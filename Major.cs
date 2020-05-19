using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;
using System.Diagnostics;

namespace Cours
{
    public partial class Major : Form
    {
        FileStream fs;
        XmlSerializer xs;
        public Major()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        //Резервные данные
        public static List<Family> listF = new List<Family>();
        public static List<Person> listP;
        
        private void Major_Load(object sender, EventArgs e)
        {


            if (File.Exists("Family.xml"))
            {
                fs = new FileStream("Family.xml", FileMode.Open);
                xs = new XmlSerializer(typeof(List<Family>));
                listF = (List<Family>)xs.Deserialize(fs);
                fs.Close();
            }
            else
            {
                //Макрушины
                listP = new List<Person>();
                listP.Add(new Person("Андрей", "Отец", 100000, 80000, false));
                listP.Add(new Person("Екатерина", "Мать", 70000, 45000, false));
                listP.Add(new Person("Ольга", "Бабушка", 50000, 15000, false));
                listP.Add(new Person("Вячеслав", "Сын", 15000, 15000, true));
                listP.Add(new Person("Ирина", "Дочь", 10000, 11000, true));

                listF.Add(new Family("Макрушины", 300000, listP));

                //Чипчаговы
                listP = new List<Person>();
                listP.Add(new Person("Кирилл", "Отец", 50000, 30000, true));
                listP.Add(new Person("Лизаветта", "Мать", 40000, 25000, false));
                listP.Add(new Person("Иосиф", "Дедушка", 40000, 20000, false));
                listP.Add(new Person("Алена", "Дочь", 20000, 7500, false));
                listP.Add(new Person("Алиса", "Дочь", 10000, 3600, false));

                listF.Add(new Family("Чипчаговы", 200000, listP));

                //Андреевы
                listP = new List<Person>();
                listP.Add(new Person("Олег", "Отец", 70000, 60000, false));
                listP.Add(new Person("Анастасия", "Мать", 70000, 55000, false));
                listP.Add(new Person("Владислав", "Дедушка", 40000, 20000, false));
                listP.Add(new Person("Таисия", "Бабушка", 50000, 23000, false));
                listP.Add(new Person("Артем", "Сын", 10000, 6250, false));
                listP.Add(new Person("Максим", "Сын", 5000, 4900, true));

                listF.Add(new Family("Андреевы", 250000, listP));
            }
            familyBindingSource.DataSource = listF;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow == null
                || dataGridView1.CurrentRow.Index == dataGridView1.RowCount)
                return;

            tt1 formP = new tt1();


            formP.f = dataGridView1.CurrentRow.Index;
            formP.personBindingSource.DataSource = listF[formP.f].Persons;

            formP.ShowDialog();
            familyBindingSource.ResetCurrentItem();
        }

        private void SaveButt_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();

            fs = new FileStream("Family.xml", FileMode.Create);

            XmlSerializer xs = new XmlSerializer(typeof(List<Family>));

            xs.Serialize(fs, listF);

            fs.Close();          
        }
        private void EditButt_Click(object sender, EventArgs e)
        {

            Editor editor = new Editor();
            editor.i = dataGridView1.CurrentRow.Index;
            editor.ShowDialog();

            if(editor.flagEdit)
            {
                familyBindingSource.ResetCurrentItem();
            }

        }

        private void AddButt_Click(object sender, EventArgs e)
        {
            Adder formAdd = new Adder();
            formAdd.ShowDialog();

            if (formAdd.flagEdit)
                familyBindingSource.ResetBindings(false);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.RemoveAt(item.Index);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();

            fs = new FileStream("Family.xml", FileMode.Create);

            XmlSerializer xs = new XmlSerializer(typeof(List<Family>));

            xs.Serialize(fs, listF);

            fs.Close();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            if (!File.Exists("Об авторе.txt"))
                File.CreateText("Об авторе.txt");

            Process.Start("notepad.exe", "Об авторе.txt");

        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            if (!File.Exists("Пояснительная записка.txt"))
                File.CreateText("Пояснительная записка.txt");

            Process.Start("notepad.exe", "Пояснительная записка.txt");
        }

        private void Major_FormClosing(object sender, FormClosingEventArgs e)
        {
            var res = MessageBox.Show("Вы уверены, что хотите закрыть программу?\nВсе несохраненные данные исчезнут.", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (res == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}

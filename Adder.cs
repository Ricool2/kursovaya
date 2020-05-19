using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cours
{
    public partial class Adder : Form
    {
        int ss;

        public bool flagEdit = false;
        
        public Adder()
        {
            InitializeComponent();
        }

        private void Adder_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Все поля обязательны к заполнению", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (Int32.TryParse(textBox2.Text, out ss) == false)
            {
                MessageBox.Show("Некорректный ввод бюджета", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                List<Person> listP = new List<Person>();
                Major.listF.Add(new Family(textBox1.Text, ss, listP));

                textBox1.Focus();
                flagEdit = true;
                MessageBox.Show("Семья добавлена");
            }
                       
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

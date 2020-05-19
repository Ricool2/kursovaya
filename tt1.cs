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
    public partial class tt1 : Form
    {
        bool select = false;
        public int f;

        public tt1()
        {
            InitializeComponent();
        }
        private void tt1_Load(object sender, EventArgs e)
        {
            Text += Major.listF[f].LastName;
            label1.Text = "Данные отображены\nбез критериев";
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView2.Columns[e.ColumnIndex].Name == "budget" || dataGridView2.Columns[e.ColumnIndex].Name == "exp")
            {
                if (e.Value.ToString() == "0")
                {
                    e.Value = "";
                }
                    
            }
                
        }

        private void dataGridView2_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string valueNew = e.FormattedValue.ToString().Trim();

            // Имя столбца (e.ColumnIndex - индекс столбца со старым значением).
            string nameColumn = dataGridView2.Columns[e.ColumnIndex].Name;

            int vInt;

            if (nameColumn == "budget" && valueNew != ""
                && !int.TryParse(valueNew, out vInt))
            {
                MessageBox.Show("Некорректный ввод бюджета");
                e.Cancel = true;    // Новое значение не принято.
            }

            else if (nameColumn == "exp" && valueNew != ""
                     && !int.TryParse(valueNew, out vInt))
            {
                MessageBox.Show("Некорректный ввод затрат");
                e.Cancel = true;    // Новое значение не принято.
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Adder_tt adder = new Adder_tt();
            adder.f = f;

            adder.ShowDialog();

            if (adder.flagEdit)
            {
                personBindingSource.ResetBindings(false);

                if (select)
                {   // Если ранее была выполнена фильтрация.
                    button4_Click(null, null);

                    // Найдем последнюю отображаемую строку и перейдем на неё.
                    for (int i = dataGridView2.RowCount - 1; i >= 0; i--)
                        if (dataGridView2.Rows[i].Visible == true)
                        {
                            // Перейти на добавленного члена. Его индекс = i.
                            dataGridView2.CurrentCell = dataGridView2[1, i];
                            break;
                        }
                }
                else
                    // Перейти на добавленного члена. Он в конце списка.
                    dataGridView2.CurrentCell = dataGridView2[1, dataGridView2.RowCount - 1];

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Editor_tt editor = new Editor_tt();
            editor.f = f;
            editor.s = dataGridView2.CurrentRow.Index;

            editor.ShowDialog();

            if (editor.flagEdit)
            {
                personBindingSource.ResetCurrentItem();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.dataGridView2.SelectedRows)
            {
                dataGridView2.Rows.RemoveAt(item.Index);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView2.CurrentCell = null;

            for (int i = 0; i < dataGridView2.RowCount; i++)
            {
                if (TestRow(i) == 0)
                    dataGridView2.Rows[i].Visible = false;
                else
                {
                    dataGridView2.Rows[i].Visible = true;
                    select = true;
                }
            }

            if (select) label1.Text = string.Format(
               "Отображены критерии:\n{0}\n({1};{2})\n({3};{4})\n{5}",
                       textBox1.Text, textBox2.Text, textBox3.Text,
                       textBox4.Text, textBox5.Text, textBox6.Text);


            // Перенести фокус на первого отображаемого члена, если он есть.
            for (int i = 0; i < dataGridView2.RowCount - 1; i++)
                if (dataGridView2.Rows[i].Visible == true)
                {
                    // Перейти на добавленного члена. Его индекс = i.
                    dataGridView2.CurrentCell = dataGridView2[1, i];
                    break;
                }

        }
        private int TestRow(int s)
        {
            Person std = Major.listF[f].Persons[s];

            int r1, r2;
            int m1, m2;
            int k = 1;

            if (textBox1.Text != "" && !std.InFamily.Contains(textBox1.Text))
            {
                k *= 0;
            }

            int.TryParse(textBox2.Text, out r1);
            int.TryParse(textBox3.Text, out r2);
            if (r2 == 0)
            {
                r2 = Major.listF[f].MonthBud;
            }
            int.TryParse(textBox4.Text, out m1);
            int.TryParse(textBox5.Text, out m2);
            if (m2 == 0)
            {
                m2 = Major.listF[f].MonthBud;
            }

            if (r1 > std.Budget || r2 < std.Budget)
            {
                k *= 0;
            }
            if (m1 > std.Exp || m2 < std.Exp)
            {
                k *= 0;
            }

            if (textBox6.Text != "")
            {
                if(textBox6.Text == "да" && !std.Debts == true)
                {
                    k *= 0;
                }
                if (textBox6.Text == "нет" && !std.Debts == false)
                {
                    k *= 0;
                }

            }
            return k;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";

        }

        private void button6_Click(object sender, EventArgs e)
        {
            select = false;
            label1.Text = "Данные отображены\nбез критериев";

            for (int i = 0; i < dataGridView2.RowCount; i++)
                dataGridView2.Rows[i].Visible = true;

        }

        private void dataGridView2_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView2.Rows.Count == 0) return;

            int d = checkBox1.Checked == true ? -1 : 1;    // Порядок сортировки.
            List<Person> list = Major.listF[f].Persons;

            switch (dataGridView2.Columns[e.ColumnIndex].Name)
            {
                case "name":
                    list.Sort((a1, a2) => d * a1.Name.CompareTo(a2.Name));
                    break;

                case "inFamily":
                    list.Sort((a1, a2) => d * a1.InFamily.CompareTo(a2.InFamily));
                    break;

                case "budget":
                    list.Sort((a1, a2) => d * a1.Budget.CompareTo(a2.Budget));
                    break;

                case "exp":
                    list.Sort((a1, a2) => d * a1.Exp.CompareTo(a2.Exp));
                    break;

                case "debts":
                    list.Sort((a1, a2) => d * a1.Debts.CompareTo(a2.Debts));
                    break;

                default:  // По другим столбцам сортировки не будет.
                    return;
            }

            personBindingSource.ResetBindings(false);

            if (select) button4_Click(null, null);  // Обновить фильтрацию.

        }

        
    }
}

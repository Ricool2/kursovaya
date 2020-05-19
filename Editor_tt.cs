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
    public partial class Editor_tt : Form
    {
        public int f, s;
        public bool flagEdit = false;

        public Editor_tt()
        {
            InitializeComponent();
        }

        private void Editor_tt_Load(object sender, EventArgs e)
        {
            Text += Major.listF[f].LastName;

            Person person = Major.listF[f].Persons[s];

            textBox1.Text = person.Name;
            textBox2.Text = person.InFamily;
            textBox3.Text = person.Budget.ToString();
            textBox4.Text = person.Exp.ToString();
            checkBox1.Checked = person.Debts;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int yb = 0, r = 0;

            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Поля красного цвета обязательны к заполнению", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                label1.ForeColor = Color.Red;
                label2.ForeColor = Color.Red;
                textBox1.Focus();
                return;
            }

            if (textBox3.Text != "" && !int.TryParse(textBox3.Text, out r))
            {
                MessageBox.Show("Бюджет должен быть числом", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox3.Focus();
                return;
            }

            if (textBox4.Text != "" && !int.TryParse(textBox4.Text, out yb))
            {
                MessageBox.Show("Затраты должны быть числом", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox4.Focus();
                return;
            }

            Person std = Major.listF[f].Persons[s];
            std.Name = textBox1.Text;
            std.InFamily = textBox2.Text;
            std.Budget = r;
            std.Exp = yb;
            std.Debts = checkBox1.Checked;

            flagEdit = true;
            Close();

        }
    }
}

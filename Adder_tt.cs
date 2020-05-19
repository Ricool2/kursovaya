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
    public partial class Adder_tt : Form
    {
        public int f;
        public bool flagEdit = false;
        public Adder_tt()
        {
            InitializeComponent();
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

            Major.listF[f].Persons.Add(new Person(textBox1.Text, textBox2.Text,
                                           r, yb, checkBox1.Checked));
            flagEdit = true;

            MessageBox.Show("Член семьи " + textBox1.Text + " добавлен.");
            Close();
            textBox1.Focus();

        }

        private void Adder_tt_Load(object sender, EventArgs e)
        {
            Text += Major.listF[f].LastName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

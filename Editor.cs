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
    public partial class Editor : Form
    {
        int ss;

        public int i;
        public bool flagEdit = false;
        public Editor()
        {
            InitializeComponent();
        }

        private void Editor_Load(object sender, EventArgs e)
        {
            textBox1.Text = Major.listF[i].LastName;
            textBox2.Text = Major.listF[i].MonthBud.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
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
                Major.listF[i].LastName = textBox1.Text;
                Major.listF[i].MonthBud = ss;
                flagEdit = true;
                Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

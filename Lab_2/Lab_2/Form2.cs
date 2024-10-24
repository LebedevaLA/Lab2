using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_2
{
    public partial class Form2 : Form
    {
        int item = 0;
        public Form2()
        {
            InitializeComponent();
            ok.DialogResult = DialogResult.OK;
            cancel.DialogResult = DialogResult.Cancel;
            AcceptButton = ok;
            CancelButton = cancel;
            comboBox1.Items.Add("Горизонтальная");
            comboBox1.Items.Add("Вертикальная");
            comboBox1.Items.Add("Волны");
            comboBox1.Items.Add("Верхне Диагональная");
            comboBox1.Items.Add("Крест-накрест");
            comboBox1.Items.Add("Крест-накрест по диагонали");
            comboBox1.SelectedItem = "Горизонтальная";
        }
        public int get_item()
        {
            return (item);
        }
       
        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cancel_Click(object sender, EventArgs e)
        {

        }

        private void ok_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Горизонтальная")
            {
                item = 0;
            }
            else if (comboBox1.Text == "Вертикальная")
            {
                item = 1;
            }
            else if (comboBox1.Text == "Волны")
            {
                item = 2;
            }
            else if (comboBox1.Text == "Верхне Диагональная")
            {
                item = 3;
            }
            else if (comboBox1.Text == "Крест-накрест")
            {
                item = 4;
            }
            else
            {
                item = 5;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace lab1
{
    public partial class Form1 : Form
    {
        Address[] address;
        MethodInfo sort = null;
        public Form1()
        {
            InitializeComponent();
            dataGridView1.ColumnCount = 3;
            dataGridView1.RowCount = 1;
            comboBox1.Items.Add("Бульбашка");
            comboBox1.Items.Add("Шейкер");
            comboBox1.Items.Add("Мін. елем.");
            comboBox1.Items.Add("Мет. вставки");
            comboBox1.SelectedIndex = 0;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if((int)numericUpDown1.Value > 0)
                dataGridView1.RowCount = (int)numericUpDown1.Value;
        }

        private void output()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.RowCount = address.Length;
            for (int i = 0; i < address.Length; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = address[i].getName();
                dataGridView1.Rows[i].Cells[1].Value = address[i].getStreet();
                dataGridView1.Rows[i].Cells[2].Value = address[i].getHouseNumber();
            }
        }
        private Address[] getObject()
        {
            Address []tempAddress = new Address[dataGridView1.RowCount];
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                tempAddress[i] = new Address(Convert.ToString(dataGridView1.Rows[i].Cells[0].Value),
                                            Convert.ToString(dataGridView1.Rows[i].Cells[1].Value),
                                            Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value));
            return tempAddress;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                address = getObject();
                MethodInfo method = null;
                if (radioButton1.Checked)
                    method = typeof(Address).GetMethod("getName");
                if (radioButton2.Checked)
                    method = typeof(Address).GetMethod("getStreet");
                if (radioButton3.Checked)
                    method = typeof(Address).GetMethod("getHouseNumber");
                
                sort.Invoke(null, new object[] { address, method });
                output();
            }
            catch { }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Address []serealizeAdress = getObject();
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (FileStream fileStream = new FileStream("Address.dat", FileMode.OpenOrCreate))
                binaryFormatter.Serialize(fileStream, serealizeAdress);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                using (FileStream fileStream = new FileStream("Address.dat", FileMode.OpenOrCreate))
                    address = (Address[])binaryFormatter.Deserialize(fileStream);
                numericUpDown1.Value = address.Length;
                output();
            }
            catch { }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(comboBox1.SelectedItem)
            {
                case "Бульбашка":
                        sort = (typeof(Sort)).GetMethod("bubble");
                    break;
                case "Шейкер":
                        sort = (typeof(Sort)).GetMethod("mix");
                    break;
                case "Мін. елем.":
                        sort = (typeof(Sort)).GetMethod("MinimumElement");
                    break;
                case "Мет. вставки":
                    sort = (typeof(Sort)).GetMethod("insert");
                    break;
            }
        }
    }
}

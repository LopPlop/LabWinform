using LabWinForm.Context;
using LabWinForm.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace LabWinForm.UI
{
    public partial class FormDbHandler : Form
    {
        private ShopContext shopContext = new ShopContext(ShopContext.GetConnection());
        private List<Shop> changedShops = new List<Shop>();
        public FormDbHandler()
        {
            InitializeComponent();
            var list = shopContext.GetAllShop();
            dataGridView1.DataSource = list;
        }

        private void FormDbHandler_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < changedShops.Count; i++) {
                shopContext.ShopUpdate(changedShops[i]);
            }
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedRow = (int)e.RowIndex;
            int selectedColumn = (int)e.ColumnIndex;

            var row = new DataGridViewRow();

            row = dataGridView1.Rows[selectedRow];

            string Name = row.Cells[1].Value.ToString();

            int price = int.Parse(row.Cells[2].Value.ToString());

            switch (selectedColumn)
            {
                case 1:
                    {
                        var name = Interaction.InputBox("Наименование", "Значенеи", Name, -1, -1);
                        dataGridView1.Rows[selectedRow].Cells[selectedColumn].Value = name;
                        changedShops.Add(new Shop { Id = (int)dataGridView1.Rows[selectedRow].Cells[0].Value, Name = name, price = (decimal)dataGridView1.Rows[selectedRow].Cells[selectedColumn+1].Value });
                        dataGridView1.Rows[selectedRow].DefaultCellStyle.BackColor = Color.GreenYellow;
                        break;
                    }
                case 2:
                    {
                        decimal prc = decimal.Parse(Interaction.InputBox("Цена", "Значение", price.ToString(), -1, -1));
                        dataGridView1.Rows[selectedRow].Cells[selectedColumn].Value = prc;
                        changedShops.Add(new Shop { Id = (int)dataGridView1.Rows[selectedRow].Cells[0].Value, price = prc, Name = (string)dataGridView1.Rows[selectedRow].Cells[selectedColumn-1].Value });
                        dataGridView1.Rows[selectedRow].DefaultCellStyle.BackColor = Color.GreenYellow;
                        break;
                    }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            changedShops.Clear();
            this.Close();
        }
    }
}

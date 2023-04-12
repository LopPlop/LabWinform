using LabWinForm.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LabWinForm.UI
{
    public partial class DeleteForm : Form
    {

        private ShopContext shopContext = new ShopContext(ShopContext.GetConnection());
        public DeleteForm()
        {
            InitializeComponent();
            var list = shopContext.GetAllShop();

            for(int i=0; i<list.Count; i++)
            {
                listBox1.Items.Insert(i, list[i].Name);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex != -1)
            {
                shopContext.ShopDelete(shopContext.GetAllShop()[listBox1.SelectedIndex]);
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
            else
            MessageBox.Show(
                "Выберите элемент",
                "Ошибка!",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

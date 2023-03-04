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

namespace LabWinForm.UI
{
    public partial class FormDbHandler : Form
    {
        private ShopContext shopContext = new ShopContext(ShopContext.GetConnection());
        public FormDbHandler()
        {
            InitializeComponent();
        }

        private void FormDbHandler_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int price = 0;
            if(int.TryParse(textBox2.Text, out price))
            {
                shopContext.ShopInsert(new Model.Shop() { Name = textBox1.Text, price = int.Parse(textBox2.Text) });
                errorProvider1.SetError(textBox2, null);
                MessageBox.Show(
                    "Успешно сохранено",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
                
            }
            else
                errorProvider1.SetError(textBox2, "Введите число!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            shopContext.ShopDelete(new Model.Shop() { Name = textBox1.Text});
            errorProvider1.SetError(textBox2, null);
            MessageBox.Show(
                    "Успешно удалено",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
            
        }
    }
}

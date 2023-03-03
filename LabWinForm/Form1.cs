using LabWinForm.Context;
using LabWinForm.Model;

namespace LabWinForm
{
    public partial class Form1 : Form
    {
        ShopContext shop;
        private string connectionStr;
        private List<Shop> shopList;
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = ".\\SQLEXPRESS";
            textBox2.Text = "LabWinForms";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Visible = true; textBox2.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button4.Enabled= true;
            button5.Enabled = true;
            connectionStr = $@"Server={textBox1.Text}; Database={textBox2.Text}; Integrated Security=true; Encrypt=false;";
            shop = new ShopContext(connectionStr);

            label1.ForeColor = Color.Green;
            label1.Text = "Connected";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

            shopList = shop.GetAllShop();
            textBox2.Text = shopList.Count.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Red;
            button4.Enabled = false;
            button5.Enabled = false;
            label1.Text = "Connection closed";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            shopList = shop.GetAllShop();
            for(int i = 0; i < shopList.Count; i++)
                richTextBox1.AppendText("id = " + shopList[i].Id.ToString() + "; " + "Name = " + shopList[i].Name.ToString() + "; " + "price = " + shopList[i].price.ToString() + "; " + "\n");
        }
    }
}
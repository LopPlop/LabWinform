using LabWinForm.Context;
using LabWinForm.Model;
using LabWinForm.UI;

namespace LabWinForm
{
    public partial class Form1 : Form
    {
        ShopContext shop = new ShopContext($@"Server=.\SQLEXPRESS; Database=LabWinForms; Integrated Security=true; Encrypt=false;");
        private string connectionStr;
        private List<Shop> shopList;
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = ".\\SQLEXPRESS";
            textBox2.Text = "LabWinForms";
            comboBox1.Items.AddRange(new string[] { "Весь список", "Самый дорогой предмет", "Самый дешевый предмет", "Предмет с ценой выше среднего" });
            comboBox1.SelectedIndex = 0;

            try
            {
                var a = shop.GetDataBases();
                for (int i = 0; i < a.Count; i++)
                {
                    TreeNode node = new TreeNode();
                    node.Text = a[i];
                    treeView1.Nodes.Add(node);
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Visible = true; textBox2.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button4.Enabled= true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
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
            button6.Enabled= false;
            button7.Enabled = false;
            label1.Text = "Connection closed";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            shopList = shop.GetAllShop();
            dataGridView1.Visible = true;
            comboBox1.Visible = true;
            dataGridView1.DataSource = shopList;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FormDbHandler formDbHandler = new FormDbHandler();
            formDbHandler.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DeleteForm deleteForm = new DeleteForm();
            deleteForm.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.AutoGenerateColumns= true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var index = comboBox1.SelectedIndex;


            switch (index)
            {
                case 0:
                    {
                        dataGridView1.DataSource = shop.GetAllShop();
                        break;
                    }
                case 1:
                    {
                        dataGridView1.DataSource = shop.GetMaxShop();
                        break;
                    }
                case 2:
                    {
                        dataGridView1.DataSource = shop.GetMinShop();
                        break;
                    }
                case 3:
                    {
                        dataGridView1.DataSource = shop.GetMoreThenAVGShop();
                        break;
                    }
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                var name = treeView1.SelectedNode.Text;

                var list = shop.GetAllTablesByDB(name);

                for (int i = 0; i < list.Count; i++)
                {
                    treeView1.SelectedNode.Nodes.Add(new TreeNode()
                    {
                        Text = list[i]
                    });
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void makeBackupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = @"C:\Users\Ilya\Desktop\DB backups";
            sfd.RestoreDirectory = true;
            sfd.FileName = $"LabWinForms_{DateTime.Now.Day}-{DateTime.Now.Month}-{DateTime.Now.Year}";
            sfd.Filter = "Backup | *.bak";

            if(sfd.ShowDialog() == DialogResult.OK)
            {
                shop.MakeDBBackup(sfd.FileName);
            }
        }

        private void loadBackupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shop.DropDB("LabWinForms");

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = @"C:\Users\Ilya\Desktop\DB backups";
            ofd.RestoreDirectory = true;
            ofd.Filter = "Backup | *.bak";
            ofd.Title = "Выберите файл";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                shop.LoadDBBackup(ofd.FileName);
            }
        }
    }
}
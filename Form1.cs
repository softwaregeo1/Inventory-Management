using System.Data;

namespace Truck_Stock
{
    public partial class TruckStock : Form
    {
        DataTable Inventory = new DataTable();
        public TruckStock()
        {
            InitializeComponent();
        }

        private void AppExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            NameTb.Text = "";
            QuantityTB.Text = "";
            PriceTb.Text = "";
            CodeTb.Text = "";
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            // Save all the values from our fields into variable
            string Name = NameTb.Text;
            string Quantity = QuantityTB.Text;
            string Code = CodeTb.Text;
            string price = PriceTb.Text;
            string category = (string)comboBox1.SelectedItem;
            string truck = (string)comboBox2.SelectedItem;

            //Add this items to the datatable
            Inventory.Rows.Add(truck,Code,Name,Quantity,price,category);

            //This clears fields after you save
            AddBtn_Click(sender, e);

        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Inventory.Rows[dataGridView1.CurrentCell.RowIndex].Delete();
            }
            catch (Exception err)
            {
                Console.WriteLine("Error: " + err);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                NameTb.Text = Inventory.Rows[dataGridView1.CurrentCell.RowIndex].ItemArray[2].ToString();
                QuantityTB.Text = Inventory.Rows[dataGridView1.CurrentCell.RowIndex].ItemArray[3].ToString();
                CodeTb.Text = Inventory.Rows[dataGridView1.CurrentCell.RowIndex].ItemArray[1].ToString();
                PriceTb.Text = Inventory.Rows[dataGridView1.CurrentCell.RowIndex].ItemArray[4].ToString();

                string ItemToLookFor = Inventory.Rows[dataGridView1.CurrentCell.RowIndex].ItemArray[5].ToString();
                comboBox1.SelectedIndex = comboBox1.Items.IndexOf(ItemToLookFor);
                string ItemToLook = Inventory.Rows[dataGridView1.CurrentCell.RowIndex].ItemArray[0].ToString();
                comboBox2.SelectedIndex = comboBox2.Items.IndexOf(ItemToLookFor);
            }
            catch (Exception err)
            {
                Console.WriteLine("There has been an error" + err);
            }
        }

        private void TruckStock_Load(object sender, EventArgs e)
        {
            Inventory.Columns.Add("Truck #");
            Inventory.Columns.Add("Code");
            Inventory.Columns.Add("Name");
            Inventory.Columns.Add("Quantity");
            Inventory.Columns.Add("Price");
            Inventory.Columns.Add("Category");

            dataGridView1.DataSource = Inventory;
        }
    }
}
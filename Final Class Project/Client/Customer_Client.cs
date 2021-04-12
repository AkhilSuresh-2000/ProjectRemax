using Final_Class_Project.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Class_Project.Client
{
    public partial class Customer_Client : Form
    {
        public Customer_Client()
        {
            InitializeComponent();
        }

        List<House> house_list = House.get_house();

        private void Customer_Client_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = house_list;
        }
    }
}

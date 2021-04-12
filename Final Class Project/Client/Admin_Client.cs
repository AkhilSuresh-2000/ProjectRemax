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
    public partial class Admin_Client : Form
    {
        public Admin_Client()
        {
            InitializeComponent();
        }

        

        private void Admin_Client_Load(object sender, EventArgs e)
        {
            refresh();
        }

        List<House> house_list = House_Data.get_house();
        List<city> cities = House_Data.get_cities();
        List<state> states = House_Data.get_states();
        List<country> countries = House_Data.get_countries();
        int selected_house = -1;


        public void load_combobox()
        {

            comboBoxcity.Items.Clear();
            comboBoxstate.Items.Clear();
            comboBoxcountry.Items.Clear();

            foreach (city c in cities)
            {
                comboBoxcity.Items.Add(c.name);
            }

            foreach (state s in states)
            {
                comboBoxstate.Items.Add(s.name);
            }

            foreach (country cn in countries)
            {
                comboBoxcountry.Items.Add(cn.name);
            }
        }

        public void refresh()
        {
            comboBoxcity.Items.Clear();
            comboBoxstate.Items.Clear();
            comboBoxcountry.Items.Clear();

            load_combobox();

            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();

            dataGridView1.Refresh();
            dataGridView1.DataSource = House.get_house();
            dataGridView1.Columns[0].Visible = false;

            textBoxhouse_number.Text = "";
            number_of_bathrooms.Refresh();
            number_of_rooms.Refresh();
            textBoxprice.Text = "";
            textBoxstreet_name.Text = "";
            checkBoxgarage.Refresh();
            checkBoxpool.Refresh();
            checkBoxfireplace.Refresh();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int garage = 0, pool = 0, fire_place = 0;

            if (checkBoxgarage.Checked == true)
            {
                garage = 1;
            }
            if (checkBoxpool.Checked == true)
            {
                pool = 1;
            }

            if (checkBoxfireplace.Checked == true)
            {
                fire_place = 1;
            }

            House house = new House();
            house.id = 1;
            house.house_number = Convert.ToInt32(textBoxhouse_number.Text.Trim());
            house.number_of_bathrooms = Convert.ToInt32(number_of_bathrooms.Value);
            house.number_of_rooms = Convert.ToInt32(number_of_rooms.Value);
            house.pool = pool;
            house.fireplace = fire_place;
            house.garage = garage;
            house.city = comboBoxcity.SelectedItem.ToString();
            house.state = comboBoxstate.SelectedItem.ToString();
            house.country = comboBoxcountry.SelectedItem.ToString();
            house.price = Convert.ToInt32(textBoxprice.Text.Trim());
            house.street_name = textBoxstreet_name.Text.Trim();

            
            house_list.Add(house);
            House_Data.Save_house(house);
            dataGridView1.DataSource = house_list;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxcity_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxcountry.SelectedItem = cities.First(s => s.name.ToString() == comboBoxcity.SelectedItem.ToString()).country;
            comboBoxstate.SelectedItem = cities.First(s => s.name.ToString() == comboBoxcity.SelectedItem.ToString()).state;
        }

        private void comboBoxcountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selected_states = states.FindAll(s => s.country.ToString() == comboBoxcountry.SelectedItem.ToString());
            var selected_cities = cities.FindAll(x => x.country.ToString() == comboBoxcountry.SelectedItem.ToString());

            comboBoxstate.Items.Clear();
            comboBoxcity.Items.Clear();

            foreach (state s in selected_states)
            {
                comboBoxstate.Items.Add(s.name);
            }

            foreach (city s in selected_cities)
            {
                comboBoxcity.Items.Add(s.name);
            }
        }

        private void comboBoxprovince_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxcountry.SelectedItem = states.First(s => s.name.ToString() == comboBoxstate.SelectedItem.ToString()).country;
            var selected_state = cities.Find(x => x.state.ToString() == comboBoxstate.SelectedItem.ToString()).state;
            var selected_cities = cities.FindAll(x => x.country.ToString() == selected_state);


            comboBoxcity.Items.Clear();

            foreach (city s in selected_cities)
            {
                comboBoxcity.Items.Add(s.name);
            }
        }

        private void buttonupdate_Click(object sender, EventArgs e)
        {
            int garage = 0, pool = 0, fire_place = 0;

            if (checkBoxgarage.Checked == true)
            {
                garage = 1;
            }
            if (checkBoxpool.Checked == true)
            {
                pool = 1;
            }

            if (checkBoxfireplace.Checked == true)
            {
                fire_place = 1;
            }

            House house = new House();
            house.id = 1;
            house.house_number = Convert.ToInt32(textBoxhouse_number.Text.Trim());
            house.number_of_bathrooms = Convert.ToInt32(number_of_bathrooms.Value);
            house.number_of_rooms = Convert.ToInt32(number_of_rooms.Value);
            house.pool = pool;
            house.fireplace = fire_place;
            house.garage = garage;
            house.city = comboBoxcity.SelectedItem.ToString();
            house.state = comboBoxstate.SelectedItem.ToString();
            house.country = comboBoxcountry.SelectedItem.ToString();
            house.price = Convert.ToInt32(textBoxprice.Text.Trim());
            house.street_name = textBoxstreet_name.Text.Trim();


            house_list.Add(house);
            House_Data.Save_house(house);
            dataGridView1.DataSource = house_list;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentCell.RowIndex > -1)
            {
                selected_house = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value);
                House h = House_Data.find(selected_house);

                textBoxhouse_number.Text = Convert.ToString(h.house_number);
                number_of_rooms.Value = Convert.ToDecimal(h.number_of_rooms);
                number_of_bathrooms.Value = Convert.ToDecimal(h.number_of_bathrooms);
                comboBoxcity.SelectedItem = h.city;
                comboBoxstate.SelectedItem = h.state;
                comboBoxcountry.SelectedItem = h.country;
                textBoxprice.Text = Convert.ToString(h.price);
                textBoxstreet_name.Text = Convert.ToString(h.street_name);

                if (h.garage == 1)
                {
                    checkBoxgarage.Checked = true;
                }
                else
                {
                    checkBoxgarage.Checked = false;
                }


                if (h.pool == 1)
                {
                    checkBoxpool.Checked = true;
                }
                else
                {
                    checkBoxpool.Checked = false;
                }


                if (h.fireplace == 1)
                {
                    checkBoxfireplace.Checked = true;
                }
                else
                {
                    checkBoxfireplace.Checked = false;
                }

            }
        }

        private void buttondelete_Click(object sender, EventArgs e)
        {
            if (selected_house > -1)
            {
                House_Data.delete(selected_house);

                refresh();
            }
        }

        private void buttonrefresh_Click(object sender, EventArgs e)
        {
            refresh();
        }
    }
}

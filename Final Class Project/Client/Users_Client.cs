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
    public partial class Users_Client : Form
    {
        public Users_Client()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void load_login_error()
        {
            login_error.Text = "Username or password are incorrect";
            login_error.Visible = true;
        }

        public bool validate_login()
        {
            bool res = true;

            if (string.IsNullOrEmpty(username_login.Text.Trim()))
            {
                username_login.BackColor = Color.Salmon;
                res = false;
            }
            if (string.IsNullOrEmpty(password_login.Text.Trim()))
            {
                password_login.BackColor = Color.Salmon;
                res = false;
            }
            
            return res;
        }

        public bool validate_register()
        {
            bool res = true;

            if (string.IsNullOrEmpty(username_register.Text.Trim()))
            {
                username_register.BackColor = Color.Salmon;
                res = false;
            }
            if (string.IsNullOrEmpty(password_register.Text.Trim()))
            {
                password_register.BackColor = Color.Salmon;
                res = false;
            }
            if (string.IsNullOrEmpty(fn_register.Text.Trim()))
            {
                fn_register.BackColor = Color.Salmon;
                res = false;
            }
            if (string.IsNullOrEmpty(ln_register.Text.Trim()))
            {
                ln_register.BackColor = Color.Salmon;
                res = false;
            }

            return res;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tabcontrol1.SelectTab(Login);
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void User_Load(object sender, EventArgs e)
        {
            tabcontrol1.Appearance = TabAppearance.FlatButtons;
            tabcontrol1.ItemSize = new Size(0, 1);
            tabcontrol1.SizeMode = TabSizeMode.Fixed;
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tabcontrol1.SelectTab(Register);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void loginbutton_Click(object sender, EventArgs e)
        {
            if(validate_login() == true)
            {
                bool login = User.Login(username_login.Text.Trim(), password_login.Text.Trim());
                if (login == true)
                {
                    Admin_Client admin = new Admin_Client();
                    admin.Show();
                    this.Hide();
                }
                else
                {
                    load_login_error();
                }
            }
        }

        private void username_login_Click(object sender, EventArgs e)
        {
            username_login.BackColor = Color.White;
        }

        private void password_login_Click(object sender, EventArgs e)
        {
            password_login.BackColor = Color.White;
        }

        private void registerbutton_Click(object sender, EventArgs e)
        {
            if (validate_register() == true)
            {

                User user = new User();
                user.first_name = fn_register.Text.Trim();
                user.last_name = ln_register.Text.Trim();
                user.middle_name = mn_register.Text.Trim();
                user.username = username_register.Text.Trim();
                user.password = password_register.Text.Trim();

                if (User.Register(user) == false)
                {
                    register_error.Text = "Username already Taken! Choose another one";
                    register_error.Visible = true;
                }
                else
                {
                    Admin_Client admin = new Admin_Client();
                    admin.Show();
                    this.Hide();
                }
            }
        }
    }
}

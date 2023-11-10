using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 土壤项目
{
    public partial class Form1 : Form
    {
        private string name="hzp";  //账号
        private string password = "1234";  //密码

        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (name.Equals(username.Text) && password.Equals(userpassowrd.Text))
            {
                MessageBox.Show("登录成功");
                //跳转界面
                this.Hide();
                new Form2().Show();
            }
            else
            {
                MessageBox.Show("登录失败");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            userpassowrd.Text = "";
            username.Text = "";
        }


    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Threading;

namespace 土壤项目
{
    public partial class Form3 : Form
    {
        public  string address_name;  //用于接收Form2的数据
        public SqlConnection conn;
        Dao_Soil d = new Dao_Soil();
        public Form3(string address_name)
        {
            InitializeComponent();
            this.address_name = address_name;
            MessageBox.Show(this.address_name);
            MessageBox.Show("欢迎进入");
            string sql = "select * from dbo.user_soil where address_name='"+this.address_name+"'";
            Dao_Soil d = new Dao_Soil();  //创建数据库连接对象
            List<Soil_user> list = new List<Soil_user>();
            IDataReader dr = d.executeQuery(sql);
            Soil_user s = new Soil_user();

            while (dr.Read())
            {
                s.Address_name = dr["address_name"].ToString();
                s.Address_ad = dr["address_ad"].ToString();
                s.Province = dr["province"].ToString();
                s.Soil_recycle = dr["soil_recycle"].ToString();
            }

            string []text=new string[] {"场地标识符","场地名称","行政地点","县市" ,"省份"};
            string[] text1 = new string[] { s.Address_name, s.Address_ad, s.Province, s.Soil_recycle, "功能强大有浏览、排序、搜索、过滤、处理分级数据、缓存更改等功能，还可以与XML数据互换。DataSet中可包括多个DataTable，可将多个查询结构存到一个DataSet中，方便操作 ADO.NET开发人员为方便数据处理开发出来的，是数据的集合，为解决DataReader的缺陷设计的，DataReader数据处理速度快，但它是只读的，一旦移到下一行就不能查看上一行的数据，DataSet则可以自由移动指针。DataSet的数据是与数据库断开的。DataSet还可用于多层应用程序中，如果应用程序运行在中间层的业务对象中来访问数据库，则业务对象需将脱机数据结构传递给客户应用程序。" };

            for (int i=0; i < text.Length; i++)
            {
                int rows = dataGridView1.Rows.Add();
                dataGridView1.Rows[rows].Cells[0].Value = text[i];
                dataGridView1.Rows[rows].Cells[1].Value = text1[i];
                
            }
            string sql1 = "select * from from3";
            IDataReader dr1 = d.executeQuery(sql1);
            List<soil_form3> list_soil = new List<soil_form3>();
            while (dr1.Read())
            {
                soil_form3 s1 = new soil_form3();
                s1.Year = dr1["年"].ToString();
                s1.Name = dr1["采样地名称"].ToString();
                s1.Soil_sort = dr1["土壤类型"].ToString();
                s1.Mo_soil = dr1["母质"].ToString();
                list_soil.Add(s1);
            }

            for (int i=0;i<5;i++)
            {
                int rows = dataGridView2.Rows.Add();
                dataGridView2.Rows[rows].Cells[0].Value = list_soil[i].Year.ToString();
                dataGridView2.Rows[rows].Cells[1].Value = list_soil[i].Name.ToString();
                dataGridView2.Rows[rows].Cells[2].Value = list_soil[i].Soil_sort.ToString();
                dataGridView2.Rows[rows].Cells[3].Value = list_soil[i].Mo_soil.ToString();
                dataGridView2.Rows[rows].Cells[4].Value = "查看";
            }

        }
        public Form3()
        {
            
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                int row=e.RowIndex;
                string str=string.Format("您选择的是第{0}", row+1);
                MessageBox.Show(str);
                this.Hide();
                new Form4().Show();
            }
        }
    }
}

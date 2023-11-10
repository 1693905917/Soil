using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;  //需要声明数据库
using System.IO;
using System.Threading;


namespace 土壤项目
{
    public partial class Form2 : Form
    {
        
        public Form2()
        {
            InitializeComponent();
            InitListView();
        }

        private void InitListView() 
        {
            Dao_Soil d = new Dao_Soil();
            string sql = "select * from dbo.user_soil;";
            List<Soil_user> list = new List<Soil_user>();  //用于接收
            IDataReader dr=d.executeQuery(sql);  //查询

            while (dr.Read())
            {
                Soil_user s = new Soil_user();
                s.Address_name = dr["address_name"].ToString();
                s.Address_ad = dr["address_ad"].ToString();
                s.Province = dr["province"].ToString();
                s.Soil_recycle = dr["soil_recycle"].ToString();
                list.Add(s);
            }

            for (int i=0;i<5;i++)
            {
                int rows = dataGridView1.Rows.Add();  //每遍历一次添加一行
                dataGridView1.Rows[rows].Cells[0].Value = list[i].Address_name;//Rows控制行  Cell控制列
                dataGridView1.Rows[rows].Cells[1].Value = list[i].Address_ad;
                dataGridView1.Rows[rows].Cells[2].Value = list[i].Province;
                dataGridView1.Rows[rows].Cells[3].Value = list[i].Soil_recycle;
                dataGridView1.Rows[rows].Cells[4].Value = "详情";

            }
        }
        //点击详情的效果
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                this.Hide();  //隐藏
                int row = this.dataGridView1.CurrentRow.Index;  //查看你点击的是第几行
                String str = string.Format("你当前选择的是第{0}行", row + 1);
                MessageBox.Show(str);
                //将所选择的行传递给Form3  相当于一个构造方法
                Form3 form3 = new Form3(dataGridView1.Rows[row].Cells[0].Value.ToString());
                ExportDataToExcel(dataGridView1);
                form3.Show();
            }
            
        }

        public void ExportDataToExcel(DataGridView myDGV)
        {
            string path = "";
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Title = "请选择要导出的位置";
            saveDialog.Filter = "Excel文件| *.xlsx;*.xls";
            saveDialog.ShowDialog();
            path = saveDialog.FileName;
            if (path.IndexOf(":") < 0) return; //判断是否点击取消
            //try
            //{
                Thread.Sleep(1000);
                StreamWriter sw = new StreamWriter(path, false, Encoding.GetEncoding("gbk"));
                StringBuilder sb = new StringBuilder();
                //写入标题
                for (int k = 0; k < myDGV.Columns.Count; k++)
                {
                    if (myDGV.Columns[k].Visible)//导出可见的标题
                    {
                        //"\t"就等于键盘上的Tab,加个"\t"的意思是: 填充完后进入下一个单元格.
                        sb.Append(myDGV.Columns[k].HeaderText.ToString().Trim() + "\t");
                    }
                }
                sb.Append(Environment.NewLine);//换行
                                               //写入每行数值
                for (int i = 0; i < myDGV.Rows.Count - 1; i++)
                {
                    System.Windows.Forms.Application.DoEvents();
                    for (int j = 0; j < myDGV.Columns.Count; j++)
                    {
                        if (myDGV.Columns[j].Visible)//导出可见的单元格
                        {
                        //注意单元格有一定的字节数量限制,如果超出,就会出现两个单元格的内容是一模一样的.
                        //具体限制是多少字节,没有作深入研究.
                        Console.WriteLine("Rows:{0}",i);
                        Console.WriteLine("Columns:{0}", j);
                        sb.Append(myDGV.Rows[i].Cells[j].Value.ToString().Trim() + "\t");
                        }
                    }
                    sb.Append(Environment.NewLine); //换行
                }
                sw.Write(sb.ToString());
                sw.Flush();
                sw.Close();
                MessageBox.Show(path + "，导出成功", "系统提示", MessageBoxButtons.OK);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using mySqlHelper;

namespace alimysql
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

         MysqlOperate  sqlOperate = new MysqlOperate();


        private void button2_Click(object sender, EventArgs e)
        {

            MySqlConnection conn = sqlOperate.MySqlGetCon();
            conn.Open();
            string sql = "select * from xsl";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();//执行ExecuteReader()返回一个MySqlDataReader对象
            while (reader.Read())//初始索引是-1，执行读取下一行数据，返回值是bool
            {
         
                listBox1.Items.Add( reader.GetString("shijian") + reader.GetString("shuliang"));//"userid"是数据库对应的列名，推荐这种方式
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "insert into xsl values('"+textBox1.Text+"','"+textBox2.Text+"')";
            sqlOperate.MySqlCom(sql);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using KGOOS.Common;
using System.Data.SqlClient;

namespace KGOOS.Login
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            getPlant();
        }

        public void getPlant()
        {

            DataSet ds = new DataSet();
            string sql = "select id_warehouse, name_warehouse from T_WareHouse";
            int id = 0;
            string name = "";
            ds = DBClass.execQuery(sql);
            List<KeyValuePair<int, string>> WareHouseList = new List<KeyValuePair<int, string>>();
            WareHouseList.Add(new KeyValuePair<int, string>(0, "请选择仓库"));
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++ )
            {
                id = 0;
                name = "";
                id = int.Parse(ds.Tables[0].Rows[i][0].ToString());
                name = ds.Tables[0].Rows[i][1].ToString();
                WareHouseList.Add(new KeyValuePair<int, string>(id, name));
            }

            WareHouse.ItemsSource = WareHouseList;
            WareHouse.SelectedValuePath = "Key";
            WareHouse.DisplayMemberPath = "Value";
            WareHouse.SelectedItem = new KeyValuePair<int, string>(0, "请选择仓库");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string name = "";
            string pass = "";
            string warehouse = "";
            name = UserName.Text;
            pass = PassWord.Text;
            warehouse = WareHouse.SelectedIndex.ToString();
            DataSet ds = new DataSet();
            string sql = "";
            sql = "select * from T_Staff as t " +
                  "where t.name_staff = '" + name + "' and t.pass_staff = '" + pass + "'";
            ds = DBClass.execQuery(sql);
            if (ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("用户名或密码有误，请检查！");
            }
            else 
            {
                sql = "select t.warehouse_staff from T_Staff as t " +
                  "where t.name_staff = '" + name + "' and t.pass_staff = '" + pass + "'";
                ds = DBClass.execQuery(sql);
                if (warehouse == "0")
                {
                    MessageBox.Show("请选择要操作的仓库！"); 
                }
                MessageBox.Show("请选择要操作的仓库！"); 
            }

        }

    }
}

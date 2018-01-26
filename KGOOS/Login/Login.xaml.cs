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
            string sql = "select * from T_Region";
            int id = 0;
            string name = "";
            ds = DBClass.execQuery(sql);
            List<KeyValuePair<int, string>> PlantList = new List<KeyValuePair<int, string>>();
            PlantList.Add(new KeyValuePair<int, string>(0, "请选择仓库"));
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++ )
            {
                id = 0;
                name = "";
                id = int.Parse(ds.Tables[0].Rows[i][0].ToString());
                name = ds.Tables[0].Rows[i][1].ToString();
                PlantList.Add(new KeyValuePair<int, string>(id, name));
            }

            Plant.ItemsSource = PlantList;
            Plant.SelectedValuePath = "Key";
            Plant.DisplayMemberPath = "Value";
            Plant.SelectedItem = new KeyValuePair<int, string>(0, "请选择仓库");
        }

    }
}

using System;
using System.Collections.Generic;
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
using StudentManagerModel;
using StudentManageBLL;

namespace StudentManagement
{
    /// <summary>
    /// register.xaml 的交互逻辑
    /// </summary>
    public partial class register : Window
    {
        public register()
        {
            InitializeComponent();
        }
        Admins admis = new Admins();
        AdminManager admin = new AdminManager();
        //注册
        private void btnLogCZ_Click(object sender, RoutedEventArgs e)
        {
            if (txtLogId.Text!=null&&txtLogName.Text!=null&&txtLogPwd.Password!=null)
            {

            admis.LoginId =Convert.ToInt32(txtLogId.Text);
            admis.LoginPwd = Convert.ToInt32(txtLogPwd.Password);
            admis.AdminName = txtLogName.Text;
            if (admin.GetAddAdmins(admis)>0)
            {
                MessageBox.Show("注册成功！");
                this.Close();
            }
            else
            {
                MessageBox.Show("注册失败请重新注册!");
            }
            }
        }
        //退出
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
      
    }
}

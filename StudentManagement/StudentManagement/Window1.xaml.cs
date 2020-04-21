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
using Common;
using StudentManageBLL;

namespace StudentManagement
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            txtLogId.Focus();
        }

        private void btnMin_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);//终止进程
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            //数据验证
            if (txtLogId.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入登录账号！", "登录提示");
                txtLogId.Focus();//焦点
                return;
            }
            if (DataValidate.IsInteger(txtLogId.Text.Trim()) == false)//通过通用层进行验证
            {
                MessageBox.Show("账号有误！(纯数字格式)", "登录提示");
                txtLogId.Focus();//聚焦
                return;
            }
            if (txtLogPwd.Password.Length == 0)
            {
                MessageBox.Show("请输入登录密码！", "登录提示");
                txtLogPwd.Focus();
                return;
            }
            //输入的账号密码
            Admins admins = new Admins()
            {
                LoginId = Convert.ToInt32(txtLogId.Text.Trim())
            };
            //先尝试和后天交互，进行查询是否有对应项
            try
            {
                Admins mainuse = new AdminManager().GetAdmins(admins);
                if (mainuse == null)
                {
                    MessageBox.Show("用户信息不存在重新输入！", "提示信息");
                    txtLogId.Focus();//聚焦
                }
                else
                {
                    if (mainuse.LoginPwd == Convert.ToInt32(txtLogPwd.Password))
                    {
                        //保存登录信息
                        App.CurrentAdmin = mainuse;
                        this.DialogResult = true;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("用户密码有误请重新输入！", "提示信息");
                        txtLogPwd.Focus();
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("服务器连接异常，登录失败！请检查您的网络！");
                throw ex;
            }
        }
        //加载事件
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //交互控制
           //  mediaElement.LoadedBehavior = MediaState.Manual;
            //添加元素完毕自动播放
          //  mediaElement.Loaded += MediaElement_Loaded;
            // mediaElement.Play();
           
        }
 

        private void MediaElement_Loaded(object sender, RoutedEventArgs e)
        {
           // (sender as MediaElement).Play();
        }
        //退出
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);//终止进程
        }


        //注册事件
        private void btnZC_Click(object sender, RoutedEventArgs e)
        {
            register register = new register();
            register.Show();
        }
    }
}

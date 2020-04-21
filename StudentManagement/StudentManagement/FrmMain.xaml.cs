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
using System.Windows.Threading;
using System.Configuration;

namespace StudentManagement
{
    /// <summary>
    /// FrmMain.xaml 的交互逻辑
    /// </summary>
    public partial class FrmMain : Window
    {
        List<int> list = new List<int>();
        public FrmMain()
        {
            InitializeComponent();
            Window1 log = new Window1();
            log.ShowDialog();//窗口打开
            if (log.DialogResult != true)
            {
                Environment.Exit(0);
            }

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(10);
            timer.Tick += Timer_Tick;

            timer.Start();
            try
            {
                statusAdminLb.Content = "操作管理员【" + App.CurrentAdmin.AdminName + "】";
                statusVersionLb.Content = "版本号：" + ConfigurationManager.AppSettings["version"].ToString();
            }
            catch (Exception)
            {

                throw;
            }
        }
        DispatcherTimer timer = null;
        private void Timer_Tick(object sender, EventArgs e)
        {

            DateTime now = DateTime.Now;
            string week = "星期天";
            switch (now.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    week = "星期天";
                    break;
                case DayOfWeek.Monday:
                    week = "星期一";
                    break;
                case DayOfWeek.Tuesday:
                    week = "星期二";
                    break;
                case DayOfWeek.Wednesday:
                    week = "星期三";
                    break;
                case DayOfWeek.Thursday:
                    week = "星期四";
                    break;
                case DayOfWeek.Friday:
                    week = "星期五";
                    break;
                case DayOfWeek.Saturday:
                    week = "星期六";
                    break;
                default:
                    break;
            }
            statusTimeLb.Content = string.Format("{0}年{1}月{2}日    {3}:{4}:{5}    {6}", now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second, week);
        }


        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void updatePwd_Click(object sender, RoutedEventArgs e)
        {

        }

        //退出系统
        private void exitMenu_Click(object sender, RoutedEventArgs e)
        {

        }

        //添加学员
        private void addsMenu_Click(object sender, RoutedEventArgs e)
        {
            
        }

        //信息管理
        private void smMenu_Click(object sender, RoutedEventArgs e)
        {
            Gird_Content.Children.Clear();
            View.FrmSruManager frmStudent = new View.FrmSruManager();
            Gird_Content.Children.Add(frmStudent);
            
        }

        //成绩写入
        private void writesMenu_Click(object sender, RoutedEventArgs e)
        {

        }

        //成绩分析 
        private void checksMenu_Click(object sender, RoutedEventArgs e)
        {

        }
        //成绩查询
        private void selectsMenu_Click(object sender, RoutedEventArgs e)
        {

        }

        //考勤打卡
        private void adakaMenu_Click(object sender, RoutedEventArgs e)
        {

        }
        //考勤查询
        private void queryaMenu_Click(object sender, RoutedEventArgs e)
        {

        }

        //联系我们
        private void lianxiMenu_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("联系热线;四个9三个2");
        }

        //官网访问
        private void inlinehMenu_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe",ConfigurationManager.AppSettings["webadd"].ToString());
        }

        //最小
        private void btnMin_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        //关闭
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 键盘快捷键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
           
            try
            {
                if (e.Key == Key.Escape)
                {
                    this.WindowState = WindowState.Minimized;
                }
                else if (e.Key == Key.S)
                {
                    menuStuMan.IsSubmenuOpen = true;
                }
                else if (e.Key == Key.Z)
                {
                    smMenu_Click(null, null);
                }
                else if (e.Key==Key.M)
                {
                    addsMenu_Click(null,null);
                }
                else if (e.Key==Key.A)
                {
                    MessageBox.Show("等我开发哈 别急");
                }
            }
            catch (Exception )
            {

                throw ;
            }


        }
        //添加学员
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            View.FrmAddStudent frmAddStudent = new View.FrmAddStudent();
            frmAddStudent.Show();
        }
        //成绩查询
        private void Grade_Click(object sender, RoutedEventArgs e)
        {
            Gird_Content.Children.Clear();
            View.FrmStudentGrade grade = new View.FrmStudentGrade();
            Gird_Content.Children.Add(grade);
        }
    }
}

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
using System.Windows.Navigation;
using System.Windows.Shapes;
using StudentManagerModel;
using StudentManageBLL;
using StudentManagerModel.ObjExt;

namespace StudentManagement.View
{
    /// <summary>
    /// FrmStudentGrade.xaml 的交互逻辑
    /// </summary>
    public partial class FrmStudentGrade : UserControl
    {
        StudentClassManager csm = new StudentClassManager();//班级访问实例化
        StudentScoreListManager score = new StudentScoreListManager();//成绩访问实例化 
        StudentManageBLL.StudentManager sm = new StudentManageBLL.StudentManager();
        List<ScoreList> scoreLists = null;//成绩表实例化                                         
         List<StudentExt> studentExt = null;
        public FrmStudentGrade()
        {
            InitializeComponent();
            select.SelectedIndex = 0;
          
            List<StudentClass> classes = csm.GetClasses();
            smclass.ItemsSource = classes;//班级绑定
            smclass.DisplayMemberPath = "ClassName";//绑定班级名称
            smclass.SelectedValuePath = "ClassId";//班级id

            smclass.SelectedIndex = 0;
            //加载展示数据  通过所选择的班级去查询班级里面的学生
            studentExt = score.GetStudent(Convert.ToInt32(smclass.SelectedValue));
            //展示所有的学生成绩表
            scoreLists = score.GetScores();         
            smDgStudentLsit.ItemsSource = scoreLists;
        }

        //提交查询  按照班级或者科目
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //首先清空路径
            smDgStudentLsit.ItemsSource = null;  
            //其次清空你那个内容
            smDgStudentLsit.Items.Clear();
            foreach ( var item in studentExt)
            {           
                //通过班级查询到的学生的ID来在成绩表中与之对相对应查到成绩表中的数据
                scoreLists = score.GetScoresStuId(Convert.ToInt32(item.StudentId));
                //添加到展示区
                smDgStudentLsit.Items.Add(scoreLists);
            }
         
        }


        //关闭
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        //未及格学员
        private void BtnNgrade_Click(object sender, RoutedEventArgs e)
        {
            smDgStudentLsit.ItemsSource = null;
            smDgStudentLsit.Items.Clear();
            scoreLists = score.GetScoresNO();
            smDgStudentLsit.ItemsSource = scoreLists;
        }
    }
}

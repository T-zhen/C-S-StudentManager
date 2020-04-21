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
using StudentManagerModel.ObjExt;
using StudentManageBLL;
using Common;
using System.IO;

namespace StudentManagement.View
{
    /// <summary>
    /// FrmSruManager.xaml 的交互逻辑
    /// </summary>
    public partial class FrmSruManager : UserControl
    {
        StudentClassManager csm = new StudentClassManager();
        StudentManageBLL.StudentManager sm = new StudentManageBLL.StudentManager();
        List<StudentExt> students = null;
        StudentExt selectStu = null;
        public FrmSruManager()
        {
            InitializeComponent();
            List<StudentClass> classes = csm.GetClasses();
            smclassCmb.ItemsSource = classes;
            smclassCmb.DisplayMemberPath = "ClassName";//设置下拉框的显示文本  与数据库绑定
            smclassCmb.SelectedValuePath = "ClassId";//下拉框的显示文本对应的value
            smclassCmb.SelectedIndex = 0;//第一项
            //DataGrid数据绑定，绑定对应的数据列
            students = sm.GetStudents(Convert.ToInt32(smclassCmb.SelectedValue));
            smDgStudentLsit.ItemsSource = students;
        }


        /// <summary>
        /// 根据班级查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectByCId_Click(object sender, RoutedEventArgs e)
        {
            if (smclassCmb.SelectedIndex<0)
            {
                MessageBox.Show("请选择班级！","提示");

            }
            students = sm.GetStudents(Convert.ToInt32(smclassCmb.SelectedValue));//通过指定信息后进行排序  添加入Students中
            smDgStudentLsit.ItemsSource = students;//完事儿添加
        }

        //排序操作
        private void btnGroupBySid_Click(object sender, RoutedEventArgs e)
        {
            if (smDgStudentLsit.ItemsSource==null)
            {
                return;
            }
            //排序  倒序
            if ((sender as Button).Tag.ToString()=="True")
            {
                students.Sort(new StudentIdDESC(true));
                groupBySidImg.Source = new BitmapImage(new Uri("/img/up.ico",UriKind.RelativeOrAbsolute));
                (sender as Button).Tag = "False";
            }
            else if ((sender as Button).Tag.ToString()=="False")
            {
                students.Sort(new StudentIdDESC(false));//改变其开关
                groupBySidImg.Source = new BitmapImage(new Uri("/img/down.ico", UriKind.RelativeOrAbsolute));
            }
            smDgStudentLsit.ItemsSource = null;//先清空
            smDgStudentLsit.ItemsSource = students;//重新刷新
        }


        /// <summary>
        /// 按照名字排序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGroupBySName_Click(object sender, RoutedEventArgs e)
        {
            //如果未选择  则return
            if (smDgStudentLsit.ItemsSource==null)
            {
                return;

            }
            if ((sender as Button).Tag.ToString() == "True")
            {
                students.Sort(new StudentNameDESC(true));//进行排序
                groupBySNameImg.Source = new BitmapImage(new Uri("/img/jiang.ico", UriKind.RelativeOrAbsolute));//对图片进行替换
                (sender as Button).Tag = "False";
            }
            else if ((sender as Button).Tag.ToString() == "False")
            {
                students.Sort(new StudentNameDESC(false));
                groupBySNameImg.Source = new BitmapImage(new Uri("/img/sheng.ico", UriKind.RelativeOrAbsolute));
                (sender as Button).Tag = "True";
            }
            smDgStudentLsit.ItemsSource = null;//提前清空
            smDgStudentLsit.ItemsSource = students;//然后进行分配
        }

        //隐藏此页面
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

    
        /// <summary>
        /// 通过输入的学号或姓名的模糊查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectBySIN_Click_3(object sender, RoutedEventArgs e)
        {
            smclassCmb.SelectedIndex = -1;
            string target = mstxtIdorName.Text.Trim();//输入框的文本
            List<StudentExt> liststu = sm.GetStudentIdOrName(target);//先装起来 暂时不添加判断之后进行添加
            smDgStudentLsit.ItemsSource = null;//先清空在进行添加
            if (liststu.Count<=0)
            {
                MessageBox.Show("为根据条件查询到相关信息！","提示");
                return;
            }
            else
            {
                students = liststu;//再添加至学生类              
                smDgStudentLsit.ItemsSource = students;
            }
        }


        //声明ID比较器
        class StudentIdDESC : IComparer<StudentExt>
        {
            
            public StudentIdDESC(bool b)
            {
                B = b;
            }
            public bool B { get; set; }
            public int Compare(StudentExt x, StudentExt y)
            {
                if (B)
                {
                    return x.StudentId.CompareTo(y.StudentId);
                }
                else
                {
                    return y.StudentId.CompareTo(x.StudentId);
                }
            }
        }
        //Name比较器
        class StudentNameDESC : IComparer<StudentExt>
        {
            
            public StudentNameDESC(bool b)
            {
                B = b;
            }
            public bool B { get; set; }
            public int Compare(StudentExt x, StudentExt y)
            {
                if (B)
                {
                    return y.StudentName.CompareTo(x.StudentName);
                }
                else
                {
                    return x.StudentName.CompareTo(y.StudentName);
                }
            }
        }

        List<int> IdList = new List<int>();//学员ID 集合
        List<FrmStudentInfor> frmList = new List<FrmStudentInfor>();//展示界面信息集合
        /// <summary>
        /// 双击学员查看信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void smDgStudentLsit_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            selectStu = smDgStudentLsit.SelectedItem as StudentExt;
            if (selectStu == null)
            {
                return;
            }
            ///当这个学员的完整信息已经存在的话，证明已经打开了一个窗口
            ///除非是打开新的学员窗口，否则只能把之前的窗口给呈现出来
            if (IdList.Contains(selectStu.StudentId))
            {
                foreach (FrmStudentInfor item in frmList)
                {
                    if (item.StuId == selectStu.StudentId)
                    {
                        //激活窗口，
                        item.Activate();
                    }
                }
            }
            else
            {
                StudentExt objStu = sm.GetStudentById(selectStu.StudentId);
                IdList.Add(selectStu.StudentId);
                View.FrmStudentInfor studentInfor = new FrmStudentInfor(objStu);
                studentInfor.Closing += StudentInfor_Closing; ;
                frmList.Add(studentInfor);
                //展示窗口
                studentInfor.Show();
            }
        }

        /// <summary>
        /// 用于移除关闭窗口的对应数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StudentInfor_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            int stuId = (sender as FrmStudentInfor).StuId;
            IdList.Remove(stuId);
            foreach (FrmStudentInfor item in frmList)
            {
                if (item.StuId == stuId)
                {
                    frmList.Remove(item);
                    return;
                }
            }
        }


       
        /// <summary>
        /// 修改学生信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdateInfor_Click(object sender, RoutedEventArgs e)
        {
            StudentExt selectStu = smDgStudentLsit.SelectedItem as StudentExt;
            if (selectStu==null)
            {
                MessageBox.Show("请选择要修改的学员！","提示");
                return;
            }
            StudentExt objStu = sm.GetStudentById(selectStu.StudentId);
            FrmUpdateStuInfor updateStuInfor = new FrmUpdateStuInfor(objStu);
            updateStuInfor.ShowDialog();
            //刷新DG中这个学员的信息
            RefreshDG();
        }

        private void RefreshDG()
        {
            students = sm.GetStudents(Convert.ToInt32(smclassCmb.SelectedValue));
            smDgStudentLsit.ItemsSource = students;
        }


        //导出Excel
        private void btnExporExcel_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog fileDialog = new Microsoft.Win32.SaveFileDialog();
            fileDialog.Filter = "Excel工作簿(*.xlsx;*.xls)|*.xlsx;*.xls";
            fileDialog.FileName = "学生信息表.xlsx";
            fileDialog.Title = "导出到Excel表";
            if (fileDialog.ShowDialog()==true)
            {
                string path = fileDialog.FileName;
                System.Data.DataTable table = sm.GetDataTable((int)smclassCmb.SelectedValue); if (table.Rows.Count<=0)
                {
                    MessageBox.Show("该班级暂无学生数据！");
                    return;
                }
                if (Common.ImportOrExportData.ExportToExcel(table,path))
                {
                    MessageBox.Show("导出数据完成！");
                }
                else
                {
                    MessageBox.Show("导出失败，请稍后重试！");
                }
            }
        }



        /// <summary>
        /// 删除学生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            selectStu = smDgStudentLsit.SelectedItem as StudentExt;//测试是否为空
            if (IdList.Contains(selectStu.StudentId))//检查该学号学生是否在集合中
            {
                MessageBox.Show("请先关闭学员信息查看界面","提示");
                return;
            }
            if (selectStu==null)
            {
                MessageBox.Show("请选择要删除的学员","提示");
                return;
            }
            StudentExt student = sm.GetStudentById(selectStu.StudentId);//获取该学号学员信息
            if (student!=null)
            {
                MessageBox.Show("该学员已被删除","提示");
                return;
            }
            //删除
            //弹框处理
            MessageBoxResult mbr = MessageBox.Show("您确定要删除【"+student.StudentName+"】学员信息？","警告",MessageBoxButton.OKCancel,MessageBoxImage.Warning);
            if (mbr==MessageBoxResult.OK)
            {
                if (sm.DeleteStudentBid(student.StudentId))
                {
                    MessageBox.Show("删除成功！");
                }
                else
                {
                    MessageBox.Show("删除失败！请稍后重试！");
                }
            }
        }
        /// <summary>
        /// 实现打印与预览
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPrint_Click(object sender, RoutedEventArgs e)
        {
            selectStu = smDgStudentLsit.SelectedItem as StudentExt;//获取信息
            if (selectStu==null)
            {
                MessageBox.Show("请选择您要打印的学员！","提示");
                return;
            }
            common.BitmapImg image = null;//照片
            if (string.IsNullOrEmpty(selectStu.StuImage))//判断照片是否为空
            {
                selectStu.ImgPath = "/img/zwzp.jpg";//默认照片

            }
            else
            {
                image = SerializeObjectTostring.DeserializeObject(selectStu.StuImage) as common.BitmapImg;//反序列化
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();//开始初始化
                bitmap.StreamSource = new MemoryStream(image.Buffer);
                bitmap.EndInit();//结束
                BitmapEncoder encoder = new PngBitmapEncoder();//图片格式
                encoder.Frames.Add(BitmapFrame.Create(bitmap));
                long sc = DateTime.Now.Ticks;//时间
                using (MemoryStream stream = new MemoryStream())
                {
                    encoder.Save(stream); //以流的形式进行存储图片
                    byte[] buffer = stream.ToArray();
                    File.WriteAllBytes(AppDomain.CurrentDomain.BaseDirectory + "/printImg/" + sc + ".png", buffer);
                    stream.Close();
                }
                selectStu.ImgPath = AppDomain.CurrentDomain.BaseDirectory + "/printImg/" + sc + ".png";//添加照片

            }
            View.FrmPrintWindow frmPrint = new FrmPrintWindow("PrintModel.xaml",selectStu);
            frmPrint.ShowInTaskbar = false;
            frmPrint.ShowDialog();
        }
    }
}

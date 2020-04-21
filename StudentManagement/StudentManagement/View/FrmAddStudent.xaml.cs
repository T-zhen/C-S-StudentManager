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
using Common;
using StudentManagerModel.ObjExt;
using StudentManageBLL;
using StudentManagerModel;
using System.IO;

namespace StudentManagement.View
{
    /// <summary>
    /// FrmAddStudent.xaml 的交互逻辑
    /// </summary>
    public partial class FrmAddStudent : Window
    {
        public FrmAddStudent()
        {
            InitializeComponent();
            StudentClassManager csm = new StudentClassManager();
            List<StudentClass> classes = csm.GetClasses();
            cmbClassName.ItemsSource = classes;
            cmbClassName.DisplayMemberPath = "ClassName";
            cmbClassName.SelectedValuePath = "ClassId";
            cmbClassName.SelectedIndex = student.ClassId;
        }

        //取消添加
        private void btnCancle_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        StudentExt student = new StudentExt();
      //  common.BitmapImg image = null;//装照片
        common.BitmapImg img = new common.BitmapImg();
        StudentManageBLL.StudentManager manager = new StudentManageBLL.StudentManager();
        //确认添加
        private void btnSureUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (CheckInfor())
            {

            
                student.Age = Convert.ToInt32(txtAge.Text);
                student.Birthday = datePkBirthday.DisplayDate;
                student.CardNo = txtCardNo.Text;
                student.ClassId = (int)cmbClassName.SelectedValue;
                student.Gender = (radBoy.IsChecked == true ? "男" : "女");
                student.PhoneNumber = txtPhoneNumber.Text;
                student.StudentAddress = (string.IsNullOrEmpty(txtAddress.Text) ? null : txtAddress.Text);
                student.StudentIdNo = txtStuNoId.Text;
                //判断是否有选择image 没选则默认
                if (student.StuImage ==null)
                {

                    stuImg.Source = new BitmapImage(new Uri("/img/zwzp.jpg", UriKind.RelativeOrAbsolute));
                }           
                else
                {
                  //则对选择的照片进行序列化

                }
                if (manager.UpAddStudent(student))
                {
                    System.Windows.MessageBox.Show("添加成功！", "提示");
                    this.Close();
                }
                else
                {
                    System.Windows.MessageBox.Show("添加失败，请稍后再试！", "提示");
                }
            }
        }

        //重新拍照
        private void btnOpenVideo_Click(object sender, RoutedEventArgs e)
        {

        }

        //重新上传
        private void btnUploadPic_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog fileDialog = new Microsoft.Win32.OpenFileDialog();
            fileDialog.Filter = "图像文件(*.jpg;*.jpeg;*.gif;*.png;*.bmp)|*.jpg;*.jpeg;*.gif;*.png,*.bmp";
            if (fileDialog.ShowDialog() == true)
            {
                string path = fileDialog.FileName;
                stuImg.Source = new BitmapImage(new Uri(path, UriKind.RelativeOrAbsolute));
                stuImg.Stretch = Stretch.UniformToFill;
                img.Buffer = File.ReadAllBytes(path);
            }
        }


        bool CheckInfor()
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                System.Windows.MessageBox.Show("姓名不能为空！");
                txtName.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtAge.Text))
            {
                System.Windows.MessageBox.Show("年龄不能为空！");
                txtAge.Focus();
                return false;
            }
            else if (!DataValidate.IsInteger(txtAge.Text))
            {
                System.Windows.MessageBox.Show("年龄必须是纯数字！");
                txtAge.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtCardNo.Text))
            {
                System.Windows.MessageBox.Show("打卡号不能为空！");
                txtCardNo.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtStuNoId.Text))
            {
                System.Windows.MessageBox.Show("身份证号不能为空！");
                txtStuNoId.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtPhoneNumber.Text))
            {
                System.Windows.MessageBox.Show("联系方式不能为空！");
                txtPhoneNumber.Focus();
                return false;
            }
            return true;
        }

        private void txtName_LostFocus(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrEmpty(txtName.Text))
            {
                System.Windows.MessageBox.Show("姓名不能为空！");
                txtName.Focus();
            }
        }

        private void txtAge_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtAge.Text))
            {
                System.Windows.MessageBox.Show("年龄不能为空！");
                txtAge.Focus();
            }
            else if (!DataValidate.IsInteger(txtAge.Text))
            {
                System.Windows.MessageBox.Show("年龄必须是纯数字！");
                txtAge.Focus();
            }
        }

        private void txtCardNo_LostFocus(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrEmpty(txtCardNo.Text))
            {
                System.Windows.MessageBox.Show("打卡号不能为空！");
                txtCardNo.Focus();
            }
        }

        private void txtStuNoId_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtStuNoId.Text))
            {
                System.Windows.MessageBox.Show("身份证号不能为空！");
                txtStuNoId.Focus();
            }
        }

        private void txtPhoneNumber_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPhoneNumber.Text))
            {
                System.Windows.MessageBox.Show("联系方式不能为空！");
                txtPhoneNumber.Focus();
            }
        }

    }
}

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
using StudentManagerModel.ObjExt;
using StudentManageBLL;
using Common;
using System.IO;


namespace StudentManagement.View
{
    /// <summary>
    /// FrmUpdateStuInfor.xaml 的交互逻辑
    /// </summary>
    public partial class FrmUpdateStuInfor : Window
    {
        StudentClassManager csm = new StudentClassManager();
        StudentManageBLL.StudentManager manager = new StudentManageBLL.StudentManager();

        common.BitmapImg image = null;//装照片
        public StudentExt student { get; set; }
        public FrmUpdateStuInfor(StudentExt stu)
        {
            InitializeComponent();
            //信息绑定
            this.Title = "修改【" + stu.StudentName + "】信息";
            student = stu;
            txtAddress.Text = stu.StudentAddress;
            txtAge.Text = stu.Age.ToString();
            txtCardNo.Text = stu.CardNo;
            txtName.Text = stu.StudentName;
            txtPhoneNumber.Text = stu.PhoneNumber;
            txtStuNoId.Text = stu.StudentIdNo;
            if (stu.Gender=="男")
            {
                radBoy.IsChecked = true;//如果性别为男 则界面男选中

            }
            else
            {
                radGirl.IsChecked = true;
            }
            datePkBirthday.DisplayDate = stu.Birthday;
            datePkBirthday.SelectedDate = stu.Birthday;
            if (string.IsNullOrEmpty(stu.StuImage))
            {
                //如果数据库为存储照片则展示预定照片
                stuImg.Source = new BitmapImage(new Uri("/img/zwzp.jpg", UriKind.RelativeOrAbsolute));
            }
            else
            {
                //如果查询到Image字段,则进行反序列化进行处理
                image = SerializeObjectTostring.DeserializeObject(stu.StuImage) as common.BitmapImg;
                img.Buffer = image.Buffer;
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.StreamSource = new MemoryStream(image.Buffer);
                bitmap.EndInit();
                stuImg.Source = bitmap;
            }
            List<StudentClass> classes = csm.GetClasses();
            cmbClassName.ItemsSource = classes;
            cmbClassName.DisplayMemberPath = "ClassName";
            cmbClassName.SelectedValuePath = "ClassId";
            cmbClassName.SelectedIndex = stu.ClassId;
        }
        common.BitmapImg img = new common.BitmapImg();

        //确认
        private void btnSureUpdate_Click(object sender, RoutedEventArgs e)
        {
            //改变数据之前的最终验证
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
                //判断是否重新选择了Image
                if (stuImg.Source == new BitmapImage(new Uri("/img/zwzp.jpg", UriKind.RelativeOrAbsolute)))
                {
                    student.StuImage = null;
                }
                //判断数据库中的图片是否和目前的上传图片一样
                else
                {
                    //证明未修改图片,目前的图片和原来数据库中的一致
                    if (image != null && img.Buffer == image.Buffer)
                    {
                        student.StuImage = Common.SerializeObjectTostring.SerializeObject(image);
                    }
                    else
                    {
                        student.StuImage = Common.SerializeObjectTostring.SerializeObject(img);
                    }

                }
                if (manager.UpdateStudentInfor(student))
                {
                    System.Windows.MessageBox.Show("修改成功！", "提示");
                    this.Close();
                }
                else
                {
                    System.Windows.MessageBox.Show("修改失败，请稍后再试！", "提示");
                }
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




        //取消
        private void btnCancle_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //重新拍照
        private void btnOpenVideo_Click(object sender, RoutedEventArgs e)
        {

        }

        //重新上传
        private void btnUploadPic_Click(object sender, RoutedEventArgs e)
        {
            //通过本地选择确定照片
            Microsoft.Win32.OpenFileDialog fileDialog = new Microsoft.Win32.OpenFileDialog();
            fileDialog.Filter= "图像文件(*.jpg;*.jpeg;*.gif;*.png;*.bmp)|*.jpg;*.jpeg;*.gif;*.png,*.bmp";
            if (fileDialog.ShowDialog()==true)
            {
                string path = fileDialog.FileName;
                stuImg.Source = new BitmapImage(new Uri(path,UriKind.RelativeOrAbsolute));
                stuImg.Stretch = Stretch.UniformToFill;//大小
                img.Buffer = File.ReadAllBytes(path);
            }
        }

        //name不为空
        private void txtName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                System.Windows.MessageBox.Show("姓名不能为空！");
                txtName.Focus();
            }
        }
        //年龄不为空且纯数字
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

        //身份账号不为空
        private void txtStuNoId_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtStuNoId.Text))
            {
                System.Windows.MessageBox.Show("身份证号不能为空！");
                txtStuNoId.Focus();
            }
        }
        //打卡号不为空
        private void txtCardNo_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtCardNo.Text))
            {
                System.Windows.MessageBox.Show("打卡号不能为空！");
                txtCardNo.Focus();
            }
        }
        //联系电话不为空
        private void txtPhoneNumber_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPhoneNumber.Text))
            {
                System.Windows.MessageBox.Show("联系方式不能为空！");
                txtPhoneNumber.Focus();
            }
        }

        public static string imgPath;
        /// <summary>
        /// 打开摄像头进行拍照
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpenVideo_Click_1(object sender, RoutedEventArgs e)
        {
            FrmStudentPhoto photo = new FrmStudentPhoto();
            photo.ShowDialog();
            if (!string.IsNullOrEmpty(imgPath))
            {
                //照片刷新了之后对新照片进行序列化
                stuImg.Source = new BitmapImage(new Uri(imgPath, UriKind.RelativeOrAbsolute));
                img.Buffer = File.ReadAllBytes(imgPath);
            }
        }
    }
}

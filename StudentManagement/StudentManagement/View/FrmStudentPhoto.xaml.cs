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
using WPFMediaKit.DirectShow.Controls;
using System.IO;

namespace StudentManagement.View
{
    /// <summary>
    /// FrmStudentPhoto.xaml 的交互逻辑
    /// </summary>
    public partial class FrmStudentPhoto : Window
    {
        public FrmStudentPhoto()
        {
            InitializeComponent();
        }

        //加载事件
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //判断系统是否连接摄像头
            if (MultimediaUtil.VideoInputNames.Length>0)
            {
                //无则采用默认摄像头
                picture.VideoCaptureSource = MultimediaUtil.VideoInputNames[0];
            }
            else
            {
                MessageBox.Show("设备未连接！","提示");
                this.Close();

            }
        }

        //重拍
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            picture.Visibility = Visibility.Visible;//显示
            pictrueYulan.Visibility = Visibility.Hidden;//隐藏
        }

        RenderTargetBitmap bmp = null;//位图转换
        //拍照
        private void btnClickPhoto_Click(object sender, RoutedEventArgs e)
        {
            bmp = new RenderTargetBitmap((int)picture.Width,(int)picture.Height,96,96,PixelFormats.Default);//设置参数
            //将摄像头捕获区域显示在照片上
            bmp.Render(picture);
            //预览
            pictrueYulan.Source = bmp;//展示在界面
            //预览图显示，影藏摄像头
            pictrueYulan.Visibility = Visibility.Visible;
            picture.Visibility = Visibility.Hidden;
        }
       //保存照片
        private void btnSavePic_Click(object sender, RoutedEventArgs e)
        {
            //如果为空则未拍照if        
            if (bmp==null)
            {
                MessageBox.Show("未检测到照片，请重新拍照！","提示");
                picture.Visibility = Visibility.Visible;//显示照片
                pictrueYulan.Visibility = Visibility.Hidden;//隐藏
                return;
            }
            //选择路径
            Microsoft.Win32.SaveFileDialog fileDialog = new Microsoft.Win32.SaveFileDialog();
            fileDialog.Filter = "图像文件(*.jpg;*.jpeg;*.gif;*.png;*.bmp)|*.jpg;*.jpeg;*.gif;*.png;*.bmp";
            fileDialog.Title = "保存照片";
            fileDialog.FileName=DateTime.Now.ToString("yyyyMMddHHmmss") + ".png";
            if (fileDialog.ShowDialog()==true)
            {
                //将刚才照片以流的形式进行保存
                BitmapEncoder encoder = new PngBitmapEncoder();//图片编码
                encoder.Frames.Add(BitmapFrame.Create(bmp));
                using (MemoryStream stream=new MemoryStream())//创建一个流进行储存
                {
                    encoder.Save(stream);
                    byte[] buffer = stream.ToArray();
                    //将图片写入
                    File.WriteAllBytes(fileDialog.FileName, buffer);
                    MessageBox.Show("照片保存成功！","提示");
                    //刷新修改界面的照片
                    FrmUpdateStuInfor.imgPath = fileDialog.FileName;
                    picture.Visibility = Visibility.Visible;
                    pictrueYulan.Visibility = Visibility.Hidden;
                }
            }

        }

    }
}

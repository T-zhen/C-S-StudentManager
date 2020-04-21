﻿using System;
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
using System.IO;
using System.IO.Packaging;
using System.Windows.Xps;
using System.Windows.Xps.Packaging;
using StudentManagerModel.ObjExt;


namespace StudentManagement.View
{
    /// <summary>
    /// FrmPrintWindow.xaml 的交互逻辑
    /// </summary>
    public partial class FrmPrintWindow : Window
    {
        FlowDocument doc;//高级文档
        DispatcherOperation op = null;
        delegate void LoadXpsMethod();
        public FrmPrintWindow(string strTmpname,object data)
        {
            InitializeComponent();
            doc = (FlowDocument)Application.LoadComponent(new Uri("/common/" + strTmpname, UriKind.RelativeOrAbsolute));
            doc.PagePadding = new Thickness(50);//距离厚度
            doc.DataContext = data;//文档绑定
            op = Dispatcher.BeginInvoke(new LoadXpsMethod(LoadXps), DispatcherPriority.ApplicationIdle);
            //“延后”调用，不然刚刚更改的数据不会马上更新，也就是说打印或者预览不到更新后的数据
            op.Completed += Op_Completed; 
        }

        private void Op_Completed(object sender, EventArgs e)
        {
            if (op.Status==DispatcherOperationStatus.Completed)//如果操作完成
            {
                doc.DataContext = null;//清空
                op.Abort();//终止操作
            }
        }

        void LoadXps()
        {
            MemoryStream stream = new MemoryStream();
            Package package = Package.Open(stream, FileMode.Create, FileAccess.ReadWrite);
            Uri DocumentUri = new Uri("pack://InMemoryDocument.xps");
            PackageStore.RemovePackage(DocumentUri);
            PackageStore.AddPackage(DocumentUri, package);
            XpsDocument xpsDocument = new XpsDocument(package, CompressionOption.Fast, DocumentUri.AbsoluteUri);
            //将flow document写入基于内存的xps document中去
            XpsDocumentWriter writer = XpsDocument.CreateXpsDocumentWriter(xpsDocument);//在这里需要添加对.NET 4.0 的一些应用
            writer.Write(((IDocumentPaginatorSource)doc).DocumentPaginator);
            //获取这个基于内存的xps document的fixed documen
            docViewer.Document = xpsDocument.GetFixedDocumentSequence();
            //关闭基于内存的xps document
            xpsDocument.Close();
        }
    }


}

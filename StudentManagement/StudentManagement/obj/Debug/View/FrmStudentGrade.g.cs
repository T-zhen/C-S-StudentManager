﻿#pragma checksum "..\..\..\View\FrmStudentGrade.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "2378B7F99CABCFD29AF4978C28E4D489B41BE193AFBDB07949009E81CA78743A"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using StudentManagement.View;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace StudentManagement.View {
    
    
    /// <summary>
    /// FrmStudentGrade
    /// </summary>
    public partial class FrmStudentGrade : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 44 "..\..\..\View\FrmStudentGrade.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox select;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\View\FrmStudentGrade.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox smclass;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\View\FrmStudentGrade.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Close;
        
        #line default
        #line hidden
        
        
        #line 94 "..\..\..\View\FrmStudentGrade.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox mstxtIdorName;
        
        #line default
        #line hidden
        
        
        #line 95 "..\..\..\View\FrmStudentGrade.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSelectBySIN;
        
        #line default
        #line hidden
        
        
        #line 102 "..\..\..\View\FrmStudentGrade.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnExportExcel;
        
        #line default
        #line hidden
        
        
        #line 108 "..\..\..\View\FrmStudentGrade.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnPrint;
        
        #line default
        #line hidden
        
        
        #line 115 "..\..\..\View\FrmStudentGrade.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnNgrade;
        
        #line default
        #line hidden
        
        
        #line 132 "..\..\..\View\FrmStudentGrade.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid smDgStudentLsit;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/StudentManagement;component/view/frmstudentgrade.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\FrmStudentGrade.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.select = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 2:
            this.smclass = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            
            #line 52 "..\..\..\View\FrmStudentGrade.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Close = ((System.Windows.Controls.Button)(target));
            
            #line 74 "..\..\..\View\FrmStudentGrade.xaml"
            this.Close.Click += new System.Windows.RoutedEventHandler(this.Close_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.mstxtIdorName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.btnSelectBySIN = ((System.Windows.Controls.Button)(target));
            return;
            case 7:
            this.btnExportExcel = ((System.Windows.Controls.Button)(target));
            return;
            case 8:
            this.BtnPrint = ((System.Windows.Controls.Button)(target));
            return;
            case 9:
            this.BtnNgrade = ((System.Windows.Controls.Button)(target));
            
            #line 115 "..\..\..\View\FrmStudentGrade.xaml"
            this.BtnNgrade.Click += new System.Windows.RoutedEventHandler(this.BtnNgrade_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.smDgStudentLsit = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

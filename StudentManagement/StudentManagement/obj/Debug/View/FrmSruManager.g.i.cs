﻿#pragma checksum "..\..\..\View\FrmSruManager.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "9F5D127D6177DC48449FAD7510AD921BF45023E4FB9E7097D4CA8C324050C66A"
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
    /// FrmSruManager
    /// </summary>
    public partial class FrmSruManager : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 44 "..\..\..\View\FrmSruManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox smclassCmb;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\View\FrmSruManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSelectByCId;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\View\FrmSruManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnGroupBySid;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\View\FrmSruManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image groupBySidImg;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\View\FrmSruManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnGroupBySName;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\View\FrmSruManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image groupBySNameImg;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\..\View\FrmSruManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnClose;
        
        #line default
        #line hidden
        
        
        #line 101 "..\..\..\View\FrmSruManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox mstxtIdorName;
        
        #line default
        #line hidden
        
        
        #line 102 "..\..\..\View\FrmSruManager.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSelectBySIN;
        
        #line default
        #line hidden
        
        
        #line 137 "..\..\..\View\FrmSruManager.xaml"
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
            System.Uri resourceLocater = new System.Uri("/StudentManagement;component/view/frmsrumanager.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\FrmSruManager.xaml"
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
            this.smclassCmb = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 2:
            this.btnSelectByCId = ((System.Windows.Controls.Button)(target));
            
            #line 46 "..\..\..\View\FrmSruManager.xaml"
            this.btnSelectByCId.Click += new System.Windows.RoutedEventHandler(this.btnSelectByCId_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnGroupBySid = ((System.Windows.Controls.Button)(target));
            
            #line 52 "..\..\..\View\FrmSruManager.xaml"
            this.btnGroupBySid.Click += new System.Windows.RoutedEventHandler(this.btnGroupBySid_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.groupBySidImg = ((System.Windows.Controls.Image)(target));
            return;
            case 5:
            this.btnGroupBySName = ((System.Windows.Controls.Button)(target));
            
            #line 58 "..\..\..\View\FrmSruManager.xaml"
            this.btnGroupBySName.Click += new System.Windows.RoutedEventHandler(this.btnGroupBySName_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.groupBySNameImg = ((System.Windows.Controls.Image)(target));
            return;
            case 7:
            this.btnClose = ((System.Windows.Controls.Button)(target));
            
            #line 81 "..\..\..\View\FrmSruManager.xaml"
            this.btnClose.Click += new System.Windows.RoutedEventHandler(this.btnClose_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.mstxtIdorName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.btnSelectBySIN = ((System.Windows.Controls.Button)(target));
            
            #line 102 "..\..\..\View\FrmSruManager.xaml"
            this.btnSelectBySIN.Click += new System.Windows.RoutedEventHandler(this.btnSelectBySIN_Click_3);
            
            #line default
            #line hidden
            return;
            case 10:
            this.smDgStudentLsit = ((System.Windows.Controls.DataGrid)(target));
            
            #line 137 "..\..\..\View\FrmSruManager.xaml"
            this.smDgStudentLsit.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.smDgStudentLsit_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


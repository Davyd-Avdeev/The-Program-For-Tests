﻿#pragma checksum "..\..\NewTestWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "E54BC39B9CE86CAD66D77DB942F4439E90A12B3EC103C239986A19200664FD94"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Program;
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


namespace Program {
    
    
    /// <summary>
    /// NewTestWindow
    /// </summary>
    public partial class NewTestWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\NewTestWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbxTestName;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\NewTestWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCreate;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\NewTestWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbxPass;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\NewTestWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnBack;
        
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
            System.Uri resourceLocater = new System.Uri("/Program;component/newtestwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\NewTestWindow.xaml"
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
            
            #line 8 "..\..\NewTestWindow.xaml"
            ((Program.NewTestWindow)(target)).Closed += new System.EventHandler(this.Window_Closed);
            
            #line default
            #line hidden
            return;
            case 2:
            this.tbxTestName = ((System.Windows.Controls.TextBox)(target));
            
            #line 16 "..\..\NewTestWindow.xaml"
            this.tbxTestName.GotFocus += new System.Windows.RoutedEventHandler(this.tbxTestName_GotFocus);
            
            #line default
            #line hidden
            
            #line 16 "..\..\NewTestWindow.xaml"
            this.tbxTestName.LostFocus += new System.Windows.RoutedEventHandler(this.tbxTestName_LostFocus);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnCreate = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\NewTestWindow.xaml"
            this.btnCreate.Click += new System.Windows.RoutedEventHandler(this.btnCreate_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.tbxPass = ((System.Windows.Controls.TextBox)(target));
            
            #line 18 "..\..\NewTestWindow.xaml"
            this.tbxPass.GotFocus += new System.Windows.RoutedEventHandler(this.tbxPass_GotFocus);
            
            #line default
            #line hidden
            
            #line 18 "..\..\NewTestWindow.xaml"
            this.tbxPass.LostFocus += new System.Windows.RoutedEventHandler(this.tbxPass_LostFocus);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnBack = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\NewTestWindow.xaml"
            this.btnBack.Click += new System.Windows.RoutedEventHandler(this.btnBack_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


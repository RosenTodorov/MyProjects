﻿#pragma checksum "..\..\ProgramWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "F3EC42983DC4315E62BA12E06AF1D540"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18408
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace CinemaBookingSystem {
    
    
    /// <summary>
    /// ProgramWindow
    /// </summary>
    public partial class ProgramWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 120 "..\..\ProgramWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ItemsControl showsButtons;
        
        #line default
        #line hidden
        
        
        #line 122 "..\..\ProgramWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label DayOfWeekLabel;
        
        #line default
        #line hidden
        
        
        #line 125 "..\..\ProgramWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Path BtnArrow;
        
        #line default
        #line hidden
        
        
        #line 137 "..\..\ProgramWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnForward;
        
        #line default
        #line hidden
        
        
        #line 138 "..\..\ProgramWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Path BtnArrow1;
        
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
            System.Uri resourceLocater = new System.Uri("/CinemaBookingSystem;component/programwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ProgramWindow.xaml"
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
            this.showsButtons = ((System.Windows.Controls.ItemsControl)(target));
            return;
            case 2:
            this.DayOfWeekLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            
            #line 123 "..\..\ProgramWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonBackward_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.BtnArrow = ((System.Windows.Shapes.Path)(target));
            return;
            case 5:
            this.btnForward = ((System.Windows.Controls.Button)(target));
            
            #line 137 "..\..\ProgramWindow.xaml"
            this.btnForward.Click += new System.Windows.RoutedEventHandler(this.Button_Forward_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.BtnArrow1 = ((System.Windows.Shapes.Path)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

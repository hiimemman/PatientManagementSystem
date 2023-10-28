﻿#pragma checksum "..\..\..\PatientManagementSystem.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "40142564001858FBADBD69DCF347BEC7E224ED84"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MahApps.Metro.Controls;
using MahApps.Metro.IconPacks;
using MahApps.Metro.IconPacks.Converter;
using PatientManagementSystem;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace PatientManagementSystem {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : MahApps.Metro.Controls.MetroWindow, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\..\PatientManagementSystem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal PatientManagementSystem.LoadingScreen loadingScreen;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\PatientManagementSystem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal PatientManagementSystem.ChooseRole chooseRole;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\PatientManagementSystem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid contentGrid;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\PatientManagementSystem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal PatientManagementSystem.PatientLogin patientLogin;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\PatientManagementSystem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal PatientManagementSystem.LogIn loginControl;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\PatientManagementSystem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal PatientManagementSystem.Register registerControl;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\PatientManagementSystem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal PatientManagementSystem.Dashboard dashboardControl;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\PatientManagementSystem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal PatientManagementSystem.Patient patientControl;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\PatientManagementSystem.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal PatientManagementSystem.AddPatient addPatientControl;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.5.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/PatientManagementSystem;component/patientmanagementsystem.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\PatientManagementSystem.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.5.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.5.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.loadingScreen = ((PatientManagementSystem.LoadingScreen)(target));
            return;
            case 2:
            this.chooseRole = ((PatientManagementSystem.ChooseRole)(target));
            return;
            case 3:
            this.contentGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 4:
            this.patientLogin = ((PatientManagementSystem.PatientLogin)(target));
            return;
            case 5:
            this.loginControl = ((PatientManagementSystem.LogIn)(target));
            return;
            case 6:
            this.registerControl = ((PatientManagementSystem.Register)(target));
            return;
            case 7:
            this.dashboardControl = ((PatientManagementSystem.Dashboard)(target));
            return;
            case 8:
            this.patientControl = ((PatientManagementSystem.Patient)(target));
            return;
            case 9:
            this.addPatientControl = ((PatientManagementSystem.AddPatient)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}


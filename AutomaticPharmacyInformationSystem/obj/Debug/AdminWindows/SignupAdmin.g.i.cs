﻿#pragma checksum "..\..\..\AdminWindows\SignupAdmin.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "87F879AE02CDC54FFEA260AA7E10636C986F3E1881DD6C968FE1956227B1B578"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using AutomaticPharmacyInformationSystem;
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


namespace AutomaticPharmacyInformationSystem {
    
    
    /// <summary>
    /// SignupAdmin
    /// </summary>
    public partial class SignupAdmin : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 25 "..\..\..\AdminWindows\SignupAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox loginBox;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\AdminWindows\SignupAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox passwordBox;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\AdminWindows\SignupAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox passwordBoxRepeat;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\AdminWindows\SignupAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SecondName;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\AdminWindows\SignupAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox FirstName;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\AdminWindows\SignupAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Surname;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\AdminWindows\SignupAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NumberPhone;
        
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
            System.Uri resourceLocater = new System.Uri("/AutomaticPharmacyInformationSystem;component/adminwindows/signupadmin.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\AdminWindows\SignupAdmin.xaml"
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
            this.loginBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 25 "..\..\..\AdminWindows\SignupAdmin.xaml"
            this.loginBox.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.loginBox_PreviewKeyDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.passwordBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 26 "..\..\..\AdminWindows\SignupAdmin.xaml"
            this.passwordBox.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.passwordBox_PreviewKeyDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.passwordBoxRepeat = ((System.Windows.Controls.TextBox)(target));
            
            #line 27 "..\..\..\AdminWindows\SignupAdmin.xaml"
            this.passwordBoxRepeat.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.passwordBoxRepeat_PreviewKeyDown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.SecondName = ((System.Windows.Controls.TextBox)(target));
            
            #line 28 "..\..\..\AdminWindows\SignupAdmin.xaml"
            this.SecondName.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.SecondName_PreviewTextInput);
            
            #line default
            #line hidden
            
            #line 28 "..\..\..\AdminWindows\SignupAdmin.xaml"
            this.SecondName.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.SecondName_PreviewKeyDown);
            
            #line default
            #line hidden
            return;
            case 5:
            this.FirstName = ((System.Windows.Controls.TextBox)(target));
            
            #line 29 "..\..\..\AdminWindows\SignupAdmin.xaml"
            this.FirstName.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.FirstName_PreviewTextInput);
            
            #line default
            #line hidden
            
            #line 29 "..\..\..\AdminWindows\SignupAdmin.xaml"
            this.FirstName.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.FirstName_PreviewKeyDown);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Surname = ((System.Windows.Controls.TextBox)(target));
            
            #line 30 "..\..\..\AdminWindows\SignupAdmin.xaml"
            this.Surname.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.Surname_PreviewTextInput);
            
            #line default
            #line hidden
            
            #line 30 "..\..\..\AdminWindows\SignupAdmin.xaml"
            this.Surname.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.Surname_PreviewKeyDown);
            
            #line default
            #line hidden
            return;
            case 7:
            this.NumberPhone = ((System.Windows.Controls.TextBox)(target));
            
            #line 31 "..\..\..\AdminWindows\SignupAdmin.xaml"
            this.NumberPhone.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.NumberPhone_PreviewTextInput);
            
            #line default
            #line hidden
            
            #line 31 "..\..\..\AdminWindows\SignupAdmin.xaml"
            this.NumberPhone.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.NumberPhone_PreviewKeyDown);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 33 "..\..\..\AdminWindows\SignupAdmin.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CloseBtn);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 34 "..\..\..\AdminWindows\SignupAdmin.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.RegistrationAccount);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 35 "..\..\..\AdminWindows\SignupAdmin.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.LoginAccount);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


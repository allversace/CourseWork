﻿#pragma checksum "..\..\AddPreparation.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "D24620E26955F9E883B78255986D7E76FE16422D3629E7A36F575E2FE3DCEE5D"
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
    /// AddPreparation
    /// </summary>
    public partial class AddPreparation : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 24 "..\..\AddPreparation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox producer;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\AddPreparation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox form;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\AddPreparation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox name;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\AddPreparation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox price;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\AddPreparation.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox amount;
        
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
            System.Uri resourceLocater = new System.Uri("/AutomaticPharmacyInformationSystem;component/addpreparation.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AddPreparation.xaml"
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
            this.producer = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.form = ((System.Windows.Controls.TextBox)(target));
            
            #line 25 "..\..\AddPreparation.xaml"
            this.form.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.form_PreviewKeyDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.name = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.price = ((System.Windows.Controls.TextBox)(target));
            
            #line 27 "..\..\AddPreparation.xaml"
            this.price.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.TextBox_PreviewTextInput);
            
            #line default
            #line hidden
            
            #line 27 "..\..\AddPreparation.xaml"
            this.price.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.price_PreviewKeyDown);
            
            #line default
            #line hidden
            return;
            case 5:
            this.amount = ((System.Windows.Controls.TextBox)(target));
            
            #line 28 "..\..\AddPreparation.xaml"
            this.amount.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.TextBox_PreviewTextInput_1);
            
            #line default
            #line hidden
            
            #line 28 "..\..\AddPreparation.xaml"
            this.amount.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.amount_PreviewKeyDown);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 30 "..\..\AddPreparation.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CloseBtn);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 31 "..\..\AddPreparation.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Add_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


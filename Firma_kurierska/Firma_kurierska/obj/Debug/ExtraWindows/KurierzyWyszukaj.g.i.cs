﻿#pragma checksum "..\..\..\ExtraWindows\KurierzyWyszukaj.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "467410B51DACCCDFC36372C714B5E35A2F4CDE4E335CD9B2E2BE87440BB297D9"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//     Wersja wykonawcza:4.0.30319.42000
//
//     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
//     kod zostanie ponownie wygenerowany.
// </auto-generated>
//------------------------------------------------------------------------------

using Firma_kurierska.ExtraWindows;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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


namespace Firma_kurierska.ExtraWindows {
    
    
    /// <summary>
    /// KurierzyWyszukaj
    /// </summary>
    public partial class KurierzyWyszukaj : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 38 "..\..\..\ExtraWindows\KurierzyWyszukaj.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxtKurierzyWImie;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\ExtraWindows\KurierzyWyszukaj.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxtKurierzyWNazwisko;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\ExtraWindows\KurierzyWyszukaj.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxtKurierzyWMiasto;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\ExtraWindows\KurierzyWyszukaj.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxtKurierzyWTelefon;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\ExtraWindows\KurierzyWyszukaj.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnKuerierzyWWyszukaj;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\ExtraWindows\KurierzyWyszukaj.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnKuerierzyWWyjdz;
        
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
            System.Uri resourceLocater = new System.Uri("/Firma_kurierska;component/extrawindows/kurierzywyszukaj.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\ExtraWindows\KurierzyWyszukaj.xaml"
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
            this.TxtKurierzyWImie = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.TxtKurierzyWNazwisko = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.TxtKurierzyWMiasto = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.TxtKurierzyWTelefon = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.BtnKuerierzyWWyszukaj = ((System.Windows.Controls.Button)(target));
            
            #line 52 "..\..\..\ExtraWindows\KurierzyWyszukaj.xaml"
            this.BtnKuerierzyWWyszukaj.Click += new System.Windows.RoutedEventHandler(this.BtnKurierzyWWyszukaj_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.BtnKuerierzyWWyjdz = ((System.Windows.Controls.Button)(target));
            
            #line 53 "..\..\..\ExtraWindows\KurierzyWyszukaj.xaml"
            this.BtnKuerierzyWWyjdz.Click += new System.Windows.RoutedEventHandler(this.BtnKurierzyWWyjdz_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


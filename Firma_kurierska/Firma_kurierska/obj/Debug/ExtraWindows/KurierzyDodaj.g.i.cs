﻿#pragma checksum "..\..\..\ExtraWindows\KurierzyDodaj.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "F5E9E5D340CBAE39CF77A1CDF7E4AC5BC9C7E67637B8A44A4738EE0B5E391F30"
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
    /// KurierzyDodaj
    /// </summary>
    public partial class KurierzyDodaj : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 39 "..\..\..\ExtraWindows\KurierzyDodaj.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxtKurierzyDImie;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\ExtraWindows\KurierzyDodaj.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxtKurierzyDNazwisko;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\ExtraWindows\KurierzyDodaj.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxtKurierzyDMiasto;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\ExtraWindows\KurierzyDodaj.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxtKurierzyDTelefon;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\ExtraWindows\KurierzyDodaj.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnKuerierzyDDodaj;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\ExtraWindows\KurierzyDodaj.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnKuerierzyDWyjdz;
        
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
            System.Uri resourceLocater = new System.Uri("/Firma_kurierska;component/extrawindows/kurierzydodaj.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\ExtraWindows\KurierzyDodaj.xaml"
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
            this.TxtKurierzyDImie = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.TxtKurierzyDNazwisko = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.TxtKurierzyDMiasto = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.TxtKurierzyDTelefon = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.BtnKuerierzyDDodaj = ((System.Windows.Controls.Button)(target));
            
            #line 53 "..\..\..\ExtraWindows\KurierzyDodaj.xaml"
            this.BtnKuerierzyDDodaj.Click += new System.Windows.RoutedEventHandler(this.BtnKurierzyWWyszukaj_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.BtnKuerierzyDWyjdz = ((System.Windows.Controls.Button)(target));
            
            #line 54 "..\..\..\ExtraWindows\KurierzyDodaj.xaml"
            this.BtnKuerierzyDWyjdz.Click += new System.Windows.RoutedEventHandler(this.BtnKurierzyWWyjdz_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


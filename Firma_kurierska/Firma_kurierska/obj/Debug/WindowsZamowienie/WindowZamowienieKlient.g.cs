﻿#pragma checksum "..\..\..\WindowsZamowienie\WindowZamowienieKlient.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "39AA0D045FB2A7D318EEFC93117045393A0B8A624E33D8D5ACDFBF80F7B73344"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//     Wersja wykonawcza:4.0.30319.42000
//
//     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
//     kod zostanie ponownie wygenerowany.
// </auto-generated>
//------------------------------------------------------------------------------

using Firma_kurierska.WindowsZamowienie;
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


namespace Firma_kurierska.WindowsZamowienie {
    
    
    /// <summary>
    /// WindowZamowienieKlient
    /// </summary>
    public partial class WindowZamowienieKlient : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 30 "..\..\..\WindowsZamowienie\WindowZamowienieKlient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DGZamowienieNadawca;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\WindowsZamowienie\WindowZamowienieKlient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnZamowienieNadawcaWyszukaj;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\WindowsZamowienie\WindowZamowienieKlient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxtZamowienieNadawcaWyszukaj;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\WindowsZamowienie\WindowZamowienieKlient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CBZamowienieIloscPaczek;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\..\WindowsZamowienie\WindowZamowienieKlient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnZamowienieNadawcaWyjscie;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\WindowsZamowienie\WindowZamowienieKlient.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnZamowienieNadawcaDalej;
        
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
            System.Uri resourceLocater = new System.Uri("/Firma_kurierska;component/windowszamowienie/windowzamowienieklient.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\WindowsZamowienie\WindowZamowienieKlient.xaml"
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
            this.DGZamowienieNadawca = ((System.Windows.Controls.DataGrid)(target));
            
            #line 30 "..\..\..\WindowsZamowienie\WindowZamowienieKlient.xaml"
            this.DGZamowienieNadawca.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.DGZamowienieNadawca_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.BtnZamowienieNadawcaWyszukaj = ((System.Windows.Controls.Button)(target));
            
            #line 47 "..\..\..\WindowsZamowienie\WindowZamowienieKlient.xaml"
            this.BtnZamowienieNadawcaWyszukaj.Click += new System.Windows.RoutedEventHandler(this.BtnZamowienieNadawcaWyszukaj_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.TxtZamowienieNadawcaWyszukaj = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.CBZamowienieIloscPaczek = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.BtnZamowienieNadawcaWyjscie = ((System.Windows.Controls.Button)(target));
            
            #line 77 "..\..\..\WindowsZamowienie\WindowZamowienieKlient.xaml"
            this.BtnZamowienieNadawcaWyjscie.Click += new System.Windows.RoutedEventHandler(this.BtnZamowienieNadawcaWyjscie_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.BtnZamowienieNadawcaDalej = ((System.Windows.Controls.Button)(target));
            
            #line 78 "..\..\..\WindowsZamowienie\WindowZamowienieKlient.xaml"
            this.BtnZamowienieNadawcaDalej.Click += new System.Windows.RoutedEventHandler(this.BtnZamowienieNadawcaDalej_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


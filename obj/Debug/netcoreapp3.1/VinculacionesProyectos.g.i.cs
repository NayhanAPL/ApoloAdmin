﻿#pragma checksum "..\..\..\VinculacionesProyectos.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "227D11211493D7CE068202E3983749C538C9E69A"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using ApoloAdmin;
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


namespace ApoloAdmin {
    
    
    /// <summary>
    /// VinculacionesProyectos
    /// </summary>
    public partial class VinculacionesProyectos : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\..\VinculacionesProyectos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView ListArtistas;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\VinculacionesProyectos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox nombre;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\VinculacionesProyectos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox lugar;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\..\VinculacionesProyectos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox descripcion;
        
        #line default
        #line hidden
        
        
        #line 93 "..\..\..\VinculacionesProyectos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Borrar;
        
        #line default
        #line hidden
        
        
        #line 100 "..\..\..\VinculacionesProyectos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Canselar;
        
        #line default
        #line hidden
        
        
        #line 107 "..\..\..\VinculacionesProyectos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Guardar;
        
        #line default
        #line hidden
        
        
        #line 124 "..\..\..\VinculacionesProyectos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label mensajeSubLeft;
        
        #line default
        #line hidden
        
        
        #line 125 "..\..\..\VinculacionesProyectos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Aceptar;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.17.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ApoloAdmin;component/vinculacionesproyectos.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\VinculacionesProyectos.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.17.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.ListArtistas = ((System.Windows.Controls.ListView)(target));
            
            #line 20 "..\..\..\VinculacionesProyectos.xaml"
            this.ListArtistas.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ListArtistas_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.nombre = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.lugar = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.descripcion = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.Borrar = ((System.Windows.Controls.Button)(target));
            
            #line 93 "..\..\..\VinculacionesProyectos.xaml"
            this.Borrar.Click += new System.Windows.RoutedEventHandler(this.Borrar_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Canselar = ((System.Windows.Controls.Button)(target));
            
            #line 100 "..\..\..\VinculacionesProyectos.xaml"
            this.Canselar.Click += new System.Windows.RoutedEventHandler(this.Canselar_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.Guardar = ((System.Windows.Controls.Button)(target));
            
            #line 107 "..\..\..\VinculacionesProyectos.xaml"
            this.Guardar.Click += new System.Windows.RoutedEventHandler(this.Guardar_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.mensajeSubLeft = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.Aceptar = ((System.Windows.Controls.Button)(target));
            
            #line 125 "..\..\..\VinculacionesProyectos.xaml"
            this.Aceptar.Click += new System.Windows.RoutedEventHandler(this.Aceptar_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


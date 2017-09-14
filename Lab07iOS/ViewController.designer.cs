// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace Lab07iOS
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton BtnBuscar { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton BtnValidarActividad { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField IDNumber { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel LabelEstadoActividad { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField TextCategoria { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField TextExistencia { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField TextNombre { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField TextPrecio { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (BtnBuscar != null) {
                BtnBuscar.Dispose ();
                BtnBuscar = null;
            }

            if (BtnValidarActividad != null) {
                BtnValidarActividad.Dispose ();
                BtnValidarActividad = null;
            }

            if (IDNumber != null) {
                IDNumber.Dispose ();
                IDNumber = null;
            }

            if (LabelEstadoActividad != null) {
                LabelEstadoActividad.Dispose ();
                LabelEstadoActividad = null;
            }

            if (TextCategoria != null) {
                TextCategoria.Dispose ();
                TextCategoria = null;
            }

            if (TextExistencia != null) {
                TextExistencia.Dispose ();
                TextExistencia = null;
            }

            if (TextNombre != null) {
                TextNombre.Dispose ();
                TextNombre = null;
            }

            if (TextPrecio != null) {
                TextPrecio.Dispose ();
                TextPrecio = null;
            }
        }
    }
}
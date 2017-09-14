// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Lab07iOS
{
    [Register ("ValidateController")]
    partial class ValidateController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton ButtonValidarActividad { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField TextClaveAcceso { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField TextCorreo { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (ButtonValidarActividad != null) {
                ButtonValidarActividad.Dispose ();
                ButtonValidarActividad = null;
            }

            if (TextClaveAcceso != null) {
                TextClaveAcceso.Dispose ();
                TextClaveAcceso = null;
            }

            if (TextCorreo != null) {
                TextCorreo.Dispose ();
                TextCorreo = null;
            }
        }
    }
}
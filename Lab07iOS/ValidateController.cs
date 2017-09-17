using Foundation;
using System;
using UIKit;

namespace Lab07iOS
{
    public partial class ValidateController : UIViewController
    {
        public ValidateController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            ButtonValidarActividad.TouchUpInside += (sender, e) =>
            {
                var Client = new SALLab07.ServiceClient();
                // TODO : Continuar con la validacion
            };
            

        }
    }
}
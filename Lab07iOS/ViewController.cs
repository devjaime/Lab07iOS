using System;

using UIKit;

namespace Lab07iOS
{
    /// <summary>
    /// Permite al usuario buscar el producto por su id
    /// </summary>
    public partial class ViewController : UIViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            // Validar actividad
            BtnValidarActividad.TouchUpInside += (sender, e) =>
            {
                if (this.Storyboard.InstantiateViewController("ValidateController") is ValidateController Controller)
                {
                    this.NavigationController.PushViewController(Controller, true);
                }
            };

            // Busacr !!! Id de producto a  buscar

            // Abonarse a los eventos de busqueda !!!
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}
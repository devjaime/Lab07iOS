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

            // Validacion de la actividad.
            ButtonValidarActividad.TouchUpInside += async(sender, e) =>
            {
                var Client = new SALLab07.ServiceClient();

                var Email = TextCorreo.Text;
                var PassWord = TextClaveAcceso.Text;
                NorthWind.INorthWindModel Model = new Lab07Model.Products() as NorthWind.INorthWindModel;

                var Result = await Client.ValidateAsync(Email, 
                    PassWord, 
                    Model);

                var Alert = UIAlertController.Create("Resultado", 
                    $"{Result.Status}\n{Result.FullName}\n{Result.Token}", 
                    UIAlertControllerStyle.Alert);
                Alert.AddAction(UIAlertAction.Create("Ok", 
                    UIAlertActionStyle.Default, 
                    null));
                PresentViewController(Alert, true, null);
            };
        }
    }
}
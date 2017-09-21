using System;
using UIKit;
using Lab07Model;

namespace Lab07iOS
{
    /// <summary>
    /// Permite al usuario buscar un producto por su ID.
    /// </summary>
    public partial class ViewController : UIViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Lab07Model.Products Productos = new Lab07Model.Products();

            // Muestra el estado de la busqueda.
            Productos.ChangeStatus += (s, e) => 
            {
                var EstatusActual = (e as ChangeStatusEventArgs).Status.ToString();
                switch (EstatusActual)
                {
                    case "CallingWebAPI":
                        EstatusActual = "Buscando datos...";
                        break;
                    case "VerifyingResult":
                        EstatusActual = "Procesando datos...";
                        break;
                    case "ProductFound":
                        EstatusActual = "Producto encontrado";
                        break;
                    case "ProductNotFound":
                        EstatusActual = "Producto no encontrado";
                        break;
                    default:
                        EstatusActual = "";
                        break;
                }
                LabelEstadoActividad.Text = EstatusActual;
            };

            // Navegacion hacia Validar actividad
            BtnValidarActividad.TouchUpInside += (sender, e) =>
            {
                if (this.Storyboard.InstantiateViewController("ValidateController") is ValidateController Controller)
                {
                    this.NavigationController.PushViewController(Controller, true);
                }
            };

            // Buscar producto por Id !
            BtnBuscar.TouchUpInside += async (sender, ev) =>
            {
                var IdProducto = this.IDNumber.Text;
                try
                {
                    Lab07Model.Product ResultProduct = await Productos.GetProductByIDAsync(int.Parse(IdProducto)) as Product;
                    this.TextNombre.Text = ResultProduct.ProductName;
                    this.TextPrecio.Text = ResultProduct.UnitPrice.ToString();
                    this.TextExistencia.Text = ResultProduct.UnitsInStock.ToString();
                    this.TextCategoria.Text = ResultProduct.CategoryID.ToString();
                }
                catch (Exception excpt)
                {
                    var Alert = UIAlertController.Create("Ooupss !",
                    $"{excpt.Message}\n",
                    UIAlertControllerStyle.Alert);
                    Alert.AddAction(UIAlertAction.Create("Ok",
                        UIAlertActionStyle.Default,
                        null));
                    PresentViewController(Alert, true, null);
                }
            };
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}
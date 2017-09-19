using System;

using UIKit;
using Lab07Model;
using System.Threading.Tasks;

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

        Lab07Model.Products Productos = null;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            Productos = new Lab07Model.Products();
            Productos.ChangeStatus += (s, e) =>
            {
                var EstatusActual = string.Empty;
                switch (e.Status)
                {
                    case NorthWind.StatusOptions.CallingWebAPI:
                        EstatusActual = "Buscando datos...";
                        break;
                    case NorthWind.StatusOptions.VerifyingResult:
                        EstatusActual = "Procesando datos...";
                        break;
                    case NorthWind.StatusOptions.ProductFound:
                        EstatusActual = "Producto encontrado";
                        break;
                    case NorthWind.StatusOptions.ProductNotFound:
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
                //Lab07Model.Product ResultProduct = await BuscaProductAsync(int.Parse(IdProducto));
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
                    var Alert = UIAlertController.Create("Exception",
                    $"{excpt.Message}\n",
                    UIAlertControllerStyle.Alert);
                    Alert.AddAction(UIAlertAction.Create("Ok",
                        UIAlertActionStyle.Default,
                        null));
                    PresentViewController(Alert, true, null);
                }
            };
        }

        private async Task<Lab07Model.Product> BuscaProductAsync(int productId)
        {
            return await Productos.GetProductByIDAsync(productId) as Product;
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}
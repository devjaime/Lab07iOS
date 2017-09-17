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
            BtnBuscar.TouchUpInside += async(sender, e) =>
            {
                string IdProducto = this.IDNumber.ToString();

                var ResultProduct = await BuscaProductAsync(int.Parse(IdProducto));

                TextNombre.Text = ResultProduct.ProductName;
                TextPrecio.Text = ResultProduct.UnitPrice.ToString();
                TextExistencia.Text = ResultProduct.UnitsInStock.ToString();
                TextCategoria.Text = ResultProduct.CategoryID.ToString();

            };
        }

        private async Task<Product> BuscaProductAsync(int productId)
        {
            var Productos = new Products();
            var TextoEstado = LabelEstadoActividad;
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

                TextoEstado.Text = EstatusActual;
            };
            return await Productos.GetProductByIDAsync(productId) as Product;
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}
using Android.App;
using Android.Widget;
using Android.OS;
using Lab07Model;
using System.Threading.Tasks;

namespace Lab07Android
{
    [Activity(Label = "BuscarProducto", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            var BuscarButton = FindViewById<Button>(Resource.Id.BtnBuscar);
            BuscarButton.Click += async(sender, ev) => 
            {
                string IdProducto = FindViewById<EditText>(Resource.Id.TextID).Text;

                var ResultProduct = await BuscaProductAsync(int.Parse(IdProducto));

                var Nombre = FindViewById<EditText>(Resource.Id.TextNombre);
                Nombre.Text = ResultProduct.ProductName;

                var Precio = FindViewById<EditText>(Resource.Id.TextPrecio);
                Precio.Text = ResultProduct.UnitPrice.ToString();

                var Existencia = FindViewById<EditText>(Resource.Id.TextExistencia);
                Existencia.Text = ResultProduct.UnitsInStock.ToString();

                var Categoria = FindViewById<EditText>(Resource.Id.TextCategoria);
                Categoria.Text = ResultProduct.CategoryID.ToString();
            };
        }

        private async Task<Product> BuscaProductAsync(int productId)
        {
            var Productos = new Products();
            var TextoEstado = FindViewById<TextView>(Resource.Id.TextEstadoActividad);
            Productos.ChangeStatus += (s, e) => 
            {
                var EstatusActual = string.Empty;
                //switch (e.Status)
                //{
                //    case NorthWind.StatusOptions.CallingWebAPI:
                //        EstatusActual = "Buscando datos...";
                //        break;
                //    case NorthWind.StatusOptions.VerifyingResult:
                //        EstatusActual = "Procesando datos...";
                //        break;
                //    case NorthWind.StatusOptions.ProductFound:
                //        EstatusActual = "Producto encontrado";
                //        break;
                //    case NorthWind.StatusOptions.ProductNotFound:
                //        EstatusActual = "Producto no encontrado";
                //        break;
                //    default:
                //        EstatusActual = "";
                //        break;
                //}

                TextoEstado.Text = EstatusActual;
                System.Threading.Thread.Sleep(2000); // Pause 1 sec
            };
            return await Productos.GetProductByIDAsync(productId) as Product;
        }
    }
}
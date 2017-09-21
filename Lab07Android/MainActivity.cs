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

            // Buscar el producto por su ID.
            var BuscarButton = FindViewById<Button>(Resource.Id.BtnBuscar);
            BuscarButton.Click += async(sender, ev) => 
            {
                string IdProducto = FindViewById<EditText>(Resource.Id.TextID).Text;

                if (!string.IsNullOrEmpty(IdProducto))
                {
                    var ResultProduct = await BuscaProductAsync(int.Parse(IdProducto));
                    if (ResultProduct != null)
                    {
                        var Nombre = FindViewById<EditText>(Resource.Id.TextNombre);
                        Nombre.Text = ResultProduct.ProductName;

                        var Precio = FindViewById<EditText>(Resource.Id.TextPrecio);
                        Precio.Text = ResultProduct.UnitPrice.ToString();

                        var Existencia = FindViewById<EditText>(Resource.Id.TextExistencia);
                        Existencia.Text = ResultProduct.UnitsInStock.ToString();

                        var Categoria = FindViewById<EditText>(Resource.Id.TextCategoria);
                        Categoria.Text = ResultProduct.CategoryID.ToString();
                    }
                    else
                    {
                        FindViewById<TextView>(Resource.Id.TextEstadoActividad).Text = "No hay producto correspondiente.";
                    }
                }
                else
                {
                    FindViewById<TextView>(Resource.Id.TextEstadoActividad).Text = "El Id no es valido, entre un numero.";
                }
            };
        }

        private async Task<Product> BuscaProductAsync(int productId)
        {
            var Productos = new Products();
            Product ProductoEncontrado = null;

            var TextoEstado = FindViewById<TextView>(Resource.Id.TextEstadoActividad);
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

            try
            {
                ProductoEncontrado = await Productos.GetProductByIDAsync(productId) as Product;
            }
            catch (System.Exception except)
            {
                AlertDialog.Builder alertDialog = new AlertDialog.Builder(this);
                alertDialog.SetTitle("Ooups !");
                alertDialog.SetMessage(except.Message);
                alertDialog.SetNeutralButton("Ok", (s,e) => alertDialog.Dispose() );
                alertDialog.Show();
            }

            return ProductoEncontrado;
        }
    }
}
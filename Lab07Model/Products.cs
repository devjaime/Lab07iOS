using NorthWind;
using System;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Net.Http;
using Newtonsoft.Json;

namespace Lab07Model
{
    public class Products : INorthWindModel
    {
        public Product MyProduct { get; private set; }

        public event ChangeStatusEventHandler ChangeStatus;

        public Task<IProduct> GetProductByIDAsync(int ID)
        {
            var result = GetProductByIDAsync(ID,"");
            return result;
        }

        public async Task<IProduct> GetProductByIDAsync(int ID, string test ="")
        {
            Product MyProduct = null;
            using (var Client = new System.Net.Http.HttpClient())
            {
                MyProduct = new Product();
                Client.BaseAddress = new Uri("https://ticapacitacion.com/webapi/northwind/");
                Client.DefaultRequestHeaders.Accept.Clear();
                Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                ChangeStatusEventArgs changeStatus = new ChangeStatusEventArgs
                {
                    Status = StatusOptions.CallingWebAPI,
                    MessageDeStatus = "Buscando datos..."
                };

                // Notificando que la api web és invocada
                ChangeStatus?.Invoke(this, changeStatus);

                HttpResponseMessage Response = await Client.GetAsync($"product/{ID}");

                //if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                //{
                //    // Notificando que se va a verificar el resultado de la llamada
                //    changeStatus.Status = StatusOptions.VerifyingResult;
                //    changeStatus.MessageDeStatus = "Processando el resultado...";

                //    ChangeStatus?.Invoke(this, changeStatus);
                //    System.Threading.Thread.Sleep(2000); // Pause 1 sec
                //}

                

                if (Response.IsSuccessStatusCode)
                {
                    changeStatus.Status = StatusOptions.VerifyingResult;
                    changeStatus.MessageDeStatus = "Processando el resultado...";

                    ChangeStatus?.Invoke(this, changeStatus);


                    var JSONProduct = await Response.Content.ReadAsStringAsync();

                    MyProduct = JsonConvert.DeserializeObject<Product>(JSONProduct);                    

                    if (MyProduct != null)
                    {
                        // Notificando que el producto fué encontrado
                        changeStatus.Status = StatusOptions.ProductFound;
                        changeStatus.MessageDeStatus = "Producto encontrado.";

                        ChangeStatus?.Invoke(this, changeStatus);
                    }
                    else
                    {
                        // Notificando que el producto no fué encontrado
                        changeStatus.Status = StatusOptions.ProductNotFound;
                        changeStatus.MessageDeStatus = "Producto no encontrado.";

                        ChangeStatus?.Invoke(this, changeStatus);
                        MyProduct = null;
                    }
                }
            }
            return MyProduct;
        }
    }
}
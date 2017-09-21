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
                };
                // Notificando que la api web és invocada
                ChangeStatus?.Invoke(this, changeStatus);

                HttpResponseMessage Response = await Client.GetAsync($"product/{ID}");

                changeStatus.Status = StatusOptions.VerifyingResult;
                ChangeStatus?.Invoke(this, changeStatus);

                await Task.Delay(1000); // Simulando el procesamiento

                if (Response.IsSuccessStatusCode)
                {

                    var JSONProduct = await Response.Content.ReadAsStringAsync();

                    MyProduct = JsonConvert.DeserializeObject<Product>(JSONProduct);

                    if (MyProduct != null)
                    {
                        // Notificando que el producto fué encontrado
                        changeStatus.Status = StatusOptions.ProductFound;
                        ChangeStatus?.Invoke(this, changeStatus);
                    }
                    else
                    {
                        // Notificando que el producto no fué encontrado
                        changeStatus.Status = StatusOptions.ProductNotFound;
                        ChangeStatus?.Invoke(this, changeStatus);
                        MyProduct = null;
                    }
                }
            }
            return MyProduct;
        }
    }
}
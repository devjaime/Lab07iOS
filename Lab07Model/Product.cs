using NorthWind;
using System;
using System.Threading.Tasks;

namespace Lab07Model
{
    public class Product:IProduct, INorthWindModel
    {
        #region Implementa IProduct
        public int ProductID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string ProductName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int? SupplierID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int? CategoryID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string QuantityPerUnit { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public decimal? UnitPrice { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public short? UnitsInStock { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public short? UnitsOnOrder { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public short? ReorderLevel { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool Discontinued { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        #endregion

        #region Implementa INorthWindModel
        public event ChangeStatusEventHandler ChangeStatus;

        public void GetProductByIDAsync()
        {

        }

        public Task<IProduct> GetProductByIDAsync(int ID)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    public class ChangeStatusEventArgs : IChangeStatusEventArgs
    {
        public StatusOptions Status {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }
    }

    //enum StatusOptions
    //{
    //CallingWebApi     -> El momento en que la api web sera invocada
    //VerifyingResult   -> El momento en que se va a procesar la respuesta de la api web
    //ProductFound      -> El momento en que se verifico que el producto fué encontrado
    //ProductNotFound   -> El momento en que se verifico que el producto no fué encontrado
    //}
}

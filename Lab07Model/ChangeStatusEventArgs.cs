using NorthWind;

namespace Lab07Model
{
    public class ChangeStatusEventArgs : IChangeStatusEventArgs
    {
        public StatusOptions Status
        {
            get;
            set;
        }
    }
}

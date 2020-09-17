using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerCoffeeShop
{
    class Table
    {
        private int amount;
        private Boolean status;

        public Table(int amount, bool status)
        {
            this.Amount = amount;
            this.Status = status;
        }

        protected bool Status { get => status; set => status = value; }
        protected int Amount { get => amount; set => amount = value; }
    }
}

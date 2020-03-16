using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automaten
{
    class MoneyBox
    {
        private int moneyInSafe;

        //Shows the amount of money currently in the safe.
        public int ShowMoney()
        {
            return this.moneyInSafe;
        }

        // Adds money to the safe in case a purchase has come through.
        public void AddMoney(int money)
        {
            this.moneyInSafe += money;
        }

        //Withdraws money from the safe.
        public void WithdrawMoney()
        {
            this.moneyInSafe = 0;
        }
    }
}

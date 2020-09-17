using BankingDomain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace BankKiosk
{
    public class WindowsFormsFedNotifier : INotifyTheFeds
    {
        public void NotifyOfWithdraw(BankAccount bankAccount, decimal amountToWithdraw)
        {
            
            MessageBox.Show($"Notifying the feds of withdrawl of {amountToWithdraw:c}");
            
        }
    }
}

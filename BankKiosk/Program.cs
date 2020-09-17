using BankingDomain;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankKiosk
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var container = Bootstrap();
            Application.Run(container.GetInstance<Form1>());
        }

        public static Container Bootstrap()
        {
            var container = new Container();

            container.Options.EnableAutoVerification = false;
            container.Register<ISystemTime, SystemTime>();
            container.Register<ICalculateBankAccountBonuses, StandardBonusCalculator>();
            container.Register<IProvideTheCutoffClock, StandardCutoffClock>();
            container.Register<INotifyTheFeds, WindowsFormsFedNotifier>();
            container.Register<BankAccount>();
            container.Register<Form1>();
            return container;
        }

    }
    

}

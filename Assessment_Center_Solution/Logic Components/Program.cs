using System;
using System.Windows.Forms;

namespace Assessment_Center_Solution
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            LogicController logicController = new LogicController();
            Application.Run(logicController.GetForm());
        }
    }
}

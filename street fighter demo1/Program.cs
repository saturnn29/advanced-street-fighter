using System;

namespace street_fighter_demo1
{
    // Features upgraded by Tran Hoang Duy Linh - 104222060, Swinburne University of Technology
    // This program is inspired by: https://github.com/mooict/Street-Fighter-Demo-MOO-ICT

    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MainMenu());
        }
    }
}
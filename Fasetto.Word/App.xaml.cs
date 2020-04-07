using Fasetto.Word.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Fasetto.Word
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Custom startup so we can load our IoC immediately before anything else
        /// </summary>
        /// <param name="e"></param>
        protected override void OnStartup(StartupEventArgs e)
        {
            // let the base application do what it needs
            base.OnStartup(e);

            // setUp IoC (dependancy injection)
            IoC.SetUp();

            // show the MainWindow which was default before (in StartupUri)
            Current.MainWindow = new MainWindow();
            Current.MainWindow.Show();
        }
    }
}

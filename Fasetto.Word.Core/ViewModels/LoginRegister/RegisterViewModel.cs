using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// View model for the register screen
    /// </summary>
    public class RegisterViewModel : BaseViewModel
    {

        #region Public Properties

        public string Email { get; set; }

        /// <summary>
        /// A flag indicating if the login command is running
        /// </summary>
        public bool RegisterIsRunning { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// the command to login
        /// </summary>
        public ICommand LoginCommand { get; set; }
        public ICommand RegisterCommand { get; set; }

        #endregion

        #region Constructor
        public RegisterViewModel()
        {

            //create commands
            // you should not have to pass parameter to a command but for the password we have to
            RegisterCommand = new RelayParametarizedCommand(async (param) => await RegisterAsync(param)); // Anonymous method for the argument

            LoginCommand = new RelayCommand(async () => await LoginAsync()); // Anonymous method for the argument

        }

    
        #endregion

        /// <summary>
        /// Attempts to register new the user
        /// </summary>
        /// <param name="param">The <see cref="SecureString"/> string passed in from the view</param>
        /// <returns></returns>
        public async Task RegisterAsync(object param)
        {
            await RunCommand(() => RegisterIsRunning, async () =>
            {

                await Task.Delay(500);

            });
        
        }

        /// <summary>
        /// Takes the user to login page
        /// </summary>
        /// <returns></returns>
        public async Task LoginAsync()
        {
            IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.Login);


            await Task.Delay(1);       
        }
    }
}

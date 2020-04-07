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
    /// View model for the login screen
    /// </summary>
    public class LoginViewModel : BaseViewModel
    {

        #region Public Properties

        public string Email { get; set; }

        /// <summary>
        /// A flag indicating if the login command is running
        /// </summary>
        public bool LoginIsRunning { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// the command to login
        /// </summary>
        public ICommand LoginCommand { get; set; }
        public ICommand RegisterCommand { get; set; }

        #endregion

        #region Constructor
        public LoginViewModel()
        {

            //create commands
            // you should not have to pass parameter to a command but for the password we have to
            LoginCommand = new RelayParametarizedCommand(async (param) => await LoginAsync(param)); // Anonymous method for the argument

            RegisterCommand = new RelayCommand(async () => await RegisterAsync()); // Anonymous method for the argument

        }

    
        #endregion

        /// <summary>
        /// Attempts to log the userin
        /// </summary>
        /// <param name="param">The <see cref="SecureString"/> string passed in from the view</param>
        /// <returns></returns>
        public async Task LoginAsync(object param)
        {
            // '() => LoginIsRunning' is the lambda expresssion that we are passing
            // if we didnt pass it as expression and passed it directly then we wouldnt be able to edit the properties value
            // you cant pass property as 'ref' so '() => LoginIsRunning' is basically passing the property as ref
            await RunCommand(() => LoginIsRunning, async () =>
            {

                await Task.Delay(500);

                var pass = (param as IHavePassword).SecurePassword.Unsecure();
            });
        
        }

        /// <summary>
        /// Takes the user to register page
        /// </summary>
        /// <returns></returns>
        public async Task RegisterAsync()
        {
            IoC.Get<ApplicationViewModel>().CurrentPage = ApplicationPage.Register;

            await Task.Delay(1);       
        }
    }
}

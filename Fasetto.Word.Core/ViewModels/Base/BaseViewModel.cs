using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Fasetto.Word.Core
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// The event that is fired when any child property changes its value
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        public void OnPropertyChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        #region Command Helpers

        /// <summary>
        /// Runs a command if the updaing flag is not set.
        /// If the flag is true (indicationg the function is already running) then the action is not run.
        /// If teh flag is false (indicating no running function then the action is run).
        /// Once the action is finished if it was run, then the flag is reset to false
        /// </summary>
        /// <param updatingFlag="">the boolean flag defining if the command is already running</param>
        /// <param action=""> the action to ru if the command is not already running</param>
        /// <returns></returns>
        protected async Task RunCommand(Expression<Func<bool>> updatingFlag, Func<Task> action)
        {
            // check if the flag property is true (meaning teh function is already running)
            // GetPorpertyValue returns the property value
            if (updatingFlag.GetPorpertyValue())
                return;

            // set the property flag to true to indicate its running
            updatingFlag.SetPropertyValue(true);

            try
            {
                // run the passed in action
                await action();
            }
            finally // also with finally we buble up all the errors
            {
                // set the property flag back to false because now its finished
                updatingFlag.SetPropertyValue(false);
            }
        }

        #endregion
    }
}

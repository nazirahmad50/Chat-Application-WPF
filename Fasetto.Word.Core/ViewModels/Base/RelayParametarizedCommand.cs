using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Fasetto.Word.Core
{
    public class RelayParametarizedCommand : ICommand
    {
        private Action<object> mAction;

        public RelayParametarizedCommand(Action<object> action)
        {
            mAction = action;

        }
        public event EventHandler CanExecuteChanged;


        /// <summary>
        /// A relay command can always execute
        /// </summary>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Executes the commands Action
        /// </summary>
        public void Execute(object parameter)
        {
            mAction(parameter);
        }
    }
}

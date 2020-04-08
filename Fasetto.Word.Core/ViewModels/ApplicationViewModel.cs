using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// The view model for the whole application
    /// The applciation state as a view model
    /// </summary>
    public class ApplicationViewModel : BaseViewModel
    {
        #region Properties

        /// <summary>
        /// The current page of the applicaiton
        /// </summary>
        public ApplicationPage CurrentPage { get; set; } = ApplicationPage.Login;

        /// <summary>
        /// True if the side menu should be shown
        /// </summary>
        public bool IsSideMenuVisible { get; set; }

        #endregion
    }
}

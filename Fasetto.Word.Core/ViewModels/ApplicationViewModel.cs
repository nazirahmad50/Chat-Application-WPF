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
        public ApplicationPage CurrentPage { get; private set; } = ApplicationPage.Login;

        /// <summary>
        /// True if the side menu should be shown
        /// </summary>
        public bool IsSideMenuVisible { get; set; }

        #endregion

        /// <summary>
        /// Navigate to the specified page
        /// </summary>
        public void GoToPage(ApplicationPage page)
        {
            // set the current page
            CurrentPage = page;

            // show sideMenu or not
            IsSideMenuVisible = page == ApplicationPage.Chat; // set to true if page is chat

        }
    }
}

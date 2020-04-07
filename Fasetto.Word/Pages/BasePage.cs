using System.Windows.Controls;
using System.Windows;
using System;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using Fasetto.Word.Core;

namespace Fasetto.Word
{
    /// <summary>
    /// generic base page for viewModels
    /// </summary>
    /// <typeparam name="VM"></typeparam>
    public class BasePage<VM> : Page where VM : BaseViewModel, new()
    {
        #region Private Member

        private VM viewModel;

        #endregion

        #region Public Properties
        /// <summary>
        /// The aniamtion to play when page first loaded
        /// </summary>
        public ePageAnimation PageLoadAnimation { get; set; } = ePageAnimation.SlideInAndFadeInFromRight;

            
        /// <summary>
        /// The aniamtion to play when page first un loaded
        /// </summary>
        public ePageAnimation PageUnloadedAnimation { get; set; } = ePageAnimation.SlideInAndFadeOutToLeft;

        /// <summary>
        /// The time any slide aniamtion takes
        /// </summary>
        public float SlideSeconds { get; set; } = 0.8f;

        /// <summary>
        /// The viewModel associated with this page
        /// </summary>
        public VM ViewModel
        {
            get
            {
                return viewModel;
            }
            set
            {
                // if nothing has changed then return
                if (viewModel == value)
                    return;

                // update value
                viewModel = value;

                // set the datatcontext for this page
                DataContext = viewModel;
            }
        }
        #endregion

        #region Constructor
        public BasePage()
        {
            // if we are animating in hide to begin with
            // dont want page visible at start because we are animating it
            if (PageLoadAnimation != ePageAnimation.None)
                Visibility = Visibility.Collapsed;

            Loaded += BasePage_LoadedAsync;

            // create default viewModel
            ViewModel = new VM();
        }

        #endregion

        /// <summary>
        /// Once the page is loaded, perform any required animation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BasePage_LoadedAsync(object sender, System.Windows.RoutedEventArgs e)
        {
            await AnimateInAsync();
        }

        public async Task AnimateInAsync()
        {
            switch (PageLoadAnimation)
            {
                case ePageAnimation.SlideInAndFadeInFromRight:
                    await this.SlideAndFadeInFromRight(SlideSeconds);
                    break;
                case ePageAnimation.None:
                    return;
            }
        }

        public async Task AnimateOutAsync()
        {
            switch (PageUnloadedAnimation)
            {
                case ePageAnimation.SlideInAndFadeOutToLeft:
                    await this.SlideAndFadeOutToLeft(SlideSeconds);
                    break;
                case ePageAnimation.None:
                    return;
            }
        }
    }
}

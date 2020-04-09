using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Fasetto.Word
{
    /// <summary>
    /// Interaction logic for PageHost.xaml
    /// </summary>
    public partial class PageHost : UserControl
    {
        // these are dependancy properties their similar to atttched properties
        #region Dependency Properties

        /// <summary>
        /// The current page to show in the page host
        /// </summary>
        public BasePage CurrentPage
        {
            get { return (BasePage)GetValue(CurrentPageProperty); }
            set { SetValue(CurrentPageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CurrentPage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentPageProperty =
            DependencyProperty.Register("CurrentPage", typeof(BasePage), typeof(PageHost), new UIPropertyMetadata(CurrentPagePropertyChanged));

        #endregion

        public PageHost()
        {
            InitializeComponent();
        }

        /// <summary>
        /// called when the <see cref="CurrentPage"/> value changes
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void CurrentPagePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            // simply swapped around the new page content with the old page
            // get the frames
            Frame newPageFrame = (d as PageHost).NewPage;
            Frame OldPageFrame = (d as PageHost).OldPage;

            // store the current page content as the old page
            // 'oldPageContent' is previous page content
            object oldPageContent = newPageFrame.Content;

            // remove current page from new page frame
            newPageFrame.Content = null;

            // move the previous page into the old page frame
            OldPageFrame.Content = oldPageContent;

            // animate out previous page when the loaded event fires in basepage
            // cast and check to basepage
            if (oldPageContent is BasePage oldPage)
                oldPage.ShouldAnimateOut = true;

            // set new page content
            newPageFrame.Content = e.NewValue;
        }
    }
}

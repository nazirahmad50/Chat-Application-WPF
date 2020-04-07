using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Fasetto.Word
{
    /// <summary>
    /// Helpers to animate pages in specific ways
    /// </summary>
   public static class PageAnimations
    {
        /// <summary>
        /// Slide page from right
        /// </summary>
        /// <param name="page"></param>
        /// <param name="secs"></param>
        /// <returns></returns>
        public static async Task SlideAndFadeInFromRight(this Page page, float secs)
        {
            Storyboard sb = new Storyboard();

            sb.AddSlideFromRight(secs, page.WindowWidth);

            sb.AddFadeIn(secs);


            sb.Begin(page);

            page.Visibility = Visibility.Visible;

            // convert secs to milliseconds for the delay method
            await Task.Delay((int)(secs * 1000));
        }

        /// <summary>
        /// Slide page out to the left
        /// </summary>
        /// <param name="page"></param>
        /// <param name="secs"></param>
        /// <returns></returns>
        public static async Task SlideAndFadeOutToLeft(this Page page, float secs)
        {
            Storyboard sb = new Storyboard();

            sb.AddSlideToLeft(secs, page.WindowWidth);

            sb.AddFadeOut(secs);


            sb.Begin(page);

            page.Visibility = Visibility.Visible;

            // convert secs to milliseconds for the delay method
            await Task.Delay((int)(secs * 1000));
        }
    }
}

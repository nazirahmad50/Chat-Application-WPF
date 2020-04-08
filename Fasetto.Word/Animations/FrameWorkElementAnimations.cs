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
    /// Helpers to animate framework elements in specific ways
    /// </summary>
   public static class FrameWorkElementAnimations
    {
        /// <summary>
        /// Slide element from right
        /// </summary>
        /// <param name="element"></param>
        /// <param name="secs"></param>
        /// <param name="keppMargin">Whether to keep the element at the same width during aniamtion</param>
        /// <returns></returns>
        public static async Task SlideAndFadeInFromRightAsync(this FrameworkElement element, float secs = 0.3f, bool keepMargin = true)
        {
            Storyboard sb = new Storyboard();

            sb.AddSlideFromRight(secs, element.ActualWidth, keppMargin: keepMargin);

            sb.AddFadeIn(secs);


            sb.Begin(element);

            element.Visibility = Visibility.Visible;

            // convert secs to milliseconds for the delay method
            await Task.Delay((int)(secs * 1000));
        }

        /// <summary>
        /// Slide element from right
        /// </summary>
        /// <param name="element"></param>
        /// <param name="secs"></param>
        /// <param name="keppMargin">Whether to keep the element at the same width during aniamtion</param>
        /// <returns></returns>
        public static async Task SlideAndFadeInFromLeftAsync(this FrameworkElement element, float secs = 0.3f, bool keepMargin = true)
        {
            Storyboard sb = new Storyboard();

            sb.AddSlideFromLeft(secs, element.ActualWidth, keppMargin: keepMargin);

            sb.AddFadeIn(secs);

            // start animating
            sb.Begin(element);

            element.Visibility = Visibility.Visible;

            // convert secs to milliseconds for the delay method
            await Task.Delay((int)(secs * 1000));
        }

        /// <summary>
        /// Slide element out to the left
        /// </summary>
        /// <param name="element"></param>
        /// <param name="secs"></param>
        /// <param name="keppMargin">Whether to keep the element at the same width during aniamtion</param>
        /// <returns></returns>
        public static async Task SlideAndFadeOutToLeftAsync(this FrameworkElement element, float secs = 0.3f, bool keepMargin = true)
        {
            Storyboard sb = new Storyboard();

            sb.AddSlideToLeft(secs, element.ActualWidth, keppMargin: keepMargin);

            sb.AddFadeOut(secs);


            sb.Begin(element);

            element.Visibility = Visibility.Visible;

            // convert secs to milliseconds for the delay method
            await Task.Delay((int)(secs * 1000));
        }


        /// <summary>
        /// Slide element out to the right
        /// </summary>
        /// <param name="element"></param>
        /// <param name="secs"></param>
        /// <param name="keppMargin">Whether to keep the element at the same width during aniamtion</param>
        /// <returns></returns>
        public static async Task SlideAndFadeOutToRightAsync(this FrameworkElement element, float secs = 0.3f, bool keepMargin = true)
        {
            Storyboard sb = new Storyboard();

            sb.AddSlideToRight(secs, element.ActualWidth, keppMargin:keepMargin);

            sb.AddFadeOut(secs);


            sb.Begin(element);

            element.Visibility = Visibility.Visible;

            // convert secs to milliseconds for the delay method
            await Task.Delay((int)(secs * 1000));
        }

    }
}

using System;
using System.Windows;
using System.Windows.Media.Animation;

namespace Fasetto.Word
{
    /// <summary>
    /// Animate helpers for <see cref="Storyboard"/>
    /// </summary>
    public static class StoryBoardHelpers
    {

        /// <summary>
        /// Adds slide from right animation to storyboard
        /// </summary>
        /// <param name="storyboard">The storyboard tp add the animation to</param>
        /// <param name="secs">The time it takes</param>
        /// <param name="offset">the distance to the right to start from</param>
        /// <param name="deceleration">the rate of deceleration</param>
        /// <param name="keppMargin">Whether to keep the element at the same width during aniamtion</param>
        public static void AddSlideFromRight(this Storyboard storyboard, float secs, double offset, float deceleration = 0.9f, bool keppMargin = true)
        {
            // Create the margin animate fromn right
            ThicknessAnimation animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(secs)),
                From = new Thickness(keppMargin ? offset : 0, 0, -offset, 0),
                To = new Thickness(0),
                DecelerationRatio = deceleration
            };

            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));
            storyboard.Children.Add(animation);
        }

        /// <summary>
        /// Adds slide from left animation to storyboard
        /// </summary>
        /// <param name="storyboard">The storyboard tp add the animation to</param>
        /// <param name="secs">The time it takes</param>
        /// <param name="offset">the distance to the left to start from</param>
        /// <param name="deceleration">the rate of deceleration</param>
        /// <param name="keppMargin">Whether to keep the element at the same width during aniamtion</param>
        public static void AddSlideFromLeft(this Storyboard storyboard, float secs, double offset, float deceleration = 0.9f, bool keppMargin = true)
        {
            // Create the margin animate fromn right
            ThicknessAnimation animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(secs)),
                From = new Thickness(-offset, 0, keppMargin ? offset : 0, 0), // '-offset' is how far away it is to the left
                To = new Thickness(0),
                DecelerationRatio = deceleration
            };

            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));
            storyboard.Children.Add(animation);
        }



        /// <summary>
        /// Adds slide to left animation to storyboard
        /// </summary>
        /// <param name="storyboard">The storyboard tp add the animation to</param>
        /// <param name="secs">The time it takes</param>
        /// <param name="offset">the distance to the left to end at</param>
        /// <param name="deceleration">the rate of deceleration</param>
        /// <param name="keppMargin">Whether to keep the element at the same width during aniamtion</param>
        public static void AddSlideToLeft(this Storyboard storyboard, float secs, double offset, float deceleration = 0.9f, bool keppMargin = true)
        {
            // Create the margin animate fromn right
            ThicknessAnimation animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(secs)),
                From = new Thickness(0),
                To = new Thickness(-offset, 0, keppMargin ? offset : 0, 0),
                DecelerationRatio = deceleration
            };

            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));
            storyboard.Children.Add(animation);
        }

        /// <summary>
        /// Adds slide to right animation to storyboard
        /// </summary>
        /// <param name="storyboard">The storyboard tp add the animation to</param>
        /// <param name="secs">The time it takes</param>
        /// <param name="offset">the distance to the right to end at</param>
        /// <param name="deceleration">the rate of deceleration</param>
        /// <param name="keppMargin">Whether to keep the element at the same width during aniamtion</param>
        public static void AddSlideToRight(this Storyboard storyboard, float secs, double offset, float deceleration = 0.9f, bool keppMargin = true)
        {
            // Create the margin animate fromn right
            ThicknessAnimation animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(secs)),
                From = new Thickness(0),
                To = new Thickness(keppMargin ? offset : 0, 0, -offset, 0),
                DecelerationRatio = deceleration
            };

            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));
            storyboard.Children.Add(animation);
        }

        /// <summary>
        /// Adds the fade in animation
        /// </summary>
        /// <param name="storyboard"></param>
        /// <param name="secs"></param>
        public static void AddFadeIn(this Storyboard storyboard, float secs)
        {
            // Create the margin animate fromn right
            DoubleAnimation animation = new DoubleAnimation
            {
                // opacity from 0 to 1
                Duration = new Duration(TimeSpan.FromSeconds(secs)),
                From = 0,
                To = 1,
            };

            Storyboard.SetTargetProperty(animation, new PropertyPath("Opacity"));
            storyboard.Children.Add(animation);
        }


        /// <summary>
        /// Adds the fade out animation
        /// </summary>
        /// <param name="storyboard"></param>
        /// <param name="secs"></param>
        public static void AddFadeOut(this Storyboard storyboard, float secs)
        {
            // Create the margin animate fromn right
            DoubleAnimation animation = new DoubleAnimation
            {
             
                Duration = new Duration(TimeSpan.FromSeconds(secs)),
                From = 1,
                To = 0,
            };

            Storyboard.SetTargetProperty(animation, new PropertyPath("Opacity"));
            storyboard.Children.Add(animation);
        }



    }
}

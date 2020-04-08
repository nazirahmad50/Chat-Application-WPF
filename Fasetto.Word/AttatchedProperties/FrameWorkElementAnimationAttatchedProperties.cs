using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Fasetto.Word
{
    // All the classes in here are attacthed properties related to the FrameworkElement (WPF) UI animation

    // this class will always be of bool
    /// <summary>
    /// a base class to run any animation method when a boolean is set to true
    /// and reverse animation when set to false
    /// </summary>
    /// <typeparam name="Parent"></typeparam>
    public abstract class AnimateBaseProperty<Parent> : BaseAttatchedProperty<Parent, bool>
        where Parent : BaseAttatchedProperty<Parent, bool>, new ()
    {
        /// <summary>
        /// a flag indicating whether if this is the first time that the property has been loaded
        /// </summary>
        public bool IsFirstLoad { get; set; } = true;

        public override void OnValueUpdated(DependencyObject sender, object value)
        {
            // get the framework element
            // if sender is not a FrameworkElement
            if (!(sender is FrameworkElement element))
                return;

            // dont fire if the value doesnt change and if its not the first time its been run
            // check the original value against the passed in value
            if (sender.GetValue(ValueProperty) == value && !IsFirstLoad)
                return;

            // this will fire before the elements (UI) are laoded
            if (IsFirstLoad)
            {
                // create a single seld-unhookable event for the elements loaded event
                // basically a fire once event
                RoutedEventHandler onLoaded = null; // set it to null so we can un-hook it

                onLoaded = (s, e) =>
                {
                    // unhook ourselves
                    element.Loaded -= onLoaded;

                    // do desired animation
                    DoAnimation(element, (bool)value);

                    // no longer in first load
                    IsFirstLoad = false;
                };

                // wait for the elements to be loaded
                // Hook into the loaded event of the element (UI)
                element.Loaded += onLoaded;
            }
            else
            {  
                // do desired animation
                DoAnimation(element, (bool)value);
            }
        }

        /// <summary>
        /// The animation method that is fired when teh value changes on first load
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        protected virtual void DoAnimation(FrameworkElement element, bool value) { }
    } 

    /// <summary>
    /// Animates a framework element sliding it in from the left on show
    /// and sliding out to left on hide
    /// </summary>
    public class AnimateSlideInFromLeftProperty : AnimateBaseProperty<AnimateSlideInFromLeftProperty>
    {
        protected override async void DoAnimation(FrameworkElement element, bool value)
        {
            // animate in
            if (value)
                // if IsFirstLoad dont animate
                await element.SlideAndFadeInFromLeftAsync(IsFirstLoad ? 0 : 0.3f, keepMargin:false);
            else
                //animate out
                await element.SlideAndFadeOutToLeftAsync(IsFirstLoad ? 0 : 0.3f, keepMargin:false);
        }
    }
}

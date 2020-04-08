using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Fasetto.Word
{
    /// <summary>
    /// A base attacthed property to replace the vanilla WPF attatched property
    /// </summary>
    /// <typeparam name="Parent"> the parent class to be attatched property</typeparam>
    /// <typeparam name="Property">The type of teh attacthed property</typeparam>
    public abstract class BaseAttatchedProperty<Parent, Property> where Parent : new()
    {
        #region Public Events

        // 'DependencyObject' is the sender like PasswordBox
        // 'DependencyPropertyChangedEventArgs' which will contain the value
        /// <summary>
        /// Fired when value changes
        /// </summary>
        public event Action<DependencyObject, DependencyPropertyChangedEventArgs> ValueChanged = (s,e) => { };

        /// <summary>
        /// Fired when value changes even if its the same
        /// </summary>
        public event Action<DependencyObject, Object> ValueUpdated = (s, v) => { };

        #endregion

        #region Public Properties

        /// <summary>
        /// Singleton instance of parent class
        /// </summary>
        public static Parent Instance { get; private set; } = new Parent();

        #endregion

        #region Attatched property definitions

        // have to put 'property' after the name in order for wpf to find it
        /// <summary>
        /// Attatched property for this class
        /// </summary>
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.RegisterAttached("Value",
                typeof(Property),
                typeof(BaseAttatchedProperty<Parent, Property>),
                new UIPropertyMetadata(
                    default(Property),
                    new PropertyChangedCallback(OnValuePropertyChanged), // its only called when the property changes
                    new CoerceValueCallback(OnValuePropertyUpdated) // used to tweak the value, this will always be called reardless if the value is changed or not
               ));

        /// <summary>
        /// The callback event when the <see cref="ValueProperty"/> is changed
        /// </summary>
        /// <param name="d">The UI element that hat its property changed</param>
        /// <param name="e"></param>
        private static void OnValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            // call the parent function
            //NOTE: we couldnt use 'BaseAttatchedProperty<Parent, Property>' in the where clause due to vialoating xaml so we had to cast it
            (Instance as BaseAttatchedProperty<Parent, Property>)?.OnValueChanged(d, e);

            // call event listeners
            (Instance as BaseAttatchedProperty<Parent, Property>)?.ValueChanged(d, e);
        }

        /// <summary>
        /// The callback event when the <see cref="ValueProperty"/> is changed, even if its the same value
        /// </summary>
        /// <param name="d">The UI element that hat its property changed</param>
        /// <param name="e"></param>
        private static object OnValuePropertyUpdated(DependencyObject d, object value)
        {
            // call the parent function
            (Instance as BaseAttatchedProperty<Parent, Property>)?.OnValueUpdated(d, value);

            // call event listeners
            (Instance as BaseAttatchedProperty<Parent, Property>)?.ValueUpdated(d, value);

            // return the original value becasue were not going to change it
            return value;
        }

        /// <summary>
        /// Get the attatched property
        /// </summary>
        /// <param name="d">The element to get the property from</param>
        /// <returns></returns>
        public static Property GetValue(DependencyObject d) => (Property)d.GetValue(ValueProperty);

        /// <summary>
        /// Sets the attacthed property
        /// </summary>
        /// <param name="d"></param>
        /// <param name="value"></param>
        public static void SetValue(DependencyObject d, Property value) => d.SetValue(ValueProperty, value);
        #endregion

        #region Overrideable Methods

        /// <summary>
        /// The method that is called when any attachted property of this type is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) { }

        /// <summary>
        /// The method that is called when any attachted property of this type is changed, even if teh value is the same
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void OnValueUpdated(DependencyObject sender, object value) { }


        #endregion
    }
}

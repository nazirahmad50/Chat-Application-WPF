using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Fasetto.Word
{
    // in the where clause the parent will always be this class type
    /// <summary>
    /// A base attacthed property to replace the vanilla WPF attatched property
    /// </summary>
    /// <typeparam name="Parent"> the parent class to be attatched property</typeparam>
    /// <typeparam name="Property">The type of teh attacthed property</typeparam>
    public abstract class BaseAttatchedProperty<Parent, Property> where Parent : BaseAttatchedProperty<Parent, Property>, new()
    {
        #region Public Events

        // 'DependencyObject' is the sender like PasswordBox
        // 'DependencyPropertyChangedEventArgs' which will contain the value
        /// <summary>
        /// Fired when value changes
        /// </summary>
        public event Action<DependencyObject, DependencyPropertyChangedEventArgs> ValueChanged = (s,e) => { };

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
            DependencyProperty.RegisterAttached("Value", typeof(Property), typeof(BaseAttatchedProperty<Parent, Property>), new PropertyMetadata(new PropertyChangedCallback(OnValuePropertyChanged)));

        /// <summary>
        /// The callback event when the <see cref="ValueProperty"/> is changed
        /// </summary>
        /// <param name="d">The UI element that hat its property changed</param>
        /// <param name="e"></param>
        private static void OnValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            // call the parent function
            Instance.OnValueChanged(d, e);

            // call event listeners
            Instance.ValueChanged(d, e);
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

        #region Public Event Methods

        /// <summary>
        /// The method that is called when any attachted property of this type is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) { }

        #endregion
    }
}

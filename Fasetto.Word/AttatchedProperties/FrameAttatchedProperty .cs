using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Fasetto.Word
{
    /// <summary>
    /// The attatched property for creating a <see cref="Frame"/> that never shows navigation bar
    /// and keeps the navigation history empty
    /// </summary>
    public class IsNoFrameHistoryProperty : BaseAttatchedProperty<IsNoFrameHistoryProperty, bool>
    {

        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            Frame frame = (Frame)sender;

            // hide navigation bar
            frame.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;

            //clear history on navigate (constantly clears the navigation history)
            frame.Navigated += (s, ev) => ((Frame)s).NavigationService.RemoveBackEntry();
        }

    }
}

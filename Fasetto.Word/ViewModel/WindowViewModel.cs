using Fasetto.Word.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Fasetto.Word
{
    /// <summary>
    /// View model for the custom flat window
    /// </summary>
    public class WindowViewModel : BaseViewModel
    {
        #region Private Member
        private Window window;

        /// <summary>
        /// the margin around the window to allow for drop shadow
        /// </summary>
        private int outerMarginSize = 10;
        /// <summary>
        /// The radius of the edges of the window
        /// </summary>
        private int windowRadius = 10; // the curved edge around teh window

        /// <summary>
        /// The last known dock position
        /// </summary>
        private WindowDockPosition dockPosition = WindowDockPosition.Undocked;
        #endregion

        #region Public Properties
        /// <summary>
        /// True if the window should be borderless because it is docked or maximized
        /// </summary>
        public bool Borderless { get { return (window.WindowState == WindowState.Maximized || dockPosition != WindowDockPosition.Undocked); } }

        /// <summary>
        /// the size of the resize border around the window
        /// </summary>
        public int ResizeBorder { get { return Borderless ? 0 : 6; } }

        /// <summary>
        /// The size of the resize border around the window and taking into account the outer margin
        /// </summary>
        public Thickness ResizeBorderThickness { get { return new Thickness(ResizeBorder + outerMarginSize); } }

        /// <summary>
        /// the margin around the window to allow for drop shadow
        /// </summary>
        public int OuterMarginSize
        {
            get
            {
                return window.WindowState == WindowState.Maximized ? 0 : outerMarginSize;
            }
            set
            {
                outerMarginSize = value;
            }
        }

        public Thickness OuterMarginSizeThickness { get { return new Thickness(OuterMarginSize); } }

        /// <summary>
        /// The radius of the edges of the window
        /// </summary>
        public int WindowRadius
        {
            get
            {
                return window.WindowState == WindowState.Maximized ? 0 : windowRadius;
            }
            set
            {
                windowRadius = value;
            }
        }

        public Thickness WindowCornerRadius { get { return new Thickness(WindowRadius); } }

        /// <summary>
        /// The height of the title bar / caption of the window
        /// </summary>
        public int TitleHeight { get; set; } = 42;

        public GridLength TitleHeightGridLenght { get { return new GridLength(TitleHeight + ResizeBorder); } }

        public double WindowMinimumWidth { get; set; } = 800;
        public double WindowMinimumHeight { get; set; } = 500;

        public Thickness InnerContentPadding { get { return new Thickness(0); } }

        #endregion

        #region Commands

        /// <summary>
        /// the command for minimize the window
        /// </summary>
        public ICommand MinimizeCommand { get; set; }


        /// <summary>
        /// the command for MaximizeCommand the window
        /// </summary>
        public ICommand MaximizeCommand { get; set; }

        /// <summary>
        /// the command for Closing the window
        /// </summary>
        public ICommand CloseCommand { get; set; }

        /// <summary>
        /// the command to show the system menu of the window
        /// </summary>
        public ICommand MenuCommand { get; set; }


        #endregion

        #region Constructor
        public WindowViewModel(Window window)
        {
            this.window = window;

            //listen out for the window resizing
            window.StateChanged += (sender, e) =>
             {
                 // fire off events for all properties that are affected by resize
                 OnPropertyChanged(nameof(ResizeBorderThickness));
                 OnPropertyChanged(nameof(OuterMarginSize));
                 OnPropertyChanged(nameof(OuterMarginSizeThickness));
                 OnPropertyChanged(nameof(WindowRadius));
                 OnPropertyChanged(nameof(WindowCornerRadius));

             };

            //create commands
            MinimizeCommand = new RelayCommand(() => window.WindowState = WindowState.Minimized); // Anonymous method for the argument
            MaximizeCommand = new RelayCommand(() => window.WindowState ^= WindowState.Maximized); // '^=' is an xor gate
            CloseCommand = new RelayCommand(() => window.Close());
            MenuCommand = new RelayCommand(() => SystemCommands.ShowSystemMenu(window, GetMousePosition()));

            // Fix window resize (when maximized the window covers the bottom taskbar of windows 10)
            // there is a bug in the wpf windowStyle.None
            new WindowResizer(window);
        }
        #endregion


        public Point GetMousePosition()
        {
            var pos = Mouse.GetPosition(window);
            return new Point(pos.X + window.Left, pos.Y + window.Top);
        }
    }
}

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Connect_4_The_Game.User_Controls
{
    /// <summary>
    /// Interaction logic for ScreenMain.xaml
    /// </summary>
    public partial class ScreenMain : UserControl
    {
        #region ScreenMain Instance

        /// <summary>
        /// Creates an Instance of this window
        /// </summary>

        static ScreenMain StaticCurrentScreenMain;
        public static ScreenMain CurrentScreenMain
        {
            get
            {
                if (StaticCurrentScreenMain == null)
                {
                    StaticCurrentScreenMain = new ScreenMain();
                }
                return StaticCurrentScreenMain;
            }
        }

        #endregion

        public ScreenMain()
        {
            InitializeComponent();
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            #region UserScreen Instance

            /// <summary>
            /// Adds the UserScreen to the Grid content of the MainWindow
            /// Margin are set to the right of the MainWindow 
            /// A Name is registered to this UserScreen
            /// </summary> 

            UsersScreen usersScreen = new UsersScreen();
            MainWindow.Instance.ContainerGrid.Children.Add(usersScreen);
            usersScreen.Margin = new Thickness(1600, 0,-1600, 0);
            usersScreen.RegisterName("usersscreen", usersScreen);

            #endregion

            #region MainWidthDecreaseAnimation

            // Creates an animation for the current screen
            DoubleAnimation MainWidthDecrease = new DoubleAnimation();
            MainWidthDecrease.Duration = TimeSpan.FromSeconds(0.25);
            MainWidthDecrease.From = 1590;
            MainWidthDecrease.To = 1440;

            // Applies the animation created to the UserControl 
            Storyboard.SetTargetName(MainWidthDecrease, "screenMain");
            Storyboard.SetTargetProperty(MainWidthDecrease, new PropertyPath(WidthProperty));

            // Creates a storyboard for the current screen
            Storyboard MainWidthDecreaseStoryboard = new Storyboard();
            MainWidthDecreaseStoryboard.Children.Add(MainWidthDecrease);
            MainWidthDecreaseStoryboard.Begin(this);

            #endregion

            #region UsersWidthDecreaseAnimation

            // Creates an animation for the incoming screen
            DoubleAnimation UsersWidthDecrease = new DoubleAnimation();
            UsersWidthDecrease.Duration = TimeSpan.FromSeconds(0.25);
            UsersWidthDecrease.From = 1590;
            UsersWidthDecrease.To = 1440;

            // Applies the animation created to the UserControl 
            Storyboard.SetTargetName(UsersWidthDecrease, "usersscreen");
            Storyboard.SetTargetProperty(UsersWidthDecrease, new PropertyPath(WidthProperty));

            // Creates a storyboard for the incoming screen
            Storyboard UsersWidthDecreaseStoryboard = new Storyboard();
            UsersWidthDecreaseStoryboard.Children.Add(UsersWidthDecrease);
            UsersWidthDecreaseStoryboard.Begin(usersScreen);

            #endregion

            #region MainHeightDecreaseAnimation

            // Creates an animation for the current screen
            DoubleAnimation MainHeightDecrease = new DoubleAnimation();
            MainHeightDecrease.Duration = TimeSpan.FromSeconds(0.25);
            MainHeightDecrease.From = 855;
            MainHeightDecrease.To = 705;

            // Applies the animation created to the UserControl 
            Storyboard.SetTargetName(MainHeightDecrease, "screenMain");
            Storyboard.SetTargetProperty(MainHeightDecrease, new PropertyPath(HeightProperty));

            // Creates a storyboard for the current screen
            Storyboard MainHeightDecreaseStoryboard = new Storyboard();
            MainHeightDecreaseStoryboard.Children.Add(MainHeightDecrease);
            MainHeightDecreaseStoryboard.Begin(this);

            #endregion

            #region UsersHeightDecreaseAnimation

            // Creates an animation for the current screen
            DoubleAnimation UsersHeightDecrease = new DoubleAnimation();
            UsersHeightDecrease.Duration = TimeSpan.FromSeconds(0.25);
            UsersHeightDecrease.From = 855;
            UsersHeightDecrease.To = 705;

            // Applies the animation created to the UserControl 
            Storyboard.SetTargetName(UsersHeightDecrease, "usersscreen");
            Storyboard.SetTargetProperty(UsersHeightDecrease, new PropertyPath(HeightProperty));

            // Creates a storyboard for the current screen
            Storyboard UsersHeightDecreaseStoryboard = new Storyboard();
            UsersHeightDecreaseStoryboard.Children.Add(UsersHeightDecrease);
            UsersHeightDecreaseStoryboard.Begin(usersScreen);

            #endregion

            #region MainSlideToLeftAnimation

            // Creates an animation for the current screen
            ThicknessAnimation MainSlideToLeft = new ThicknessAnimation();
            MainSlideToLeft.Duration = TimeSpan.FromSeconds(0.5);
            MainSlideToLeft.From = screenMain.Margin;
            MainSlideToLeft.To = new Thickness(-1600, 0, 1600, 0);
            MainSlideToLeft.BeginTime = TimeSpan.FromSeconds(0.5);

            // Applies the animation created to the UserControl 
            Storyboard.SetTargetName(MainSlideToLeft, "screenMain");
            Storyboard.SetTargetProperty(MainSlideToLeft, new PropertyPath(MarginProperty));

            // Creates a storyboard for the current screen
            Storyboard MainSlideToLeftStoryboard = new Storyboard();
            MainSlideToLeftStoryboard.Children.Add(MainSlideToLeft);
            MainSlideToLeftStoryboard.Begin(this);

            #endregion

            #region UsersSlideToLeftAnimation

            // Creates an animation for the current screen
            ThicknessAnimation UsersSlideToLeft = new ThicknessAnimation();
            UsersSlideToLeft.Duration = TimeSpan.FromSeconds(0.5);
            UsersSlideToLeft.From = usersScreen.Margin;
            UsersSlideToLeft.To = new Thickness(0, 0, 0, 0);
            UsersSlideToLeft.BeginTime = TimeSpan.FromSeconds(0.5);

            // Applies the animation created to the UserControl 
            Storyboard.SetTargetName(UsersSlideToLeft, "usersscreen");
            Storyboard.SetTargetProperty(UsersSlideToLeft, new PropertyPath(MarginProperty));

            // Creates a storyboard for the current screen
            Storyboard UsersSlideToLeftStoryboard = new Storyboard();
            UsersSlideToLeftStoryboard.Children.Add(UsersSlideToLeft);
            UsersSlideToLeftStoryboard.Begin(usersScreen);

            #endregion

            #region UsersWidthIncreaseAnimation

            // Creates an animation for the current screen
            DoubleAnimation UsersWidthIncrease = new DoubleAnimation();
            UsersWidthIncrease.Duration = TimeSpan.FromSeconds(0.25);
            UsersWidthIncrease.From = 1440;
            UsersWidthIncrease.To = 1590;
            UsersWidthIncrease.BeginTime = TimeSpan.FromSeconds(1);

            // Applies the animation to the current screen
            Storyboard.SetTargetName(UsersWidthIncrease, usersScreen.Name);
            Storyboard.SetTargetProperty(UsersWidthIncrease, new PropertyPath(WidthProperty));

            // Creates a storyboard for the animation
            Storyboard UsersWidthIncreaseStoryBoard = new Storyboard();
            UsersWidthIncreaseStoryBoard.Children.Add(UsersWidthIncrease);
            UsersWidthIncreaseStoryBoard.Begin(usersScreen, HandoffBehavior.Compose);

            #endregion

            #region UsersHeightIncreaseAnimation

            // Creates an animation for the current screen
            DoubleAnimation UsersHeightIncrease = new DoubleAnimation();
            UsersHeightIncrease.Duration = TimeSpan.FromSeconds(0.25);
            UsersHeightIncrease.From = 705;
            UsersHeightIncrease.To = 855;
            UsersHeightIncrease.BeginTime = TimeSpan.FromSeconds(1);

            // Applies the animation to the current screen
            Storyboard.SetTargetName(UsersHeightIncrease, usersScreen.Name);
            Storyboard.SetTargetProperty(UsersHeightIncrease, new PropertyPath(HeightProperty));

            // Creates a storyboard for the animation
            Storyboard UsersHeightIncreaseStoryBoard = new Storyboard();
            UsersHeightIncreaseStoryBoard.Children.Add(UsersHeightIncrease);
            UsersHeightIncreaseStoryBoard.Begin(usersScreen, HandoffBehavior.Compose);

            #endregion

            #region MainWidthIncreaseAnimation

            // Creates an animation for the incoming screen
            DoubleAnimation MainWidthIncrease = new DoubleAnimation();
            MainWidthIncrease.Duration = TimeSpan.FromSeconds(0.25);
            MainWidthIncrease.From = 1440;
            MainWidthIncrease.To = 1590;
            MainWidthIncrease.BeginTime = TimeSpan.FromSeconds(1);

            // Applies the animation to the incoming screen
            Storyboard.SetTargetName(MainWidthIncrease, this.Name);
            Storyboard.SetTargetProperty(MainWidthIncrease, new PropertyPath(WidthProperty));

            // Creates a new storyboard for the incoming animation
            Storyboard MainWidthIncreaseStoryboard = new Storyboard();
            MainWidthIncreaseStoryboard.Children.Add(MainWidthIncrease);
            MainWidthIncreaseStoryboard.Begin(this, HandoffBehavior.Compose);

            #endregion

            #region MainHeightIncreaseAnimation

            // Creates an animation for the incoming screen
            DoubleAnimation MainHeightIncrease = new DoubleAnimation();
            MainHeightIncrease.Duration = TimeSpan.FromSeconds(0.25);
            MainHeightIncrease.From = 705;
            MainHeightIncrease.To = 855;
            MainHeightIncrease.BeginTime = TimeSpan.FromSeconds(1);

            // Applies the animation to the incoming screen
            Storyboard.SetTargetName(MainHeightIncrease, this.Name);
            Storyboard.SetTargetProperty(MainHeightIncrease, new PropertyPath(HeightProperty));

            // Creates a new storyboard for the incoming animation
            Storyboard MainHeightIncreaseStoryboard = new Storyboard();
            MainHeightIncreaseStoryboard.Children.Add(MainHeightIncrease);
            MainHeightIncreaseStoryboard.Begin(this, HandoffBehavior.Compose);

            #endregion

        }

        private void screenMain_Loaded(object sender, RoutedEventArgs e)
        {
            StaticCurrentScreenMain = this; 
        }

        private void screenMain_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            #region SizeChanged Event Handler

            /// <summary>
            /// Code that changes the size of the controls in the canvases in the current window when the window is resized
            /// </summary>

            foreach (FrameworkElement frameworkElement in GridMenager.Children)
            {
                //The loop iterates through each element in the MainGrid
                //A canvas is declared (to simulate the actual canvas made in the xaml file) so that it's controls can be accessed
                //A grid is declared in case some canvases are within another grid

                Grid CommonGrid;
                Canvas ReusableCanvas;

                if (frameworkElement is Grid)
                {
                    CommonGrid = (Grid)frameworkElement;

                    foreach (Canvas CommonCanvas in CommonGrid.Children)
                    {
                        //The percentage change in size is calculated and applied to the controls

                        CommonCanvas.Width = e.NewSize.Width;
                        CommonCanvas.Height = e.NewSize.Height;

                        double xChange = 1, yChange = 1;

                        if (e.PreviousSize.Width != 0)
                            xChange = (e.NewSize.Width / e.PreviousSize.Width);

                        if (e.PreviousSize.Height != 0)
                            yChange = (e.NewSize.Height / e.PreviousSize.Height);

                        foreach (FrameworkElement fe in CommonCanvas.Children)
                        {
                            /*because I didn't want to resize the grid I'm having inside the canvas in this particular instance. (doing that from xaml) */
                            if (fe is Grid == false)
                            {
                                fe.Height = fe.ActualHeight * yChange;
                                fe.Width = fe.ActualWidth * xChange;

                                Canvas.SetTop(fe, Canvas.GetTop(fe) * yChange);
                                Canvas.SetLeft(fe, Canvas.GetLeft(fe) * xChange);

                            }
                        }
                    }
                }
                // The same goes on here when 'frameworkelement' is not a Grid
                else if (frameworkElement is Canvas)
                {
                    ReusableCanvas  = (Canvas)frameworkElement;
                    ReusableCanvas.Width = e.NewSize.Width;
                    ReusableCanvas.Height = e.NewSize.Height;
                    double xChange = 1, yChange = 1;

                    if (e.PreviousSize.Width != 0)
                        xChange = (e.NewSize.Width / e.PreviousSize.Width);

                    if (e.PreviousSize.Height != 0)
                        yChange = (e.NewSize.Height / e.PreviousSize.Height);

                    foreach (FrameworkElement fe in ReusableCanvas.Children)
                    {
                        /*because I didn't want to resize the grid I'm having inside the canvas in this particular instance. (doing that from xaml) */
                        if (fe is Grid == false)
                        {
                            fe.Height = fe.ActualHeight * yChange;
                            fe.Width = fe.ActualWidth * xChange;

                            Canvas.SetTop(fe, Canvas.GetTop(fe) * yChange);
                            Canvas.SetLeft(fe, Canvas.GetLeft(fe) * xChange);

                        }
                    }
                }
            }

            #endregion
        }
    }
}

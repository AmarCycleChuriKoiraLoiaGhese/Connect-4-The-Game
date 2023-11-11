using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Connect_4_The_Game.User_Controls
{
    /// <summary>
    /// Interaction logic for UsersScreen.xaml
    /// </summary>
    public partial class UsersScreen : UserControl
    {
        #region UserScreen's Instance

        /// <summary>
        /// An Instance of this window is created
        /// </summary>

        static UsersScreen StaticCurrentUsersScreen;
        public static UsersScreen CurrentUsersScreen
        {
            get
            {
                if (StaticCurrentUsersScreen == null)
                {
                    StaticCurrentUsersScreen = new UsersScreen();
                }
                return StaticCurrentUsersScreen;
            }
        }
        #endregion

        public UsersScreen()
        {
            InitializeComponent();
        }

        private void btnBackToScreenMain_Click(object sender, RoutedEventArgs e)
        {
            #region Instance of the ScreenMain UserControl

            ScreenMain screenMain = ScreenMain.CurrentScreenMain;
            screenMain.RegisterName("Screenmain", screenMain);

            //A Name is being registered to this UserControl so that it can be referred to later on for the animations to be applied 

            #endregion

            #region MainWidthDecreaseAnimation
            // Creates an animation for the current screen
            DoubleAnimation MainWidthDecrease = new DoubleAnimation();
            MainWidthDecrease.Duration = TimeSpan.FromSeconds(0.25);
            MainWidthDecrease.From = 1590;
            MainWidthDecrease.To = 1440;

            // Applies the animation created to the UserControl 
            Storyboard.SetTargetName(MainWidthDecrease, "Screenmain");
            Storyboard.SetTargetProperty(MainWidthDecrease, new PropertyPath(WidthProperty));

            // Creates a storyboard for the current screen
            Storyboard MainWidthDecreaseStoryboard = new Storyboard();
            MainWidthDecreaseStoryboard.Children.Add(MainWidthDecrease);
            MainWidthDecreaseStoryboard.Begin(screenMain);
            #endregion

            #region UsersWidthDecreaseAnimation
            // Creates an animation for the incoming screen
            DoubleAnimation UsersWidthDecrease = new DoubleAnimation();
            UsersWidthDecrease.Duration = TimeSpan.FromSeconds(0.25);
            UsersWidthDecrease.From = 1590;
            UsersWidthDecrease.To = 1440;

            // Applies the animation created to the UserControl 
            Storyboard.SetTargetName(UsersWidthDecrease, this.Name);
            Storyboard.SetTargetProperty(UsersWidthDecrease, new PropertyPath(WidthProperty));

            // Creates a storyboard for the incoming screen
            Storyboard UsersWidthDecreaseStoryboard = new Storyboard();
            UsersWidthDecreaseStoryboard.Children.Add(UsersWidthDecrease);
            UsersWidthDecreaseStoryboard.Begin(this);
            #endregion

            #region MainHeightDecreaseAnimation
            // Creates an animation for the current screen
            DoubleAnimation MainHeightDecrease = new DoubleAnimation();
            MainHeightDecrease.Duration = TimeSpan.FromSeconds(0.25);
            MainHeightDecrease.From = 855;
            MainHeightDecrease.To = 705;

            // Applies the animation created to the UserControl 
            Storyboard.SetTargetName(MainHeightDecrease, "Screenmain");
            Storyboard.SetTargetProperty(MainHeightDecrease, new PropertyPath(HeightProperty));

            // Creates a storyboard for the current screen
            Storyboard MainHeightDecreaseStoryboard = new Storyboard();
            MainHeightDecreaseStoryboard.Children.Add(MainHeightDecrease);
            MainHeightDecreaseStoryboard.Begin(screenMain);
            #endregion

            #region UsersHeightDecreaseAnimation
            // Creates an animation for the current screen
            DoubleAnimation UsersHeightDecrease = new DoubleAnimation();
            UsersHeightDecrease.Duration = TimeSpan.FromSeconds(0.25);
            UsersHeightDecrease.From = 855;
            UsersHeightDecrease.To = 705;

            // Applies the animation created to the UserControl 
            Storyboard.SetTargetName(UsersHeightDecrease, this.Name);
            Storyboard.SetTargetProperty(UsersHeightDecrease, new PropertyPath(HeightProperty));

            // Creates a storyboard for the current screen
            Storyboard UsersHeightDecreaseStoryboard = new Storyboard();
            UsersHeightDecreaseStoryboard.Children.Add(UsersHeightDecrease);
            UsersHeightDecreaseStoryboard.Begin(this);
            #endregion

            #region Slide to the right animation for the UsersScreen
            // Creates an animation for the current screen
            ThicknessAnimation UsersRight = new ThicknessAnimation();
            UsersRight.Duration = TimeSpan.FromSeconds(0.5);
            UsersRight.From = this.Margin;
            UsersRight.To = new Thickness(1600,0,-1600,0);
            UsersRight.BeginTime = TimeSpan.FromSeconds(0.5);

            // Applies the animation created to the UserControl 
            Storyboard.SetTargetName(UsersRight, "usersScreen");
            Storyboard.SetTargetProperty(UsersRight, new PropertyPath(MarginProperty));

            // Creates a storyboard for the current screen
            Storyboard ellipseStoryboard = new Storyboard();
            ellipseStoryboard.Children.Add(UsersRight);
            ellipseStoryboard.Begin(this);
            #endregion

            #region Slide to the right for the ScreenMain
            // Creates an animation for the incoming screen
            ThicknessAnimation MainRight = new ThicknessAnimation();
            MainRight.Duration = TimeSpan.FromSeconds(0.5);
            MainRight.From = screenMain.Margin;
            MainRight.To = new Thickness(0, 0, 0, 0);
            MainRight.BeginTime = TimeSpan.FromSeconds(0.5);

            // Applies the animation created to the UserControl 
            Storyboard.SetTargetName(MainRight, "Screenmain");
            Storyboard.SetTargetProperty(MainRight, new PropertyPath(MarginProperty));

            // Creates a storyboard for the incoming screen
            Storyboard ellipseStoryboard1 = new Storyboard();
            ellipseStoryboard1.Children.Add(MainRight);
            ellipseStoryboard1.Begin(screenMain);
            #endregion

            #region UsersWidthIncreaseAnimation
            // Creates an animation for the current screen
            DoubleAnimation UsersWidthIncrease = new DoubleAnimation();
            UsersWidthIncrease.Duration = TimeSpan.FromSeconds(0.25);
            UsersWidthIncrease.From = 1440;
            UsersWidthIncrease.To = 1590;
            UsersWidthIncrease.BeginTime = TimeSpan.FromSeconds(1);

            // Applies the animation to the current screen
            Storyboard.SetTargetName(UsersWidthIncrease, this.Name);
            Storyboard.SetTargetProperty(UsersWidthIncrease, new PropertyPath(WidthProperty));

            // Creates a storyboard for the animation
            Storyboard UsersWidthIncreaseStoryBoard = new Storyboard();
            UsersWidthIncreaseStoryBoard.Children.Add(UsersWidthIncrease);
            UsersWidthIncreaseStoryBoard.Begin(this, HandoffBehavior.Compose);
            #endregion

            #region UsersHeightIncreaseAnimation
            // Creates an animation for the current screen
            DoubleAnimation UsersHeightIncrease = new DoubleAnimation();
            UsersHeightIncrease.Duration = TimeSpan.FromSeconds(0.25);
            UsersHeightIncrease.From = 705;
            UsersHeightIncrease.To = 855;
            UsersHeightIncrease.BeginTime = TimeSpan.FromSeconds(1);

            // Applies the animation to the current screen
            Storyboard.SetTargetName(UsersHeightIncrease, this.Name);
            Storyboard.SetTargetProperty(UsersHeightIncrease, new PropertyPath(HeightProperty));

            // Creates a storyboard for the animation
            Storyboard UsersHeightIncreaseStoryBoard = new Storyboard();
            UsersHeightIncreaseStoryBoard.Children.Add(UsersHeightIncrease);
            UsersHeightIncreaseStoryBoard.Begin(this, HandoffBehavior.Compose);
            #endregion

            #region MainWidthIncreaseAnimation
            // Creates an animation for the incoming screen
            DoubleAnimation MainWidthIncrease = new DoubleAnimation();
            MainWidthIncrease.Duration = TimeSpan.FromSeconds(0.25);
            MainWidthIncrease.From = 1440;
            MainWidthIncrease.To = 1590;
            MainWidthIncrease.BeginTime = TimeSpan.FromSeconds(1);

            // Applies the animation to the incoming screen
            Storyboard.SetTargetName(MainWidthIncrease, screenMain.Name);
            Storyboard.SetTargetProperty(MainWidthIncrease, new PropertyPath(WidthProperty));

            // Creates a new storyboard for the incoming animation
            Storyboard MainWidthIncreaseStoryboard = new Storyboard();
            MainWidthIncreaseStoryboard.Children.Add(MainWidthIncrease);
            MainWidthIncreaseStoryboard.Begin(screenMain, HandoffBehavior.Compose);
            #endregion

            #region MainHeightIncreaseAnimation
            // Creates an animation for the incoming screen
            DoubleAnimation MainHeightIncrease = new DoubleAnimation();
            MainHeightIncrease.Duration = TimeSpan.FromSeconds(0.25);
            MainHeightIncrease.From = 705;
            MainHeightIncrease.To = 855;
            MainHeightIncrease.BeginTime = TimeSpan.FromSeconds(1);

            // Applies the animation to the incoming screen
            Storyboard.SetTargetName(MainHeightIncrease, screenMain.Name);
            Storyboard.SetTargetProperty(MainHeightIncrease, new PropertyPath(HeightProperty));

            // Creates a new storyboard for the incoming animation
            Storyboard MainHeightIncreaseStoryboard = new Storyboard();
            MainHeightIncreaseStoryboard.Children.Add(MainHeightIncrease);
            MainHeightIncreaseStoryboard.Begin(screenMain, HandoffBehavior.Compose);
            #endregion

        }

        private void usersScreen_Loaded(object sender, RoutedEventArgs e)
        {
            StaticCurrentUsersScreen = this;
        }

        private void btnContinue_Click(object sender, RoutedEventArgs e)
        {

            /// <summary>
            /// A logic operations occurs to verify whether the user inputs the same name in both textboxes or just puts nothing
            /// Once the names are succesfully input, the sliding animation occurs
            /// A Message is shown to the user if the names input don't respect the requirements
            /// </summary>

            if (txtP1.Text != txtP2.Text && txtP1.Text.Length < 15 && txtP2.Text.Length < 15 && txtP1.Text != "" && txtP2.Text != "")
            {
                #region UsersWidthDecreaseAnimation
                // Creates an animation for the incoming screen
                DoubleAnimation UsersWidthDecrease = new DoubleAnimation();
                UsersWidthDecrease.Duration = TimeSpan.FromSeconds(0.25);
                UsersWidthDecrease.From = 1590;
                UsersWidthDecrease.To = 1440;

                // Applies the animation created to the UserControl 
                Storyboard.SetTargetName(UsersWidthDecrease, this.Name);
                Storyboard.SetTargetProperty(UsersWidthDecrease, new PropertyPath(WidthProperty));

                // Creates a storyboard for the incoming screen
                Storyboard UsersWidthDecreaseStoryboard = new Storyboard();
                UsersWidthDecreaseStoryboard.Children.Add(UsersWidthDecrease);
                UsersWidthDecreaseStoryboard.Begin(this);
                #endregion

                #region UsersHeightDecreaseAnimation
                // Creates an animation for the current screen
                DoubleAnimation UsersHeightDecrease = new DoubleAnimation();
                UsersHeightDecrease.Duration = TimeSpan.FromSeconds(0.25);
                UsersHeightDecrease.From = 855;
                UsersHeightDecrease.To = 705;

                // Applies the animation created to the UserControl 
                Storyboard.SetTargetName(UsersHeightDecrease, this.Name);
                Storyboard.SetTargetProperty(UsersHeightDecrease, new PropertyPath(HeightProperty));

                // Creates a storyboard for the current screen
                Storyboard UsersHeightDecreaseStoryboard = new Storyboard();
                UsersHeightDecreaseStoryboard.Children.Add(UsersHeightDecrease);
                UsersHeightDecreaseStoryboard.Begin(this);
                #endregion

                #region Slide to the left animation for the UsersScreen
                // Creates an animation for the current screen
                ThicknessAnimation UsersRight = new ThicknessAnimation();
                UsersRight.Duration = TimeSpan.FromSeconds(0.5);
                UsersRight.From = this.Margin;
                UsersRight.To = new Thickness(-1600, 0, 1600, 0);
                UsersRight.BeginTime = TimeSpan.FromSeconds(0.5);

                // Applies the animation created to the UserControl 
                Storyboard.SetTargetName(UsersRight, "usersScreen");
                Storyboard.SetTargetProperty(UsersRight, new PropertyPath(MarginProperty));

                // Creates a storyboard for the current screen
                Storyboard ellipseStoryboard = new Storyboard();
                ellipseStoryboard.Children.Add(UsersRight);
                ellipseStoryboard.Begin(this);
                #endregion

                #region UsersWidthIncreaseAnimation
                // Creates an animation for the current screen
                DoubleAnimation UsersWidthIncrease = new DoubleAnimation();
                UsersWidthIncrease.Duration = TimeSpan.FromSeconds(0.25);
                UsersWidthIncrease.From = 1440;
                UsersWidthIncrease.To = 1590;
                UsersWidthIncrease.BeginTime = TimeSpan.FromSeconds(1);

                // Applies the animation to the current screen
                Storyboard.SetTargetName(UsersWidthIncrease, this.Name);
                Storyboard.SetTargetProperty(UsersWidthIncrease, new PropertyPath(WidthProperty));

                // Creates a storyboard for the animation
                Storyboard UsersWidthIncreaseStoryBoard = new Storyboard();
                UsersWidthIncreaseStoryBoard.Children.Add(UsersWidthIncrease);
                UsersWidthIncreaseStoryBoard.Begin(this, HandoffBehavior.Compose);
                #endregion

                #region UsersHeightIncreaseAnimation
                // Creates an animation for the current screen
                DoubleAnimation UsersHeightIncrease = new DoubleAnimation();
                UsersHeightIncrease.Duration = TimeSpan.FromSeconds(0.25);
                UsersHeightIncrease.From = 705;
                UsersHeightIncrease.To = 855;
                UsersHeightIncrease.BeginTime = TimeSpan.FromSeconds(1);

                // Applies the animation to the current screen
                Storyboard.SetTargetName(UsersHeightIncrease, this.Name);
                Storyboard.SetTargetProperty(UsersHeightIncrease, new PropertyPath(HeightProperty));

                // Creates a storyboard for the animation
                Storyboard UsersHeightIncreaseStoryBoard = new Storyboard();
                UsersHeightIncreaseStoryBoard.Children.Add(UsersHeightIncrease);
                UsersHeightIncreaseStoryBoard.Begin(this, HandoffBehavior.Compose);
                #endregion

                #region GameGrid Istance
                GameGrid gameGrid = new GameGrid();
                MainWindow.Instance.ContainerGrid.Children.Add(gameGrid);
                gameGrid.Margin = new Thickness(1600, 0, -1600, 0);
                gameGrid.RegisterName("gameGrid", gameGrid);
                #endregion

                #region GameGridWidthDecreaseAnimation
                // Creates an animation for the incoming screen
                DoubleAnimation GameGridWidthDecrease = new DoubleAnimation();
                GameGridWidthDecrease.Duration = TimeSpan.FromSeconds(0.25);
                GameGridWidthDecrease.From = 1590;
                GameGridWidthDecrease.To = 1440;

                // Applies the animation created to the UserControl 
                Storyboard.SetTargetName(GameGridWidthDecrease, "gameGrid");
                Storyboard.SetTargetProperty(GameGridWidthDecrease, new PropertyPath(WidthProperty));

                // Creates a storyboard for the incoming screen
                Storyboard GameGridWidthDecreaseStoryboard = new Storyboard();
                GameGridWidthDecreaseStoryboard.Children.Add(GameGridWidthDecrease);
                GameGridWidthDecreaseStoryboard.Begin(gameGrid);
                #endregion

                #region GameGridHeightDecreaseAnimation
                // Creates an animation for the current screen
                DoubleAnimation GameGridHeightDecrease = new DoubleAnimation();
                GameGridHeightDecrease.Duration = TimeSpan.FromSeconds(0.25);
                GameGridHeightDecrease.From = 855;
                GameGridHeightDecrease.To = 705;

                // Applies the animation created to the UserControl 
                Storyboard.SetTargetName(GameGridHeightDecrease, "gameGrid");
                Storyboard.SetTargetProperty(GameGridHeightDecrease, new PropertyPath(HeightProperty));

                // Creates a storyboard for the current screen
                Storyboard GameGridHeightDecreaseStoryboard = new Storyboard();
                GameGridHeightDecreaseStoryboard.Children.Add(GameGridHeightDecrease);
                GameGridHeightDecreaseStoryboard.Begin(gameGrid);
                #endregion

                #region Slide to the left animation for the GameGrid
                // Creates an animation for the current screen
                ThicknessAnimation GameGridRight = new ThicknessAnimation();
                GameGridRight.Duration = TimeSpan.FromSeconds(0.5);
                GameGridRight.From = gameGrid.Margin;
                GameGridRight.To = new Thickness(0, 0, 0, 0);
                GameGridRight.BeginTime = TimeSpan.FromSeconds(0.5);

                // Applies the animation created to the UserControl 
                Storyboard.SetTargetName(GameGridRight, "gameGrid");
                Storyboard.SetTargetProperty(GameGridRight, new PropertyPath(MarginProperty));

                // Creates a storyboard for the current screen
                Storyboard ellipseStoryboard1 = new Storyboard();
                ellipseStoryboard1.Children.Add(GameGridRight);
                ellipseStoryboard1.Begin(gameGrid);
                #endregion

                #region GameGridWidthIncreaseAnimation
                // Creates an animation for the current screen
                DoubleAnimation GameGridWidthIncrease = new DoubleAnimation();
                GameGridWidthIncrease.Duration = TimeSpan.FromSeconds(0.25);
                GameGridWidthIncrease.From = 1440;
                GameGridWidthIncrease.To = 1590;
                GameGridWidthIncrease.BeginTime = TimeSpan.FromSeconds(1);

                // Applies the animation to the current screen
                Storyboard.SetTargetName(GameGridWidthIncrease, "gameGrid");
                Storyboard.SetTargetProperty(GameGridWidthIncrease, new PropertyPath(WidthProperty));

                // Creates a storyboard for the animation
                Storyboard GameGridWidthIncreaseStoryBoard = new Storyboard();
                GameGridWidthIncreaseStoryBoard.Children.Add(GameGridWidthIncrease);
                GameGridWidthIncreaseStoryBoard.Begin(gameGrid, HandoffBehavior.Compose);
                #endregion

                #region GameGridHeightIncreaseAnimation
                // Creates an animation for the current screen
                DoubleAnimation GameGridHeightIncrease = new DoubleAnimation();
                GameGridHeightIncrease.Duration = TimeSpan.FromSeconds(0.25);
                GameGridHeightIncrease.From = 705;
                GameGridHeightIncrease.To = 855;
                GameGridHeightIncrease.BeginTime = TimeSpan.FromSeconds(1);

                // Applies the animation to the current screen
                Storyboard.SetTargetName(GameGridHeightIncrease, "gameGrid");
                Storyboard.SetTargetProperty(GameGridHeightIncrease, new PropertyPath(HeightProperty));

                // Creates a storyboard for the animation
                Storyboard GameGridHeightIncreaseStoryBoard = new Storyboard();
                GameGridHeightIncreaseStoryBoard.Children.Add(GameGridHeightIncrease);
                GameGridHeightIncreaseStoryBoard.Begin(gameGrid, HandoffBehavior.Compose);
                #endregion
            }
            else
            {
                MessageBox.Show("- Use different names" + "- Names must be less than 14 characters" + "- Do not put black spaces as your name");
            }
        }

        private void usersScreen_SizeChanged(object sender, SizeChangedEventArgs e)
        {

            /// <summary>
            /// Same code that resizes controls when the window is resized
            /// </summary>

            foreach (FrameworkElement frameworkElement in GridManager.Children)
            {
                Grid CommonGrid;
                Canvas ReusableCanvas;
                if (frameworkElement is Grid)
                {
                    CommonGrid = (Grid)frameworkElement;
                    foreach (Canvas CommonCanvas in CommonGrid.Children)
                    {
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
                else if (frameworkElement is Canvas)
                {
                    ReusableCanvas = (Canvas)frameworkElement;
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
        }
    }
}

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Shapes;

namespace Connect_4_The_Game.User_Controls
{
    /// <summary>
    /// Interaction logic for GameGrid.xaml
    /// </summary>
    public partial class GameGrid : UserControl
    {
        #region Global Variables

        /// <summary>
        /// PlayerTurn is a boolean which tells who's turn is
        /// The ArrayGrid is the main grid the contains the values input whenever a 'coin' is dropped
        /// </summary>

        bool PlayerTurn;
        static int[,] ArrayGrid = new int[6, 7];

        #endregion

        #region Instance of GameGrid

        /// <summary>
        /// Created an Instance of this window
        /// </summary>

        static GameGrid StaticCurrentGameGrid;
        public static GameGrid CurrentGameGrid
        {
            get
            {
                if (StaticCurrentGameGrid == null)
                {
                    StaticCurrentGameGrid = new GameGrid();
                }
                return StaticCurrentGameGrid;
            }
        }

        #endregion

        public GameGrid()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            #region First Turn

            /// <summary>
            /// Code that lets the first turn to be chosen at random
            /// </summary>

            Random random = new Random();
            PlayerTurn = Convert.ToBoolean(random.Next(0, 2));

            #endregion

            #region Lighters 

            /// <summary>
            /// At the start of the game when the first turn is chosen by the program
            /// The lighters are set in order to help the user to understand whose turn it is
            /// </summary>

            switch (PlayerTurn)
            {
                case true:
                    LighterP1.Visibility = Visibility.Visible;
                    break;
                case false:
                    LighterP2.Visibility = Visibility.Visible;
                    break;
            }

            #endregion

            #region Filling the ArrayGrid 

            /// <summary>
            /// The ArrayGrid is filled with zeroes
            /// So that the array does not throw null errors (Example: 'ArrayGrid[5,4] = null')
            /// </summary>

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    ArrayGrid[i, j] = 0;
                }
            }

            #endregion

            StaticCurrentGameGrid = this;

            txtP1Label.Text = UsersScreen.CurrentUsersScreen.txtP1.Text;
            txtP2Label.Text = UsersScreen.CurrentUsersScreen.txtP2.Text;

            //The Names chosen in the previous UserControl are being set on the TextBlocks in this UserControl
        }

        private void Columns_MouseEnter(object sender, MouseEventArgs e)
        {
            #region Creation of the Triangle Indicator

            /// <summary>
            /// An Animated Triangle Indicator is created 
            /// To Show the user where a 'coin' will be dropped 
            /// when anywhere on the centre grids is clicked
            /// </summary>

            #region Triangles's Position

            /// <summary>
            /// The Trinagle figure is created and given a position in the upper canvases
            /// The Point are used to define the LineSegments' positions 
            /// (LineSegments are basically the 'sides' of the triangle)
            /// The LineSegments are collected and applied to the PathGeometry (The Triangle)
            /// Meanwhile a NameScopes are set for the two LineSegments
            /// To let them being accessed by the animations later on
            /// </summary>

            Point FirstPoint = new Point(121, 10);
            Point SecondPoint = new Point(70, 70);
            Point StartingPoint = new Point(20, 10);

            LineSegment Line1 = new LineSegment(FirstPoint, false);
            LineSegment Line2 = new LineSegment(SecondPoint, false);

            NameScope.SetNameScope(Line1, new NameScope());
            NameScope.SetNameScope(Line2, new NameScope());

            PathSegmentCollection pathSegments = new PathSegmentCollection();
            pathSegments.Add(Line1);
            pathSegments.Add(Line2);

            PathFigure ActualFigure = new PathFigure(StartingPoint, pathSegments, true);
            ActualFigure.StartPoint = StartingPoint;

            NameScope.SetNameScope(ActualFigure, new NameScope());

            PathFigureCollection pathFigures = new PathFigureCollection();
            pathFigures.Add(ActualFigure);

            PathGeometry pathGeometry = new PathGeometry();
            pathGeometry.Figures = pathFigures;

            #endregion

            #region Triangle's Effect

            /// <summary>
            /// A DropShadowEffect is declared and defined to give the neon effect to the Triangle
            /// </summary>

            DropShadowEffect NeonEffect = new DropShadowEffect();
            NeonEffect.ShadowDepth = 0;
            NeonEffect.BlurRadius = 30;
            NeonEffect.Color = Color.FromRgb(0, 255, 255);

            #endregion

            #region Triangle's Design

            /// <summary>
            /// A Path is declared to container The PathGeometry 
            /// (Yeah, it is a bit confusing to have so many things containing each other)
            /// A NameScope for the Triangle is set so that a name can be registered to it
            /// The Triangle is defined
            /// Names are being registered
            /// </summary>

            Path IndicatorTriangle = new Path();
            IndicatorTriangle.Data = pathGeometry;
            NameScope.SetNameScope(IndicatorTriangle, new NameScope());
            IndicatorTriangle.Fill = Brushes.Aqua;
            IndicatorTriangle.Effect = NeonEffect;
            IndicatorTriangle.Width = 141;
            IndicatorTriangle.Height = 80;

            IndicatorTriangle.RegisterName("Line1", Line1);
            IndicatorTriangle.RegisterName("Line2", Line2);
            IndicatorTriangle.RegisterName("StartingPoint", ActualFigure);

            #endregion

            #region Triangle's Animations

            /// <summary>
            /// Different PoinAnimations are being declared:
            /// All three animations contribute to form an overall stretch in size of the TriangleIndicator
            /// All the properties of each Animations are set 
            /// Each Animation is being assigned to an object by referring to the names registered previously
            /// A storyboard is declared to container and 'begin' all of these animations
            /// </summary>

            PointAnimation TranslationToTheRight = new PointAnimation();
            TranslationToTheRight.From = FirstPoint;
            TranslationToTheRight.To = new Point(131, 5);
            TranslationToTheRight.Duration = TimeSpan.FromSeconds(1);
            TranslationToTheRight.AutoReverse = true;
            TranslationToTheRight.RepeatBehavior = RepeatBehavior.Forever;

            PointAnimation TranslationToTheLeft = new PointAnimation();
            TranslationToTheLeft.From = StartingPoint;
            TranslationToTheLeft.To = new Point(10, 5);
            TranslationToTheLeft.Duration = TimeSpan.FromSeconds(1);
            TranslationToTheLeft.AutoReverse = true;
            TranslationToTheLeft.RepeatBehavior = RepeatBehavior.Forever;

            PointAnimation DownwardTranslation = new PointAnimation();
            DownwardTranslation.From = SecondPoint;
            DownwardTranslation.To = new Point(70, 75);
            DownwardTranslation.Duration = TimeSpan.FromSeconds(1);
            DownwardTranslation.AutoReverse = true;
            DownwardTranslation.RepeatBehavior = RepeatBehavior.Forever;

            Storyboard.SetTargetName(TranslationToTheRight, "Line1");
            Storyboard.SetTargetProperty(TranslationToTheRight, new PropertyPath(LineSegment.PointProperty));

            Storyboard.SetTargetName(TranslationToTheLeft, "Line2");
            Storyboard.SetTargetProperty(TranslationToTheLeft, new PropertyPath(LineSegment.PointProperty));

            Storyboard.SetTargetName(DownwardTranslation, "StartingPoint");
            Storyboard.SetTargetProperty(DownwardTranslation, new PropertyPath(PathFigure.StartPointProperty));

            Storyboard AnimationContainer = new Storyboard();
            AnimationContainer.Children.Add(TranslationToTheRight);
            AnimationContainer.Children.Add(TranslationToTheLeft);
            AnimationContainer.Children.Add(DownwardTranslation);
            AnimationContainer.Begin(IndicatorTriangle);

            #endregion

            #endregion

            #region Mouse Hover Effect

            /// <summary>
            /// Canvas is declared to represent the canvas that has triggered this event handler
            /// The column index of the canvas(sender) is being retrieved
            /// The Triangle is added at the top in the respective columns
            /// </summary>

            Canvas canvas = (Canvas)sender;

            if (ColumnSelecterGrid.Children.Contains(canvas))
            {
                switch (Grid.GetColumn(canvas))
                {
                    case 0:
                        ColumnSelector0.Children.Add(IndicatorTriangle);
                        break;
                    case 1:
                        ColumnSelector1.Children.Add(IndicatorTriangle);
                        break;
                    case 2:
                        ColumnSelector2.Children.Add(IndicatorTriangle);
                        break;
                    case 3:
                        ColumnSelector3.Children.Add(IndicatorTriangle);
                        break;
                    case 4:
                        ColumnSelector4.Children.Add(IndicatorTriangle);
                        break;
                    case 5:
                        ColumnSelector5.Children.Add(IndicatorTriangle);
                        break;
                    case 6:
                        ColumnSelector6.Children.Add(IndicatorTriangle);
                        break;
                }
            }
            else
            {
                switch (Grid.GetColumn(canvas))
                {
                    case 1:
                        ColumnSelector0.Children.Add(IndicatorTriangle);
                        break;
                    case 2:
                        ColumnSelector1.Children.Add(IndicatorTriangle);
                        break;
                    case 3:
                        ColumnSelector2.Children.Add(IndicatorTriangle);
                        break;
                    case 4:
                        ColumnSelector3.Children.Add(IndicatorTriangle);
                        break;
                    case 5:
                        ColumnSelector4.Children.Add(IndicatorTriangle);
                        break;
                    case 6:
                        ColumnSelector5.Children.Add(IndicatorTriangle);
                        break;
                    case 7:
                        ColumnSelector6.Children.Add(IndicatorTriangle);
                        break;
                }
            }

            #endregion
        }

        private void Columns_MouseLeave(object sender, MouseEventArgs e)
        {
            #region Mouse Hover Effect Removal

            /// <summary>
            /// The exact same code is being used
            /// The main differences are that the canvases are cleared instead of being 'temporarily filled'
            /// </summary>

            Canvas canvas = (Canvas)sender;

            if (ColumnSelecterGrid.Children.Contains(canvas))
            {
                switch (Grid.GetColumn(canvas))
                {
                    case 0:
                        ColumnSelector0.Children.Clear();
                        break;
                    case 1:
                        ColumnSelector1.Children.Clear();
                        break;
                    case 2:
                        ColumnSelector2.Children.Clear();
                        break;
                    case 3:
                        ColumnSelector3.Children.Clear();
                        break;
                    case 4:
                        ColumnSelector4.Children.Clear();
                        break;
                    case 5:
                        ColumnSelector5.Children.Clear();
                        break;
                    case 6:
                        ColumnSelector6.Children.Clear();
                        break;
                }
            }
            else
            {
                switch (Grid.GetColumn(canvas))
                {
                    case 1:
                        ColumnSelector0.Children.Clear();
                        break;
                    case 2:
                        ColumnSelector1.Children.Clear();
                        break;
                    case 3:
                        ColumnSelector2.Children.Clear();
                        break;
                    case 4:
                        ColumnSelector3.Children.Clear();
                        break;
                    case 5:
                        ColumnSelector4.Children.Clear();
                        break;
                    case 6:
                        ColumnSelector5.Children.Clear();
                        break;
                    case 7:
                        ColumnSelector6.Children.Clear();
                        break;
                }
            }

            #endregion
        }

        #region Artificial Rectangles

        /// <summary>
        /// As I am creating many RectangleGeometries with the same properties
        /// I have made this little subroutine to automatically make Rectangles by just calling the subroutine
        /// This saves me time by not coding many rectangles each times
        /// </summary>
        /// 
        /// <returns>
        /// It returns a Rectangle Geometry
        /// </returns>

        private RectangleGeometry RectangleMaker()
        {
            RectangleGeometry AnimatedRectangle = new RectangleGeometry
            {
                Rect = new Rect(60, 45, 20, 20),
                RadiusX = 10,
                RadiusY = 10
            };

            return AnimatedRectangle;
        }

        #endregion

        private void ArrayGridHandler(int Column, bool PlayerTurn)
        {
            #region Variables

            /// <summary>
            /// This region is entirely made up for all the varibles I declared in this Sub
            /// This allows me to tweak the variables or to just have a look on them without wasting time by trying to find where they are
            /// As they might be declared throught the whole sub in different parts
            /// </summary>

            int Counter = 5;
            int[,] GridChecker = new int[4, 4];
            int SecondCounter = 0, Sum, Sum1, Sum2 = 0, Sum3 = 0, Iterator = 0, SecondIterator, ThirdIterator = 0;

            Podium podium;

            #endregion

            #region Assignment of values onto the ArrayGrid

            /// <summary>
            /// The ArrayGrid is filled with zeroes so in this moment,
            /// The ArraGrid is completely free and stores no value (other than zeroes)
            /// The Idea is that the zeroes represent the 'free space' (with free space I mean whether a coin is currently occupying a space or not)
            /// The following while loop is used to loop until it finds a free space (so a zero)
            /// If it finds a free space, the Counter is stopped and its value copied onto another counter (SecondCounter),
            /// While the previous counter is set to 1 to end the While loop 'earlier'
            /// </summary>

            while (Counter != 0)
            {
                switch (ArrayGrid[Counter, Column])
                {
                    case 0:
                        SecondCounter = Counter;
                        Counter = 1;
                        break;
                }
                Counter -= 1;
            }

            /// <summary>
            /// The following switch statement allows to store a 10 or a 1 based on the bool PlayerTurn's value
            /// Onto the ArrayGrid
            /// </summary>

            switch (PlayerTurn)
            {
                case true:
                    ArrayGrid[SecondCounter, Column] = 10;
                    break;
                case false:
                    ArrayGrid[SecondCounter, Column] = 1;
                    break;
            }

            #endregion

            #region Epic Loop

            /// <summary>
            /// The following big chunk of code is the best and most complex 'gigantic' loop I ever made.
            /// It is purely an alternative to the tedious hard coding.
            /// It's purpose is to check whether a Player has scored 4 in either a row, column or well...an oblique...row? 
            /// As it is a very complex piece of code, I have divided it into 3-4 main sections/steps to help explain it best
            /// </summary>

            // Step 5: Concept of looping vertically

            /// <summary>
            /// Once a whole single 'horizontal' loop (meaning that the GridCheker has checked and loop through all the data from left to right into chuncks of 4X4)
            /// It should loop vertically, meaning that the row index (ThirdIterator) is increase by 1, so the GridChecker 'goes down' by 1 row.
            /// At this stage, the GridChecker copies and checks data 'horizontally' again, until the horizontal loop ends again and ThirdIterator is increased by 1 row again.
            /// This Continues until the whole ArraGrid has been checked from left to right, from top to bottom.
            /// </summary>

            ThirdIterator = 0;
            while (ThirdIterator != 3)
            {

                // Step 4: Concept of looping horizontally

                /// <summary>
                /// Once the GridChecker checks the first 'portion' of the the ArrayGrid data it should go towards the next set of data
                /// Columns Index are increased by 1 each time the GridChecker has finished checking its current portion of data that is holding
                /// This continues until the ArrayGrid's data is finished (at least horizontally, this means there is no way go more 'to the right' as there is the end of the ArrayGrid)
                /// This while loops allows this to happen, to loop 'horizontally' through the ArrayGrid
                /// SecondIterator is initially set to 0 to allow it be reused each time a vertical loop has been completed
                /// </summary>

                SecondIterator = 0;
                while (SecondIterator != 4)
                {

                    // Step 6: Transfering data from the ArrayGrid to the GridChecker

                    /// <summary>
                    /// This is the most complex part of the whole code.
                    /// This is where the SecondIterator and ThirdIterator are actually being used to iterate horizontally and vertically.
                    /// In the first for loop you can see j initilized and being qual to SecondIterator. Also the condition (j < 4 + SecondIterator) is different from usual.
                    /// As the both ThirdIterator and SecondIterator start at 0, GridChecker starts looping from the top-left corner of the ArrayGrid.
                    /// As the GridChecker's copied data is being checked, it goes forward (towards the right).
                    /// Each time the GridChecker finishes to check all its data, SecondIterator is increased by 1.
                    /// This means that the next loop (to copy the ArrayGrid's data) will start at 1 column after the the first in the previous loop. 
                    /// The condition in the for loop is also affected by this as it will stop looping at 1 column after the last in the previous loop.
                    /// The same happens with the ThirdIterator but vertically.
                    /// As we don't want 'Index out of range' erros coming out from the GridChecker, ThirdIterator and SecondIterator are subtracted from i and j.
                    /// </summary>

                    for (int i = 0 + ThirdIterator; i < 4 + ThirdIterator; i++)
                    {
                        for (int j = 0 + SecondIterator; j < 4 + SecondIterator; j++)
                        {
                            GridChecker[i - ThirdIterator, j - SecondIterator] = ArrayGrid[i, j];
                        }
                    }

                    // Step 1: Looping through GridChecker

                    /// <summary>
                    /// GridChecker is a 4X4 array that stores a 'portion' of the ArrayGrid
                    /// This Allows me  to facilitate my 'checks'
                    /// The GridChecker, once filled with the ArrayGrid data, is then loop through
                    /// Sum, Sum1, Sum2, Sum3 are the varibles that store the sums of the 'coins'
                    /// Sum2 and Sum3 are 'filled', they store all the GridChecker's data DIAGONALLY)
                    /// </summary>

                    for (int i = 0; i < 4; i++)
                    {
                        Sum2 += GridChecker[i, i];
                        Sum3 += GridChecker[3 - i, i];
                    }

                    // Step 2: Logic Operations

                    /// <summary>
                    /// Simple Logic operations are being used to check whether the sums are 40 or 4
                    /// In case a 40 has been scored the player's name, at which 10s are attribuited to, is sent to Podium 
                    /// Podium is the name of the Windows that displays the winner
                    /// Same happens if a 4 has been scored, just a different player's name is sent
                    /// </summary>

                    if (Sum2 == 40 || Sum3 == 40)
                    {
                        podium = new Podium(txtP1Label.Text);
                        MainWindow.Instance.ContainerGriddo.Children.Add(podium);
                    }
                    else if (Sum2 == 4 || Sum3 == 4)
                    {
                        podium = new Podium(txtP2Label.Text);
                        MainWindow.Instance.ContainerGriddo.Children.Add(podium);
                    }
                    else
                    {

                        // Step 3: Further Loops and Checks

                        /// <summary>
                        /// Sum2 and Sum3 are reset to 0 (to make sure they start at 0 when they are used to hold the sum of new data)
                        /// Iterator is also set to 0 (this allows the variables to be reused once the while loop ends)
                        /// As there are many while loops within other loops
                        /// </summary>

                        Sum2 = 0;
                        Sum3 = 0;

                        Iterator = 0;

                        while (Iterator != 4)
                        {
                            Sum = 0;
                            Sum1 = 0;

                            /// <summary>
                            /// In here, the GridChecker is being looped though in a different, but still similar way
                            /// There are 4 rows in 4X4 array, which means 4 different places to score 4 coins in a row (same applies to columns)
                            /// Sum stores the sum of the columns, using Iterator as columns index and i as the row index
                            /// Sum1 stores the sum of the rows, using Iterator as row index and i as the columns index
                            /// </summary>

                            for (int i = 0; i < 4; i++)
                            {
                                Sum += GridChecker[i, Iterator];
                                Sum1 += GridChecker[Iterator, i];
                            }

                            /// <summary>
                            /// Further logic operations
                            /// </summary>

                            if (Sum == 40 || Sum1 == 40)
                            {
                                podium = new Podium(txtP1Label.Text);
                                MainWindow.Instance.ContainerGriddo.Children.Add(podium);
                            }
                            else if (Sum == 4 || Sum1 == 4)
                            {
                                podium = new Podium(txtP2Label.Text);
                                MainWindow.Instance.ContainerGriddo.Children.Add(podium);
                            }
                            Iterator++;
                        }
                    }
                    SecondIterator++;
                }
                ThirdIterator ++;
            }

            #endregion
        }

        private int PointDecider(int Column, int Case)
        {
            #region Variables

            int Counter = 5;
            int SecondCounter = 0;

            #endregion

            #region Looking for zeroes

            /// <summary>
            /// Here is there same code you've seen before.
            /// It checks for zeroes.
            /// </summary>

            while (Counter != 0)
            {
                switch (ArrayGrid[Counter, Column])
                {
                    case 0:
                        SecondCounter = Counter;
                        Counter = 1;
                        break;
                }
                Counter -= 1;
            }

            #endregion

            #region PointMenager

            /// <summary>
            /// The point of this is to return a an integer value that tells you where in the Grid the animation should stop according to the free space (zeroes)
            /// Case is used to represent which one of the 3 cases the animation is at:
            /// - Starting Point
            /// - Downwards slide
            /// - Transformation from coin to rectangle
            /// </summary>

            switch (Case)
            {

                /// <summary>
                /// In the first case you want returned the point at which the base of the coin should stop at (so where there is free space or zeroes) 
                /// </summary>

                case 0:
                    switch (SecondCounter)
                    {
                        case 5:
                            return 560;
                        case 4:
                            return 450;
                        case 3:
                            return 340;
                        case 2:
                            return 220;
                        case 1:
                            return 120;
                        case 0:
                            return 20;
                        default:
                            return 0;
                    }

                /// <summary>
                /// In the second case you want returned the point at which the 'roof' of the coin should stop at
                /// </summary>

                case 1:
                    switch (SecondCounter)
                    {
                        case 5:
                            return 595;
                        case 4:
                            return 485;
                        case 3:
                            return 375;
                        case 2:
                            return 265;
                        case 1:
                            return 155;
                        case 0:
                            return 45;
                        default:
                            return 0;
                    }
                case 2:

                /// <summary>
                /// In the third case, you want returned the value of the top margin for the rectangle to form (space between border and top of the rectangle)
                /// </summary>

                    switch (SecondCounter)
                    {
                        case 5:
                            return 570;
                        case 4:
                            return 460;
                        case 3:
                            return 350;
                        case 2:
                            return 240;
                        case 1:
                            return 130;
                        case 0:
                            return 20;
                        default:
                            return 0;
                    }
                default:
                    return 0;
            }

            #endregion

        }

        private void Animator(int GridColumn)
        {
            
            #region Declaration of variables

            /// <summary>
            /// All the variables need to animate the coins are declared here.
            /// A NameScope is set to the Rectangle and a name given to it.
            /// This allows the coin to be animated
            /// </summary>

            RectKeyFrameCollection KeyFramesCollector;
            RectAnimationUsingKeyFrames ElevatorAnimation;
            Storyboard AnimationContainer;
            Path ContainerPath;

            RectangleGeometry AnimatedRectangle = RectangleMaker();
            NameScope.SetNameScope(AnimatedRectangle, new NameScope());
            this.RegisterName("AnimatedRectangle", AnimatedRectangle);

            #endregion

            #region Design of the rectangle

            /// <summary>
            /// A path is initialized and all of its properties defined.
            /// Based on PlayerTurn's value, a colour is assigned to the coin.
            /// The coins are then added to one of the canvases based on the column selected.
            /// </summary>

            ContainerPath = new Path
            {
                Width = 141,
                Height = 660,
                Data = AnimatedRectangle
            };

            switch (PlayerTurn)
            {
                case true:
                    ContainerPath.Fill = txtP1Label.Foreground;
                    break;
                case false:
                    ContainerPath.Fill = txtP2Label.Foreground;
                    break;
            }

            switch (GridColumn)
            {
                case 1:
                    AnimatingCanvasColumn1.Children.Add(ContainerPath);
                    break;
                case 2:
                    AnimatingCanvasColumn2.Children.Add(ContainerPath);
                    break;
                case 3:
                    AnimatingCanvasColumn3.Children.Add(ContainerPath);
                    break;
                case 4:
                    AnimatingCanvasColumn4.Children.Add(ContainerPath);
                    break;
                case 5:
                    AnimatingCanvasColumn5.Children.Add(ContainerPath);
                    break;
                case 6:
                    AnimatingCanvasColumn6.Children.Add(ContainerPath);
                    break;
                case 7:
                    AnimatingCanvasColumn7.Children.Add(ContainerPath);
                    break;
            }

            #endregion

            #region Animation

            /// <summary>
            /// Defined KeyFrames are added to KeyFramesCollector which is then added to the ElevatorAnimation.
            /// KeyFrames are defined by specifying their new value and the time in which that value 'lasts' for (So if my KeyTime is 1 second and my value is a new point, it will take 1 second to reach that new point from whatever starting or previous point).
            /// The animation is applied to the coin by referring to its name and the property being 'animated' is also defined afterwards.
            /// The animation is then added to a Storyboard which then begins.
            /// Lastly, the current coin after being animated is then unregistered to allow new coins to be registered with that name.
            /// </summary>

            KeyFramesCollector = new RectKeyFrameCollection();
            KeyFramesCollector.Add(new LinearRectKeyFrame(new Rect(60, 45, 20, PointDecider(GridColumn - 1, 0)), KeyTime.FromTimeSpan(TimeSpan.FromSeconds(0.25))));
            KeyFramesCollector.Add(new LinearRectKeyFrame(new Rect(60, PointDecider(GridColumn - 1, 1), 20, 20), KeyTime.FromTimeSpan(TimeSpan.FromSeconds(0.50))));
            KeyFramesCollector.Add(new LinearRectKeyFrame(new Rect(20, PointDecider(GridColumn - 1, 2), 100, 70), KeyTime.FromTimeSpan(TimeSpan.FromSeconds(0.50))));

            ElevatorAnimation = new RectAnimationUsingKeyFrames
            {
                Duration = new Duration(TimeSpan.FromSeconds(1.25)),
                KeyFrames = KeyFramesCollector
            };

            Storyboard.SetTargetName(ElevatorAnimation, "AnimatedRectangle");
            Storyboard.SetTargetProperty(ElevatorAnimation, new PropertyPath(RectangleGeometry.RectProperty));

            AnimationContainer = new Storyboard();
            AnimationContainer.Children.Add(ElevatorAnimation);
            AnimationContainer.Begin(this);

            this.UnregisterName("AnimatedRectangle");

            #endregion

            #region Switching Turns

            /// <summary>
            /// The sub ArrayGridHandler is called, filling the parameters with the current Grid column being selected and the current player's turn.
            /// PLayerTurn's value is then changed to allow the next player to make their move.
            /// The lighters are also switch on and off according to the next turn.
            /// </summary>

            ArrayGridHandler(GridColumn - 1, PlayerTurn);

            switch (PlayerTurn)
            {
                case true:
                    PlayerTurn = false;
                    LighterP1.Visibility = Visibility.Hidden;
                    LighterP2.Visibility = Visibility.Visible;
                    break;
                case false:
                    PlayerTurn = true;
                    LighterP2.Visibility = Visibility.Hidden;
                    LighterP1.Visibility = Visibility.Visible;
                    break;
            }

            #endregion
        }

        private void AnimationInitialiter(object sender, MouseEventArgs e)
        {
            //This basically allows both grids (the one in the centre and the on above it) to trigger the subsequent subroutines.

            if (ColumnSelecterGrid.Children.Contains((UIElement)sender))
            {
                Animator(Grid.GetColumn((UIElement)sender) + 1);
            }
            else 
            {
                Animator(Grid.GetColumn((UIElement)sender));
            }
        }
    }
}

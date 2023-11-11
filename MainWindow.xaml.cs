using System.Windows;
using System.Windows.Controls;

namespace Connect_4_The_Game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Creates an Instance of MainWindow

        /// <summary>
        /// Creates An Instance of this windows so that it can be accessed by other windows
        /// </summary>

        static MainWindow _obj;
        public static MainWindow Instance
        {
            get
            {
                if (_obj == null)
                {
                    _obj = new MainWindow();
                }
                return _obj;
            }
        }

        #endregion

        #region Public Grid

        /// <summary>
        /// Creates a public grid that can be accessed by other windows
        /// </summary>

        public Grid ContainerGriddo
        {
            get { return ContainerGrid; }
            set { ContainerGrid = value; }
        }

        #endregion

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _obj = this; //referring _obj to this window
        }

    }
}

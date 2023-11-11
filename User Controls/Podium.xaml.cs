using System.Windows;
using System.Windows.Controls;

namespace Connect_4_The_Game.User_Controls
{
    /// <summary>
    /// Interaction logic for Podium.xaml
    /// </summary>
    public partial class Podium : UserControl
    {
        #region Global Variables

        /// <summary>
        /// List of the global variables.
        /// Winner to display the winner's name retrived from the parameters at the moment when this UserControl has been called.
        /// gameGrid is used to open a new GameGrid UserControl whenever the user clicks on 'rematch'.
        /// </summary>

        string Winner;
        GameGrid gameGrid;

        #endregion

        public Podium(string winner)
        {
            InitializeComponent();
            Winner = winner;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            txtWinningPlayer.Text = Winner;
        }

        private void btnRematch_Click(object sender, RoutedEventArgs e)
        {
            gameGrid = GameGrid.CurrentGameGrid;
            MainWindow.Instance.ContainerGriddo.Children.Remove(gameGrid);
            gameGrid = new GameGrid();
            MainWindow.Instance.ContainerGriddo.Children.Add(gameGrid);
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.Close();
        }
    }
}

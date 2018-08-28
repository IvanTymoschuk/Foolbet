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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FoolBet
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
            MainDB db = new MainDB();

        public MainWindow()
        {

            InitializeComponent();
           
            lbMatches.ItemsSource = db.Matches.ToList();
     

            lbLeagues.ItemsSource = db.Leagues.ToList();




        }

        private void LbLeagues_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           var t = db.Matches.ToList().Where(x => x.TeamHome.League.Equals(lbLeagues.SelectedItem as League));

            lbMatches.ItemsSource = t;

            //lbMatches.ItemsSource = tmp;

        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            lbMatches.ItemsSource = db.Matches.ToList();
        }


        private void BtnSortDate_OnClick(object sender, RoutedEventArgs e)
        {
            lbMatches.ItemsSource = db.Matches.ToList().OrderBy(x => x.MatchDate);
        }

        private void BtnSortLeag_OnClick(object sender, RoutedEventArgs e)
        {
            lbMatches.ItemsSource = db.Matches.ToList().OrderBy(x => x.TeamHome.League.Name);

        }
    }
}

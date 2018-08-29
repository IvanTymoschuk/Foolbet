using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FoolBet
{
    /// <summary>
    /// Interaction logic for MatchWindow.xaml
    /// </summary>
    public partial class MatchWindow : Window
    { Match Match;
        public MatchWindow(Match match)
        {
            InitializeComponent();
            Match = match;
            this.Title = match.TeamHome.Name + " - " + match.TeamAway.Name;
            dgMatchCoefs.ItemsSource = match.Coefs;
            
        }
        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;
            
            e.Handled = Regex.IsMatch(e.Text, "[^0-9.]+");
            if(tbValueBet.Text != "")
            tbGain.Text = ((dgMatchCoefs.SelectedItem as Coeficient).Value * double.Parse(tbValueBet.Text)).ToString();

        }

        private void tbValueBet_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tbValueBet.Text == "Price")
                tbValueBet.Text = "";
        }

        private void dgMatchCoefs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tbValueBet.Text !="Price")
            tbGain.Text = ((dgMatchCoefs.SelectedItem as Coeficient).Value * double.Parse(tbValueBet.Text)).ToString();
            tbNameBet.Text = (dgMatchCoefs.SelectedItem as Coeficient).Name + "  (" + (dgMatchCoefs.SelectedItem as Coeficient).Value + ")";
        }
    }
}

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
    {
        private Accounts account;
        public MatchWindow(Match match,Accounts acc)
        {
            InitializeComponent();
            MainGrid.Visibility = Visibility.Hidden;

            account = acc;
            this.Title = match.TeamHome.Name + " - " + match.TeamAway.Name;
            dgMatchCoefs.ItemsSource = match.Coefs;
            
        }
        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;
            
            e.Handled = Regex.IsMatch(e.Text, "[^0-9.]+");
            
            

        }

        private void tbValueBet_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tbValueBet.Text == "Price")
                tbValueBet.Text = "";
        }

        private void dgMatchCoefs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(dgMatchCoefs.SelectedItem==null)
                MainGrid.Visibility = Visibility.Hidden;
            MainGrid.Visibility = Visibility.Visible;

            tbValueBet.Text = "0";
            tbGain.Text = ((dgMatchCoefs.SelectedItem as Coeficient).Value * double.Parse(tbValueBet.Text)).ToString();         
            tbNameBet.Text = (dgMatchCoefs.SelectedItem as Coeficient).Name + "  (" + (dgMatchCoefs.SelectedItem as Coeficient).Value + ")";
        }

        private void TbValueBet_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbValueBet.Text != null&& dgMatchCoefs.SelectedItem!=null&&!tbValueBet.Text.Contains(".\0"))
                tbGain.Text = ((dgMatchCoefs.SelectedItem as Coeficient).Value * double.Parse(tbValueBet.Text)).ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (account.Money < decimal.Parse(tbValueBet.Text))
            {
                MessageBox.Show("Not enough money to make bet");
                return;
            }
            using (MainDB db = new MainDB())
            {
                UserBet ub = new UserBet()
                {
                    Accounts = account, Coef = (dgMatchCoefs.SelectedItem as Coeficient),
                    Price = double.Parse(tbValueBet.Text)
                };

                db.UserBets.Add(ub);
                db.SaveChanges();
                
            }

            MessageBox.Show("Bet made!");
            this.Close();
        }
    
    }
}

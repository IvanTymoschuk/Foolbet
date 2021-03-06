﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        //    MainDB db = new MainDB();
        public Accounts account;
        public MainWindow(Accounts acc)
        {

            InitializeComponent();
            
            account = acc;
            AccCard.DataContext = account;
            using (MainDB db = new MainDB())
            {
                lbMatches.ItemsSource = db.Matches.Include("TeamHome").Include("TeamAway").ToList();
                lbLeagues.ItemsSource = db.Leagues.ToList();
            }

            RefreshAccCard(acc);




        }

        public void RefreshAccCard(Accounts acc)
        {
            tbAccName.Text = String.Format("My Account Card (" + acc.Email + ")");
            //tbBalance.Text = acc.Money.ToString("C");           
            tbOpenBetsBal.Text = acc.Bets.Sum(x => x.Price).ToString("C");
            lbUserBets.ItemsSource = acc.Bets.ToList();
        }

        public void GetBets()
        {
            using (MainDB db = new MainDB())
            {
                db.Accounts.Attach(account);
                lbUserBets.ItemsSource  = account.Bets.ToList();
            }

        }


        private void LbLeagues_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using (MainDB db = new MainDB())
            {
                var t = db.Matches.ToList().Where(x => x.TeamHome.League.Equals(lbLeagues.SelectedItem as League));
                lbMatches.ItemsSource = t;
            }
            //lbMatches.ItemsSource = tmp;

        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            using (MainDB db = new MainDB())
            {
                lbMatches.ItemsSource = db.Matches.Include("TeamHome").Include("TeamAway").ToList();
            }
        }


        private void BtnSortDate_OnClick(object sender, RoutedEventArgs e)
        {
            lbMatches.Items.SortDescriptions.Add(new System.ComponentModel.SortDescription("MatchDate", System.ComponentModel.ListSortDirection.Ascending));
            
        }

        private void BtnSortLeag_OnClick(object sender, RoutedEventArgs e)
        {
            lbMatches.Items.SortDescriptions.Add(new System.ComponentModel.SortDescription("TeamHome.League.Name", System.ComponentModel.ListSortDirection.Ascending));
        }

        private void lbMatches_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Match match = (lbMatches.SelectedItem as Match);
            MatchWindow mw = new MatchWindow(match,account);
            mw.ShowDialog();
            //RefreshAccCard(account);
            GetBets();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Payment.PayIn pay = new Payment.PayIn();
            pay.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Payment.PayOut pay = new Payment.PayOut();
            pay.ShowDialog();
        }
    }
}

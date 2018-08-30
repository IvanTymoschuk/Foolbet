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
using System.Windows.Shapes;

namespace FoolBet
{
    /// <summary>
    /// Interaction logic for Autorization.xaml
    /// </summary>
    public partial class Autorization : Window
    {
       // MainDB db = new MainDB();
        public Autorization()
        {
            InitializeComponent();
        }

        private void Login_btn_OnClick(object sender, RoutedEventArgs e)
        {
            using (MainDB db = new MainDB())
            {
                Accounts acc = db.Accounts.FirstOrDefault(x => x.Email == Login.Text);
                if (acc == null)
                {
                    MessageBox.Show("Login not found");
                    //return;
                }

                MainWindow mw = new MainWindow(acc);

                if (acc.Password == Pass.Password)
                {

                    this.Close();
                    mw.Show();
                }
                else
                {
                    MessageBox.Show("Password is in corrected");
                }
            }
        }

        private void Reg_btn_OnClick_(object sender, RoutedEventArgs e)
        {
            Registration new_acc = new Registration();
            new_acc.ShowDialog();
        }
    }
}

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
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        MainDB db=new MainDB();
        public Registration()
        {
            InitializeComponent();
        }

        private void Reg_btn_OnClick(object sender, RoutedEventArgs e)
        {
            Accounts acc = new Accounts()
            {
                Email = tbLogin.Text,
                Password = pbPass.Password,
                Money = decimal.Parse(tbMoney.Text)

            };

            db.Accounts.Add(acc);
            db.SaveChanges();
            MessageBox.Show("New account created. Please input data");
            this.Close();
        }

        private void Close_btn_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

       
    }
}

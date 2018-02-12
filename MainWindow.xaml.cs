using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Sibras
{
    public partial class MainWindow : Window
    {
        DispatcherTimer timer;
        Loader pageLoader;
        Login pageLogin;

        public MainWindow()
        {
            InitializeComponent();

            this.Visibility = System.Windows.Visibility.Hidden;

            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 0, 0, 50);
            timer.Start();

            pageLoader = new Loader();
            pageLoader.Show();

            pageLogin = new Login();
            pageLogin.button1.Click += new RoutedEventHandler(button1_Click);
            pageLogin.button2.Click += new RoutedEventHandler(button2_Click);
        }

        void button2_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("cancelado");
        }

        void button1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("verificar se login e senha estao correto, avança prox tela, ou mostra mensagem erro");

            pageLogin.Close();
            this.Visibility = System.Windows.Visibility.Visible;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (pageLoader.progressBar1.Value < 100)
            {
                pageLoader.progressBar1.Value = pageLoader.progressBar1.Value + RandomNumber(0, 5);
            }
            else
            {
                pageLoader.Close();
                pageLogin.Show();
                timer.Stop();
            }
        }

        private int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        private void RadTabControlPainel_SelectionChanged(object sender, Telerik.Windows.Controls.RadSelectionChangedEventArgs e)
        {
            /*
            if (RadTabControlPainel.SelectedIndex == 0)
            {
                //((Sibras.MainWindow)Application.Current.MainWindow).StatusBarInformacoes.Content = ("Carregando produtos...");
                //GridTabItemProdutos.Children[0].Add(new Loader());
                GridTabItemProdutos.DataContext = new Loader();
            }
             */
        }

    }
}

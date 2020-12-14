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

namespace Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Cribbage c;

        Button[] humansHand = new Button[6];
        Button[] AIHand = new Button[6];
        


        public MainWindow()
        {
            InitializeComponent();
            

            c = new Cribbage();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            // Turn Off Button
            play.Visibility = Visibility.Hidden;
            c.startround();
            ShowHand();
           
            



        }

        void ShowHand()
        {
            Player p = c.getPlayer(0);
            Player ai = c.getPlayer(1);
            int dis = 0;
            
            foreach(Card card in p.ReturnHand())
            {
                CreateCard(card.number, card.suit, card, dis, true);
                dis++;
            }
            dis = 0;
            foreach (Card card in p.ReturnHand())
            {
                CreateCard(card.number, card.suit, card, dis, false);
                dis++;
            }

        }

        void CreateCard(int num, int suit, Card crd, int offset, bool human)
        {
            Button card = new Button();
            
            card.Height = 80;
            card.Width = 56;
            Image img = new Image();
            BitmapImage bitm = new BitmapImage(new Uri(crd.getName() + ".jpg", UriKind.Relative));
            //might want to change this format
            card.Name = "C" + Convert.ToString(num)+ "b" + Convert.ToString(suit);
            img.Width = 100;
            img.Height = 80;
            img.Source = bitm;
            card.Content = img;
            card.Visibility = Visibility.Visible;
            card.Margin = new Thickness(offset * 108, 0, 0, 0);
            if(human)
            {
                bottomCanvas.Children.Add(card);
                humansHand[offset] = card;
            }
            else
            {
                AIHand[offset] = card;
            }
                
        }
        void updateBoard()
        {


        }


    }
}

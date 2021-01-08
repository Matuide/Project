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
        Image[] AIHand = new Image[6];


        public MainWindow()
        {
            InitializeComponent();

            //AICards = new Image[] { AICard1, AICard2, AICard3, AICard4, AICard5, AICard6 };

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
            
            if(human)
            {
                card.Content = img;
                card.Click += Card_Click;
                card.Visibility = Visibility.Visible;
                Connect4_Board.Children.Add(card);
                Grid.SetColumn(card, offset);
                Grid.SetRow(card, 4);
                humansHand[offset] = card;
            }
            else
            {
                img.Visibility = Visibility.Visible;
                Connect4_Board.Children.Add(img);
                Grid.SetColumn(img,offset);
                Grid.SetRow(img,0);
                AIHand[offset] = img;
            }
                
        }
        void updateBoard()
        {


        }


        void Card_Click(object sender, RoutedEventArgs e)
        {
            Button tempCard = sender as Button;
            tempCard.Visibility = Visibility.Hidden;
            //do stuff like put into crib method in game etc...
        }

    }
}

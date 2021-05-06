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
        int humanPts, aiPts;
        Label AIPTS;
        Label HUMANPTS;
       


        public MainWindow()
        {
            InitializeComponent();
            
            Instructions.Visibility = Visibility.Hidden;

            aiPts = 0;
            humanPts = 0;
            c = new Cribbage();
            HUMANPTS = new Label();
            AIPTS = new Label();
            //describing the position,colour and size of the number in each corner displaying the points
            HUMANPTS.VerticalAlignment = VerticalAlignment.Bottom;
            HUMANPTS.HorizontalAlignment = HorizontalAlignment.Right;
            AIPTS.VerticalAlignment = VerticalAlignment.Top;
            AIPTS.HorizontalAlignment = HorizontalAlignment.Right;
            AIPTS.Foreground = new SolidColorBrush(Colors.White);
            HUMANPTS.Foreground = new SolidColorBrush(Colors.White);
            HUMANPTS.FontSize = 50;
            AIPTS.FontSize = 50;
            GridPanel.Children.Add(HUMANPTS);
            GridPanel.Children.Add(AIPTS);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int cribowner = 0;
            // Turn Off Buttons 
            play.Visibility = Visibility.Hidden;
            Instruction.Visibility = Visibility.Hidden;
            cribowner = (cribowner+1)% 2;

            Restart();
        }

        void Restart()
        {

            c = new Cribbage();
            c.startround();
            ShowHand();
            c.GetPile().Push(c.getDeck().pop());
        }

        void ShowHand()
        {
            Player p = c.getPlayer(0);
            Player ai = c.getPlayer(1);
            int counter = 0;

            Cribbage_Board.Children.Clear();

            foreach (Card card in p.ReturnHand())
            {
                //get each card from the player's hand and put them on the UI
                if (card != null)
                {
                    CreateCard(card.number, card.suit, card, counter, true);
                    counter++;
                }
            }
            counter = 0;
            foreach (Card card in ai.ReturnHand())
            {
                
                if (card != null)
                {
                    CreateCard(card.number, card.suit, card, counter, false);
                    counter++;
                }
            }
        }

        void CreateCard(int num, int suit, Card crd, int offset, bool human)
        {
            Button card = new Button();
            //set button sizes according to ration of size of real playing cards
            card.Height = 107;
            card.Width = 75;
            Image img = new Image();
            Image imag = new Image();
            //As the player is not supposed to see what cards the AI has
            //this just displays the back of a card picture of colour purple because thats the colour
            //that Charlie thought was best
            BitmapImage bean = new BitmapImage(new Uri("purple_back.jpg", UriKind.Relative));
            BitmapImage bitm = new BitmapImage(new Uri(crd.getName() + ".jpg", UriKind.Relative));
            
            card.Name = "C" + Convert.ToString(num) + Convert.ToString(suit);

            img.Width = 133;
            img.Height = 107;
            img.Source = bitm;
            imag.Source = bean;
            imag.Width = 133;
            imag.Height = 107;
            if (human)
            {
                card.Content = img;
                card.Click += Card_Click;
                card.Visibility = Visibility.Visible;
                Cribbage_Board.Children.Add(card);
                Grid.SetColumn(card, offset);
                Grid.SetRow(card, 4);
                humansHand[offset] = card;
            }
            else
            {
                Cribbage_Board.Children.Add(imag);
                Grid.SetColumn(imag, offset);
                Grid.SetRow(imag, 0);
                AIHand[offset] = imag;
            }

        }


        void Card_Click(object sender, RoutedEventArgs e)
        {
            Button tempCard = sender as Button;
            Card card = null;
            bool loop = true;
            foreach (Card temp in c.getPlayer(0).getHand().gethand())
            {
                if (temp != null)
                {
                    Console.WriteLine("C" + temp.getName());
                    if (("C" + temp.getUIName()) == tempCard.Name)
                    {
                        card = temp;
                    }
                }
            }
            if (CheckPile())
            {
                if (CheckCards(card))
                {
                    tempCard.Visibility = Visibility.Hidden;
                    c.playerClickCard(card);
                
                    //if the player has thrown 2 cards away then let them play
                    if (c.getPlayer(0).getHand().Count() > 3)
                    {
                        c.ThrowOne();
                        ShowHand();
                        //shows starter card
                        if (c.getPlayer(0).getHand().Count() < 5)
                        {
                            RenderPile();
                            humanPts += CountPlayerPoints(0);
                            aiPts += CountPlayerPoints(1);
                        }
                    }
                    else
                    {
                        c.GetPile().Push(card);
                        if(CardPlace(1))
                            c.GetPile().Push(c.getPlayer(1).move());
                        ShowHand();
                        RenderPile();
                        Console.WriteLine(Convert.ToString(aiPts + humanPts));

                        HUMANPTS.Content = Convert.ToString(humanPts);
                        AIPTS.Content = Convert.ToString(aiPts);
                        if (humanPts >= 121)
                        {
                            MessageBox.Show("Human wins");
                        }
                        else if (aiPts >= 121)
                        {
                            MessageBox.Show("AI wins");
                        }
                    }
                }
                else if(!CardPlace(1) && !CardPlace(0))
                {
                    for(int i = 1; i < c.GetPile().GetArray().Length; i++)
                    {
                        c.GetPile().GetArray()[i] = null;
                    }
                }
                else if (!CardPlace(0) && CardPlace(1))
                {
                    c.GetPile().Push(c.getPlayer(1).move());
                    ShowHand();
                    RenderPile();
                }
                while(c.getPlayer(0).getHand().Count() == 0 && loop)
                {
                    if (c.getPlayer(1).getHand().Count() == 0)
                    {
                        Restart();
                        loop = false;
                    }
                    else
                    {
                        c.GetPile().Push(c.getPlayer(1).move());
                        ShowHand();
                        RenderPile();
                    }
                }
            }
            else
            {
                Restart();
            }

        }

        bool CardPlace(int p)
        {
            bool place = false;
            if (p == 0)
            {
                foreach (Card crd in c.getPlayer(0).getHand().gethand())
                {
                    if (crd != null && CheckCards(crd))
                    {
                        place = true;
                    }
                }
            }
            if (p == 1)
            {
                foreach (Card crd in c.getPlayer(1).getHand().gethand())
                {
                    if (crd != null && CheckCards(crd))
                    {
                        place = true;
                    }
                }
            }
            return place;
        }


        bool CheckCards(Card cr)
        {
            bool check = true;
            c.GetPile().Push(cr);
            if (CountScore(c.GetPile().GetArray()) > 31)
            {
                check = false;
            }
            c.GetPile().Remove();
            return check;
        }
        bool CheckPile()
        {
            bool check = true;
            if (CountScore(c.GetPile().GetArray()) > 31)
            {
                check = false;
            }
            return check;
        }

        int CountScore(Card[] bean)
        {
            int spoon = 0, bread = 0;
            foreach (Card mules in bean)
            {
                if (mules != null && bread > 0)
                    spoon += mules.tempnumber;
                bread++;
            }
            return spoon;
        }

        int CountPlayerPoints(int p)
        {
            Card[] Hand = new Card[5];
            int score;
            int counter = 0;

            foreach (Card crd in c.getPlayer(p).getHand().gethand())
            {
                if(crd != null)
                {
                    Hand[counter] = crd;
                    counter++;
                }
            }

            Hand[4] = c.GetPile().GetArray()[0];
            score = c.getPlayer(p).getHand().CountPoints(Hand);
            return score;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Instructions.Visibility = Visibility.Visible;
        }

        void RenderPile()
        {
            int count = 0;
            foreach (Card crd in c.GetPile().GetArray())
            {
                if (crd != null)
                {
                    Button card = new Button();
                    BitmapImage bitm;
                    Image img = new Image();
                    card.Height = 160;
                    card.Width = 112;
                    bitm = new BitmapImage(new Uri(crd.getName() + ".jpg", UriKind.Relative));
                    img.Width = 200;
                    img.Height = 160;
                    img.Source = bitm;

                    card.Content = img;
                    card.Visibility = Visibility.Visible;
                    Cribbage_Board.Children.Add(card);
                    Grid.SetColumn(card, count);
                    Grid.SetRow(card, 2);
                    count++;
                }
            }
        }

    }
}

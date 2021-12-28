using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
namespace CardGame.SupportClasses
{
    public class Player : IHand, IActions, INotifyPropertyChanged
    {
        private readonly int maxTotal = 21;
        private bool canHit;
        private Visibility visible;
        private bool busted;
        private int total;
        private ObservableCollection<Card> hand;
        public event PropertyChangedEventHandler PropertyChanged;
        public event NotifyCollectionChangedEventHandler CollectionChanged;
        public Player(ref Deck deck)
        {
            Deck = deck;
            CanHit = true;
            RevealedCards = new ObservableCollection<Card>();
            Card cardOne = Deck.Cards.Dequeue();
            RevealedCards.Add(cardOne);
            Card cardTwo = Deck.Cards.Dequeue();
            RevealedCards.Add(cardTwo);
        }
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public Visibility Visible { get { return visible; } set { visible = value; OnPropertyChanged("Visible"); } }
        public bool CanHit { get { return canHit; } set { canHit = value; OnPropertyChanged("CanHit"); } }
        public bool Busted { get { return busted; } set { busted = value; OnPropertyChanged("Busted"); } }
        public int Total { get { return total; } set { total = value; OnPropertyChanged("Total"); } }
        private Deck Deck { get; set; }
        public ObservableCollection<Card> RevealedCards { get { return hand; } set { hand = value; } }
        public bool DidWin()
        {
            List<Card> aces = new List<Card>();
            int sum = 0;
            bool result = false;
            //Get Sum of Non-Ace Cards
            for (var i = 0; i < RevealedCards.Count; i++)
            {
                if (RevealedCards[i].Face != Faces.Ace)
                {
                    sum += RevealedCards[i].Value;
                }

                else
                {
                    aces.Add(RevealedCards[i]);
                }


            }
            if (sum == 21)
            {
                result = true;
            }

            //check all possibilities to find one way to add to 21
            if (aces.Count == 1)
            {
                result = Is21(aces[0], sum);
            }

            if (aces.Count == 2)
            {
                aces[0].Value = 11;
                result |= Is21(aces[1], sum + aces[0].Value);
                aces[0].Value = 1;
                result |= Is21(aces[1], sum + aces[0].Value);
            }

            if (aces.Count == 3)
            {
                aces[0].Value = 1;
                aces[1].Value = 1;
                result |= Is21(aces[2], sum + aces[0].Value + aces[1].Value);
                aces[0].Value = 1;
                aces[1].Value = 11;
                result |= Is21(aces[2], sum + aces[0].Value + aces[1].Value);
                aces[0].Value = 11;
                aces[1].Value = 1;
                result |= Is21(aces[2], sum + aces[0].Value + aces[1].Value);
                aces[0].Value = 11;
                aces[1].Value = 11;
                result |= Is21(aces[2], sum + aces[0].Value + aces[1].Value);
            }

            if (aces.Count == 4)
            {
                aces[0].Value = 1;
                aces[1].Value = 1;
                aces[2].Value = 1;
                result |= Is21(aces[2], sum + aces[0].Value + aces[1].Value + aces[2].Value);
                aces[0].Value = 1;
                aces[1].Value = 1;
                aces[2].Value = 11;
                result |= Is21(aces[2], sum + aces[0].Value + aces[1].Value + aces[2].Value);
                aces[0].Value = 1;
                aces[1].Value = 11;
                aces[2].Value = 1;
                result |= Is21(aces[2], sum + aces[0].Value + aces[1].Value + aces[2].Value);
                aces[0].Value = 1;
                aces[1].Value = 11;
                aces[2].Value = 11;
                result |= Is21(aces[2], sum + aces[0].Value + aces[1].Value + aces[2].Value);
                aces[0].Value = 11;
                aces[1].Value = 1;
                aces[2].Value = 1;
                result |= Is21(aces[2], sum + aces[0].Value + aces[1].Value + aces[2].Value);
                aces[0].Value = 11;
                aces[1].Value = 1;
                aces[2].Value = 11;
                result |= Is21(aces[2], sum + aces[0].Value + aces[1].Value + aces[2].Value);
                aces[0].Value = 11;
                aces[1].Value = 11;
                aces[2].Value = 1;
                result |= Is21(aces[2], sum + aces[0].Value + aces[1].Value + aces[2].Value);
                aces[0].Value = 11;
                aces[1].Value = 11;
                aces[2].Value = 11;
                result |= Is21(aces[2], sum + aces[0].Value + aces[1].Value + aces[2].Value);

            }

            if (result)
            {
                Debug.Write("\nPlayer Won\n");
                for (var i = 0; i < RevealedCards.Count; i++)
                {
                    Debug.Write(RevealedCards[i].Symbol + " " + RevealedCards[i].Face + "\n");
                }

            }

            return result;

        }
        public bool DidLose()
        {
            bool result = false;
            int sum = 0;
            List<Card> aces = new List<Card>();

            //Get Sum of Non-Ace Cards
            for (var i = 0; i < RevealedCards.Count; i++)
            {
                if (RevealedCards[i].Face != Faces.Ace)
                {
                    sum += RevealedCards[i].Value;
                }
                else
                {
                    aces.Add(RevealedCards[i]);
                }
            }
            if (sum > 21)
            {
                result = true;
            }
            //check all possibilities to find one way to add to 21
            if (aces.Count == 1)
            {
                result = IsOver21(aces[0], sum);
            }
            if (aces.Count == 2)
            {
                aces[0].Value = 11;
                result &= IsOver21(aces[1], sum + aces[0].Value);
                aces[0].Value = 1;
                result &= IsOver21(aces[1], sum + aces[0].Value);
            }
            if (aces.Count == 3)
            {
                aces[0].Value = 1;
                aces[1].Value = 1;
                result &= IsOver21(aces[2], sum + aces[0].Value + aces[1].Value);
                aces[0].Value = 1;
                aces[1].Value = 11;
                result &= IsOver21(aces[2], sum + aces[0].Value + aces[1].Value);
                aces[0].Value = 11;
                aces[1].Value = 1;
                result &= IsOver21(aces[2], sum + aces[0].Value + aces[1].Value);
                aces[0].Value = 11;
                aces[1].Value = 11;
                result &= IsOver21(aces[2], sum + aces[0].Value + aces[1].Value);
            }
            if (aces.Count == 4)
            {
                aces[0].Value = 1;
                aces[1].Value = 1;
                aces[2].Value = 1;
                result &= IsOver21(aces[2], sum + aces[0].Value + aces[1].Value + aces[2].Value);
                aces[0].Value = 1;
                aces[1].Value = 1;
                aces[2].Value = 11;
                result &= IsOver21(aces[2], sum + aces[0].Value + aces[1].Value + aces[2].Value);
                aces[0].Value = 1;
                aces[1].Value = 11;
                aces[2].Value = 1;
                result &= IsOver21(aces[2], sum + aces[0].Value + aces[1].Value + aces[2].Value);
                aces[0].Value = 1;
                aces[1].Value = 11;
                aces[2].Value = 11;
                result &= IsOver21(aces[2], sum + aces[0].Value + aces[1].Value + aces[2].Value);
                aces[0].Value = 11;
                aces[1].Value = 1;
                aces[2].Value = 1;
                result &= IsOver21(aces[2], sum + aces[0].Value + aces[1].Value + aces[2].Value);
                aces[0].Value = 11;
                aces[1].Value = 1;
                aces[2].Value = 11;
                result &= IsOver21(aces[2], sum + aces[0].Value + aces[1].Value + aces[2].Value);
                aces[0].Value = 11;
                aces[1].Value = 11;
                aces[2].Value = 1;
                result &= IsOver21(aces[2], sum + aces[0].Value + aces[1].Value + aces[2].Value);
                aces[0].Value = 11;
                aces[1].Value = 11;
                aces[2].Value = 11;
                result &= IsOver21(aces[2], sum + aces[0].Value + aces[1].Value + aces[2].Value);
            }
            if(result)
            {
                Debug.Write("\nPlayer Busted\n");
                for (var i = 0; i < RevealedCards.Count; i++)
                {
                    Debug.Write(RevealedCards[i].Symbol + " " + RevealedCards[i].Face + "\n");
                }
            }
            return result;
        }
        public void Hit()
        {
            if (CanHit)
            {
                Card card = Deck.Cards.Dequeue();
                if (card.Face == Faces.Ace)
                {
                    int potentialTotal = Total + card.Value;
                    if (IsBusted(potentialTotal))
                        card.Value = 1;
                }
                Total += card.Value;
                Busted = IsBusted(Total);
                RevealedCards.Add(card);
                CollectionChanged?.Invoke(this.RevealedCards, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, card));
            }
        }
        public void Stand()
        {
            Visible = Visibility.Hidden;
            CanHit = false;
        }
        public int CalculateScore()
        {
            List<Card> aces = new List<Card>();
            List<int> scores = new List<int>();
            int sum = 0;

            for (var i = 0; i < RevealedCards.Count; i++)
            {
                if (RevealedCards[i].Face != Faces.Ace)
                {
                    sum += RevealedCards[i].Value;
                    scores.Add(sum);

                }

                else
                {
                    aces.Add(RevealedCards[i]);
                }
            }
            //check all possibilities to find one way to add to 21
            if (aces.Count == 1)
            {
                aces[0].Value = 1;
                scores.Add(sum + aces[0].Value);
                aces[0].Value = 11;
                scores.Add(sum + aces[0].Value);
            }
            if (aces.Count == 2)
            {
                aces[0].Value = 1;
                aces[1].Value = 1;
                scores.Add(sum + aces[0].Value + aces[1].Value);
                aces[0].Value = 1;
                aces[1].Value = 11;
                scores.Add(sum + aces[0].Value + aces[1].Value);
                aces[0].Value = 11;
                aces[1].Value = 1;
                scores.Add(sum + aces[0].Value + aces[1].Value);
                aces[0].Value = 11;
                aces[1].Value = 11;
                scores.Add(sum + aces[0].Value + aces[1].Value);
            }
            if (aces.Count == 3)
            {
                aces[0].Value = 1;
                aces[1].Value = 1;
                aces[2].Value = 1;
                scores.Add(sum + aces[0].Value + aces[1].Value + aces[2].Value);
                aces[0].Value = 1;
                aces[1].Value = 1;
                aces[2].Value = 11;
                scores.Add(sum + aces[0].Value + aces[1].Value + aces[2].Value);
                aces[0].Value = 1;
                aces[1].Value = 11;
                aces[2].Value = 1;
                scores.Add(sum + aces[0].Value + aces[1].Value + aces[2].Value);
                aces[0].Value = 1;
                aces[1].Value = 11;
                aces[2].Value = 11;
                scores.Add(sum + aces[0].Value + aces[1].Value + aces[2].Value);
                aces[0].Value = 11;
                aces[1].Value = 1;
                aces[2].Value = 1;
                scores.Add(sum + aces[0].Value + aces[1].Value + aces[2].Value);
                aces[0].Value = 11;
                aces[1].Value = 1;
                aces[2].Value = 11;
                scores.Add(sum + aces[0].Value + aces[1].Value + aces[2].Value);
                aces[0].Value = 11;
                aces[1].Value = 11;
                aces[2].Value = 1;
                scores.Add(sum + aces[0].Value + aces[1].Value + aces[2].Value);
                aces[0].Value = 11;
                aces[1].Value = 11;
                aces[2].Value = 11;
                scores.Add(sum + aces[0].Value + aces[1].Value + aces[2].Value);

            }
            if (aces.Count == 4)
            {
                aces[0].Value = 1;
                aces[1].Value = 1;
                aces[2].Value = 1;
                aces[3].Value = 1;
                scores.Add(sum + aces[0].Value + aces[1].Value + aces[2].Value + aces[3].Value);
                aces[0].Value = 1;
                aces[1].Value = 1;
                aces[2].Value = 1;
                aces[3].Value = 11;
                scores.Add(sum + aces[0].Value + aces[1].Value + aces[2].Value + aces[3].Value);
                aces[0].Value = 1;
                aces[1].Value = 1;
                aces[2].Value = 11;
                aces[3].Value = 1;
                scores.Add(sum + aces[0].Value + aces[1].Value + aces[2].Value + aces[3].Value);
                aces[0].Value = 1;
                aces[1].Value = 1;
                aces[2].Value = 11;
                aces[3].Value = 11;
                scores.Add(sum + aces[0].Value + aces[1].Value + aces[2].Value + aces[3].Value);
                aces[0].Value = 1;
                aces[1].Value = 11;
                aces[2].Value = 1;
                aces[3].Value = 1;
                scores.Add(sum + aces[0].Value + aces[1].Value + aces[2].Value + aces[3].Value);
                aces[0].Value = 1;
                aces[1].Value = 11;
                aces[2].Value = 1;
                aces[3].Value = 11;
                scores.Add(sum + aces[0].Value + aces[1].Value + aces[2].Value + aces[3].Value);
                aces[0].Value = 1;
                aces[1].Value = 11;
                aces[2].Value = 11;
                aces[3].Value = 1;
                scores.Add(sum + aces[0].Value + aces[1].Value + aces[2].Value + aces[3].Value);
                aces[0].Value = 1;
                aces[1].Value = 11;
                aces[2].Value = 11;
                aces[3].Value = 11;
                scores.Add(sum + aces[0].Value + aces[1].Value + aces[2].Value + aces[3].Value);
                aces[0].Value = 11;
                aces[1].Value = 1;
                aces[2].Value = 1;
                aces[3].Value = 1;
                scores.Add(sum + aces[0].Value + aces[1].Value + aces[2].Value + aces[3].Value);
                aces[0].Value = 11;
                aces[1].Value = 1;
                aces[2].Value = 1;
                aces[3].Value = 11;
                scores.Add(sum + aces[0].Value + aces[1].Value + aces[2].Value + aces[3].Value);
                aces[0].Value = 11;
                aces[1].Value = 1;
                aces[2].Value = 11;
                aces[3].Value = 1;
                scores.Add(sum + aces[0].Value + aces[1].Value + aces[2].Value + aces[3].Value);
                aces[0].Value = 11;
                aces[1].Value = 1;
                aces[2].Value = 11;
                aces[3].Value = 11;
                scores.Add(sum + aces[0].Value + aces[1].Value + aces[2].Value + aces[3].Value);
                aces[0].Value = 11;
                aces[1].Value = 11;
                aces[2].Value = 1;
                aces[3].Value = 1;
                scores.Add(sum + aces[0].Value + aces[1].Value + aces[2].Value + aces[3].Value);
                aces[0].Value = 11;
                aces[1].Value = 11;
                aces[2].Value = 1;
                aces[3].Value = 11;
                scores.Add(sum + aces[0].Value + aces[1].Value + aces[2].Value + aces[3].Value);
                aces[0].Value = 11;
                aces[1].Value = 11;
                aces[2].Value = 11;
                aces[3].Value = 1;
                scores.Add(sum + aces[0].Value + aces[1].Value + aces[2].Value + aces[3].Value);
                aces[0].Value = 11;
                aces[1].Value = 11;
                aces[2].Value = 11;
                aces[3].Value = 11;
                scores.Add(sum + aces[0].Value + aces[1].Value + aces[2].Value + aces[3].Value);
            }
            scores = scores.OrderBy(number => number).ToList();
            //find index of first score greater than 21
            int stopIndex = -1;
            for (var i = 0; i < scores.Count; i++)
            {
                if (scores[i] > 21)
                {
                    stopIndex = i;
                    break;
                }

            }
            if (stopIndex >= 0 && stopIndex <= scores.Count - 1)
            {
                //remove all scores that are greter than 21
                scores.RemoveRange(stopIndex, scores.Count - stopIndex);
                scores.TrimExcess();
            }
            //sort scores to be in descending order(greatest at the beginning (21 ..20...19)
            scores.Reverse();
            Debug.Write("\nPlayers's Hand: \n");
            for (var i = 0; i < RevealedCards.Count; i++)
            {
                Debug.Write(RevealedCards[i].Symbol + " " + RevealedCards[i].Face + "\n");
            }

            //return closest to 21
            return scores[0];
        }
        public bool Is21(Card ace, int sum)
        {
            int possibleSum = sum + ace.Value;
            if (possibleSum == 21)
                return true;
            else
            {
                ace.Value = 1;
                possibleSum = sum + ace.Value;
                if (possibleSum == 21)
                    return true;
            }
            return false;
        }
        public bool IsOver21(Card ace, int sum)
        {
            int possibleSum = sum + ace.Value;
            if (possibleSum > 21)
                return true;
            else
            {
                ace.Value = 1;
                possibleSum = sum + ace.Value;
                if (possibleSum > 21)
                    return true;
            }
            return false;
        }
        public bool IsBusted(int total)
        {
            bool result = false; ;
            if (total > maxTotal)
                result = true;
            return result;
        }
    }
}
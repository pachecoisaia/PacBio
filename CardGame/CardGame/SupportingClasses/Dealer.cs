using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
namespace CardGame.SupportClasses
{
    public class Dealer : IHand, INotifyPropertyChanged
    {
        private readonly int maxTotal = 21;
        private bool canHit;
        private bool busted;
        private int total;
        private ObservableCollection<Card> revealedCards;
        private ObservableCollection<Card> hiddenCard;
        public event PropertyChangedEventHandler PropertyChanged;
        public event NotifyCollectionChangedEventHandler CollectionChanged;
        public Dealer(ref Deck deck)
        {
            Deck = deck;
            CanHit = true;
            RevealedCards = new ObservableCollection<Card>();
            HiddenCards = new ObservableCollection<Card>();
            Card cardOne = Deck.Cards.Dequeue();
            RevealedCards.Add(cardOne);
            Card cardTwo = Deck.Cards.Dequeue();
            hiddenCard.Add(cardTwo);
        }
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public bool CanHit { get { return canHit; } set { canHit = value; OnPropertyChanged("CanHit"); } }
        public bool Busted { get { return busted; } set { busted = value; OnPropertyChanged("Busted"); } }
        public int Total { get { return total; } set { total = value; OnPropertyChanged("Total"); } }
        private Deck Deck { get; set; }
        public ObservableCollection<Card> RevealedCards { get { return revealedCards; } set { revealedCards = value; } }
        public ObservableCollection<Card> HiddenCards { get { return hiddenCard; } set { hiddenCard = value; } }
        public void Deal(ref Player player)
        {
            Card card = Deck.Cards.Dequeue();
            player.RevealedCards.Add(card);
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, card));
        }
        public void Hit()
        {
            while(DealerUnder17() & CanHit)
            {
                Card card = Deck.Cards.Dequeue();
                RevealedCards.Add(card);
                CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, card));
            }
            Stand();
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
            for(var i = 0; i< scores.Count; i++)
            {
                if(scores[i] > 21)
                {
                    stopIndex = i;
                    break;
                }
                
            }
            if (stopIndex >= 0 &&  stopIndex <= scores.Count - 1)
            {
                //remove all scores that are greter than 21
                scores.RemoveRange(stopIndex, scores.Count- stopIndex);
                scores.TrimExcess();
            }
            //sort scores to be in descending order(greatest at the beginning (21 ..20...19)
            scores.Reverse();
            Debug.Write("\nDealer's Hand: \n");
            for (var i = 0; i < RevealedCards.Count; i++)
            {
                Debug.Write(RevealedCards[i].Symbol + " " + RevealedCards[i].Face + "\n");
            }
            //return closest to 21
            return scores[0];
        }
        public void Stand()
        {
            CanHit = false;
            Total = CalculateScore();
        }    
        public int DecideAction()
        {
            int action = -1;

            if(DidWin())
            {
                Stand();
                action = 1;
            }

            else {
                Hit();
                action = 0;
            }

            return action;

        }
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
                Debug.Write("\nDealer Won\n");
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

            if (result)
            {
                Debug.Write("\nDealer Busted\n");
                for (var i = 0; i < RevealedCards.Count; i++)
                {
                    Debug.Write(RevealedCards[i].Symbol + " " + RevealedCards[i].Face + "\n");
                }
            }

            return result;
        }
        public bool DealerUnder17()
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
            if (sum < 17)
            {
                result = true;
            }

            //check all possibilities to find one way to add to 21
            if (aces.Count == 1)
            {
                result = IsUnder17(aces[0], sum);
            }

            if (aces.Count == 2)
            {
                aces[0].Value = 11;
                result |= IsUnder17(aces[1], sum + aces[0].Value);
                aces[0].Value = 1;
                result |= IsUnder17(aces[1], sum + aces[0].Value);
            }

            if (aces.Count == 3)
            {
                aces[0].Value = 1;
                aces[1].Value = 1;
                result |= IsUnder17(aces[2], sum + aces[0].Value + aces[1].Value);
                aces[0].Value = 1;
                aces[1].Value = 11;
                result |= IsUnder17(aces[2], sum + aces[0].Value + aces[1].Value);
                aces[0].Value = 11;
                aces[1].Value = 1;
                result |= IsUnder17(aces[2], sum + aces[0].Value + aces[1].Value);
                aces[0].Value = 11;
                aces[1].Value = 11;
                result |= IsUnder17(aces[2], sum + aces[0].Value + aces[1].Value);
            }

            if (aces.Count == 4)
            {
                aces[0].Value = 1;
                aces[1].Value = 1;
                aces[2].Value = 1;
                result |= IsUnder17(aces[2], sum + aces[0].Value + aces[1].Value + aces[2].Value);
                aces[0].Value = 1;
                aces[1].Value = 1;
                aces[2].Value = 11;
                result |= IsUnder17(aces[2], sum + aces[0].Value + aces[1].Value + aces[2].Value);
                aces[0].Value = 1;
                aces[1].Value = 11;
                aces[2].Value = 1;
                result |= IsUnder17(aces[2], sum + aces[0].Value + aces[1].Value + aces[2].Value);
                aces[0].Value = 1;
                aces[1].Value = 11;
                aces[2].Value = 11;
                result |= IsUnder17(aces[2], sum + aces[0].Value + aces[1].Value + aces[2].Value);
                aces[0].Value = 11;
                aces[1].Value = 1;
                aces[2].Value = 1;
                result |= IsUnder17(aces[2], sum + aces[0].Value + aces[1].Value + aces[2].Value);
                aces[0].Value = 11;
                aces[1].Value = 1;
                aces[2].Value = 11;
                result |= IsUnder17(aces[2], sum + aces[0].Value + aces[1].Value + aces[2].Value);
                aces[0].Value = 11;
                aces[1].Value = 11;
                aces[2].Value = 1;
                result |= IsUnder17(aces[2], sum + aces[0].Value + aces[1].Value + aces[2].Value);
                aces[0].Value = 11;
                aces[1].Value = 11;
                aces[2].Value = 11;
                result |= IsUnder17(aces[2], sum + aces[0].Value + aces[1].Value + aces[2].Value);

            }

            return result;
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
        public bool IsUnder17(Card ace, int sum)
        {
            int possibleSum = sum + ace.Value;
            if (possibleSum < 17)
                return true;
            else
            {
                ace.Value = 1;
                possibleSum = sum + ace.Value;
                if (possibleSum < 17)
                    return true;
            }
            return false;
        }
        public void ShowHiddenCards()
        {
            for(var i =0; i <HiddenCards.Count; i++) {
                Card card = HiddenCards[i];
                hiddenCard.Remove(card);
                CollectionChanged?.Invoke(this.HiddenCards, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, card));
                RevealedCards.Add(card);
                CollectionChanged?.Invoke(this.RevealedCards, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, card));
            }
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
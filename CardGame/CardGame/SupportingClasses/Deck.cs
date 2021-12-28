using System;
using System.Collections.Generic;
namespace CardGame.SupportClasses
{
    public class Deck
    {
        public Deck()
        {
            CardsList = new List<Card>();
            Cards = new Queue<Card>();
            GetColdDeck();
            Shuffle();
            EnqueueCards();
        }
        private List<Card> CardsList { get; set; }
        public Queue<Card> Cards { get; private set; }
        /// <summary> Initializes a cold deck of colds sorted by suit and face</summary>
        private void GetColdDeck()
        {
            foreach (Suits suit in Enum.GetValues(typeof(Suits)))
            {
                foreach (Faces face in Enum.GetValues(typeof(Faces)))
                {
                    CardsList.Add(new Card(face, suit));
                }
            }
        }
        /// <summary> Shuffles the list of cards  </summary>
        private void Shuffle()
        {
            Random random = new Random();
            for (int i = 0; i < CardsList.Count; i++)
            {
                int randomIndex = random.Next(0, CardsList.Count);
                Card card = CardsList[i];
                CardsList[i] = CardsList[randomIndex];
                CardsList[randomIndex] = card;
            }
        }
        /// <summary> Enqueues each card in the list of cards</summary>
        private void EnqueueCards()
        {
            foreach (Card card in CardsList)
                Cards.Enqueue(card);
            CardsList.Clear();
        }
    }
}
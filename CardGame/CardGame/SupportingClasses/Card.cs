using System;
using System.Windows.Media.Imaging;
namespace CardGame.SupportClasses
{
    public class Card
    {
        private int value;
        private readonly char symbol;
        private readonly Faces face;
        private readonly Suits suit;
        private readonly BitmapImage front;
        private BitmapImage back;
        public Card(Faces face, Suits suit)
        {
            this.face = face;
            this.suit = suit;
            switch (Suit)
            {
                case Suits.Spade:
                    symbol = '♠';
                    switch (Face)
                    {
                        case Faces.Ace:
                            Value = 11;
                            front = new BitmapImage(new Uri("/CardGame;component/Images/Card/Spade/A.png", UriKind.RelativeOrAbsolute));
                            back = new BitmapImage(new Uri("/CardGame;component/Images/Card/Spade/S.png", UriKind.RelativeOrAbsolute));
                            break;
                        case Faces.Two:
                            Value = 2;
                            front = new BitmapImage(new Uri("/CardGame;component/Images/Card/Spade/2.png", UriKind.RelativeOrAbsolute));
                            back = new BitmapImage(new Uri("/CardGame;component/Images/Card/Spade/S.png", UriKind.RelativeOrAbsolute));
                            break;
                        case Faces.Three:
                            Value = 3;
                            front = new BitmapImage(new Uri("/CardGame;component/Images/Card/Spade/3.png", UriKind.RelativeOrAbsolute));
                            back = new BitmapImage(new Uri("/CardGame;component/Images/Card/Spade/S.png", UriKind.RelativeOrAbsolute));
                            break;
                        case Faces.Four:
                            Value = 4;
                            front = new BitmapImage(new Uri("/CardGame;component/Images/Card/Spade/4.png", UriKind.RelativeOrAbsolute));
                            back = new BitmapImage(new Uri("/CardGame;component/Images/Card/Spade/S.png", UriKind.RelativeOrAbsolute));
                            break;
                        case Faces.Five:
                            Value = 5;
                            front = new BitmapImage(new Uri("/CardGame;component/Images/Card/Spade/5.png", UriKind.RelativeOrAbsolute));
                            back = new BitmapImage(new Uri("/CardGame;component/Images/Card/Spade/S.png", UriKind.RelativeOrAbsolute));
                            break;
                        case Faces.Six:
                            Value = 6;
                            front = new BitmapImage(new Uri("/CardGame;component/Images/Card/Spade/6.png", UriKind.RelativeOrAbsolute));
                            back = new BitmapImage(new Uri("/CardGame;component/Images/Card/Spade/S.png", UriKind.RelativeOrAbsolute));
                            break;
                        case Faces.Seven:
                            Value = 7;
                            front = new BitmapImage(new Uri("/CardGame;component/Images/Card/Spade/7.png", UriKind.RelativeOrAbsolute));
                            back = new BitmapImage(new Uri("/CardGame;component/Images/Card/Spade/S.png", UriKind.RelativeOrAbsolute));
                            break;
                        case Faces.Eight:
                            Value = 8;
                            front = new BitmapImage(new Uri("/CardGame;component/Images/Card/Spade/8.png", UriKind.RelativeOrAbsolute));
                            back = new BitmapImage(new Uri("/CardGame;component/Images/Card/Spade/S.png", UriKind.RelativeOrAbsolute));
                            break;
                        case Faces.Nine:
                            Value = 9;
                            front = new BitmapImage(new Uri("/CardGame;component/Images/Card/Spade/9.png", UriKind.RelativeOrAbsolute));
                            back = new BitmapImage(new Uri("/CardGame;component/Images/Card/Spade/S.png", UriKind.RelativeOrAbsolute));
                            break;
                        case Faces.Ten:
                            Value = 10;
                            front = new BitmapImage(new Uri("/CardGame;component/Images/Card/Spade/10.png", UriKind.RelativeOrAbsolute));
                            back = new BitmapImage(new Uri("/CardGame;component/Images/Card/Spade/S.png", UriKind.RelativeOrAbsolute));
                            break;
                        case Faces.Jack:
                            Value = 10;
                            front = new BitmapImage(new Uri("/CardGame;component/Images/Card/Spade/J.png", UriKind.RelativeOrAbsolute));
                            back = new BitmapImage(new Uri("/CardGame;component/Images/Card/Spade/S.png", UriKind.RelativeOrAbsolute));
                            break;
                        case Faces.Queen:
                            Value = 10;
                            front = new BitmapImage(new Uri("/CardGame;component/Images/Card/Spade/Q.png", UriKind.RelativeOrAbsolute));
                            back = new BitmapImage(new Uri("/CardGame;component/Images/Card/Spade/S.png", UriKind.RelativeOrAbsolute));
                            break;
                        case Faces.King:
                            Value = 10;
                            front = new BitmapImage(new Uri("/CardGame;component/Images/Card/Spade/K.png", UriKind.RelativeOrAbsolute));
                            back = new BitmapImage(new Uri("/CardGame;component/Images/Card/Spade/S.png", UriKind.RelativeOrAbsolute));
                            break;
                    }
                    break;
                case Suits.Club:
                    symbol = '♣';
                    switch (Face)
                    {
                        case Faces.Ace:
                            Value = 11;
                            front = new BitmapImage(new Uri("/CardGame;component/Images/Card/Club/A.png", UriKind.RelativeOrAbsolute));
                            back = new BitmapImage(new Uri("/CardGame;component/Images/Card/Club/S.png", UriKind.RelativeOrAbsolute));
                            break;
                        case Faces.Two:
                            Value = 2;
                            front = new BitmapImage(new Uri("/CardGame;component/Images/Card/Club/2.png", UriKind.RelativeOrAbsolute));
                            back = new BitmapImage(new Uri("/CardGame;component/Images/Card/Club/S.png", UriKind.RelativeOrAbsolute));
                            break;
                        case Faces.Three:
                            Value = 3;
                            front = new BitmapImage(new Uri("/CardGame;component/Images/Card/Club/3.png", UriKind.RelativeOrAbsolute));
                            back = new BitmapImage(new Uri("/CardGame;component/Images/Card/Club/S.png", UriKind.RelativeOrAbsolute));
                            break;
                        case Faces.Four:
                            Value = 4;
                            front = new BitmapImage(new Uri("/CardGame;component/Images/Card/Club/4.png", UriKind.RelativeOrAbsolute));
                            back = new BitmapImage(new Uri("/CardGame;component/Images/Card/Club/S.png", UriKind.RelativeOrAbsolute));
                            break;
                        case Faces.Five:
                            Value = 5;
                            front = new BitmapImage(new Uri("/CardGame;component/Images/Card/Club/5.png", UriKind.RelativeOrAbsolute));
                            back = new BitmapImage(new Uri("/CardGame;component/Images/Card/Club/S.png", UriKind.RelativeOrAbsolute));
                            break;
                        case Faces.Six:
                            Value = 6;
                            front = new BitmapImage(new Uri("/CardGame;component/Images/Card/Club/6.png", UriKind.RelativeOrAbsolute));
                            back = new BitmapImage(new Uri("/CardGame;component/Images/Card/Club/S.png", UriKind.RelativeOrAbsolute));
                            break;
                        case Faces.Seven:
                            Value = 7;
                            front = new BitmapImage(new Uri("/CardGame;component/Images/Card/Club/7.png", UriKind.RelativeOrAbsolute));
                            back = new BitmapImage(new Uri("/CardGame;component/Images/Card/Club/S.png", UriKind.RelativeOrAbsolute));
                            break;
                        case Faces.Eight:
                            Value = 8;
                            front = new BitmapImage(new Uri("/CardGame;component/Images/Card/Club/8.png", UriKind.RelativeOrAbsolute));
                            back = new BitmapImage(new Uri("/CardGame;component/Images/Card/Club/S.png", UriKind.RelativeOrAbsolute));
                            break;
                        case Faces.Nine:
                            Value = 9;
                            front = new BitmapImage(new Uri("/CardGame;component/Images/Card/Club/9.png", UriKind.RelativeOrAbsolute));
                            back = new BitmapImage(new Uri("/CardGame;component/Images/Card/Club/S.png", UriKind.RelativeOrAbsolute));
                            break;
                        case Faces.Ten:
                            Value = 10;
                            front = new BitmapImage(new Uri("/CardGame;component/Images/Card/Club/10.png", UriKind.RelativeOrAbsolute));
                            back = new BitmapImage(new Uri("/CardGame;component/Images/Card/Club/S.png", UriKind.RelativeOrAbsolute));
                            break;
                        case Faces.Jack:
                            Value = 10;
                            front = new BitmapImage(new Uri("/CardGame;component/Images/Card/Club/J.png", UriKind.RelativeOrAbsolute));
                            back = new BitmapImage(new Uri("/CardGame;component/Images/Card/Club/S.png", UriKind.RelativeOrAbsolute));
                            break;
                        case Faces.Queen:
                            Value = 10;
                            front = new BitmapImage(new Uri("/CardGame;component/Images/Card/Club/Q.png", UriKind.RelativeOrAbsolute));
                            back = new BitmapImage(new Uri("/CardGame;component/Images/Card/Club/S.png", UriKind.RelativeOrAbsolute));
                            break;
                        case Faces.King:
                            Value = 10;
                            front = new BitmapImage(new Uri("/CardGame;component/Images/Card/Club/K.png", UriKind.RelativeOrAbsolute));
                            back = new BitmapImage(new Uri("/CardGame;component/Images/Card/Club/S.png", UriKind.RelativeOrAbsolute));
                            break;
                    }
                    break;
                case Suits.Heart:
                    symbol = '♥';
                    switch (Face)
                    {
                        case Faces.Ace:
                            Value = 11;
                            front = new BitmapImage(new Uri("/CardGame;component/Images/Card/Heart/A.png", UriKind.RelativeOrAbsolute));
                            back = new BitmapImage(new Uri("/CardGame;component/Images/Card/Heart/S.png", UriKind.RelativeOrAbsolute));
                            break;
                        case Faces.Two:
                            Value = 2;
                            front = new BitmapImage(new Uri("/CardGame;component/Images/Card/Heart/2.png", UriKind.RelativeOrAbsolute));
                            back = new BitmapImage(new Uri("/CardGame;component/Images/Card/Heart/S.png", UriKind.RelativeOrAbsolute));
                            break;
                        case Faces.Three:
                            Value = 3;
                            front = new BitmapImage(new Uri("/CardGame;component/Images/Card/Heart/3.png", UriKind.RelativeOrAbsolute));
                            back = new BitmapImage(new Uri("/CardGame;component/Images/Card/Heart/S.png", UriKind.RelativeOrAbsolute));
                            break;
                        case Faces.Four:
                            Value = 4;
                            front = new BitmapImage(new Uri("/CardGame;component/Images/Card/Heart/4.png", UriKind.RelativeOrAbsolute));
                            back = new BitmapImage(new Uri("/CardGame;component/Images/Card/Heart/S.png", UriKind.RelativeOrAbsolute));
                            break;
                        case Faces.Five:
                            Value = 5;
                            front = new BitmapImage(new Uri("/CardGame;component/Images/Card/Heart/5.png", UriKind.RelativeOrAbsolute));
                            back = new BitmapImage(new Uri("/CardGame;component/Images/Card/Heart/S.png", UriKind.RelativeOrAbsolute));
                            break;
                        case Faces.Six:
                            Value = 6;
                            front = new BitmapImage(new Uri("/CardGame;component/Images/Card/Heart/6.png", UriKind.RelativeOrAbsolute));
                            back = new BitmapImage(new Uri("/CardGame;component/Images/Card/Heart/S.png", UriKind.RelativeOrAbsolute));
                            break;
                        case Faces.Seven:
                            Value = 7;
                            front = new BitmapImage(new Uri("/CardGame;component/Images/Card/Heart/7.png", UriKind.RelativeOrAbsolute));
                            back = new BitmapImage(new Uri("/CardGame;component/Images/Card/Heart/S.png", UriKind.RelativeOrAbsolute));
                            break;
                        case Faces.Eight:
                            Value = 8;
                            front = new BitmapImage(new Uri("/CardGame;component/Images/Card/Heart/8.png", UriKind.RelativeOrAbsolute));
                            back = new BitmapImage(new Uri("/CardGame;component/Images/Card/Heart/S.png", UriKind.RelativeOrAbsolute));
                            break;
                        case Faces.Nine:
                            Value = 9;
                            front = new BitmapImage(new Uri("/CardGame;component/Images/Card/Heart/9.png", UriKind.RelativeOrAbsolute));
                            back = new BitmapImage(new Uri("/CardGame;component/Images/Card/Heart/S.png", UriKind.RelativeOrAbsolute));
                            break;
                        case Faces.Ten:
                            Value = 10;
                            front = new BitmapImage(new Uri("/CardGame;component/Images/Card/Heart/10.png", UriKind.RelativeOrAbsolute));
                            back = new BitmapImage(new Uri("/CardGame;component/Images/Card/Heart/S.png", UriKind.RelativeOrAbsolute));
                            break;
                        case Faces.Jack:
                            Value = 10;
                            front = new BitmapImage(new Uri("/CardGame;component/Images/Card/Heart/J.png", UriKind.RelativeOrAbsolute));
                            back = new BitmapImage(new Uri("/CardGame;component/Images/Card/Heart/S.png", UriKind.RelativeOrAbsolute));
                            break;
                        case Faces.Queen:
                            Value = 10;
                            front = new BitmapImage(new Uri("/CardGame;component/Images/Card/Heart/Q.png", UriKind.RelativeOrAbsolute));
                            back = new BitmapImage(new Uri("/CardGame;component/Images/Card/Heart/S.png", UriKind.RelativeOrAbsolute));
                            break;
                        case Faces.King:
                            Value = 10;
                            front = new BitmapImage(new Uri("/CardGame;component/Images/Card/Heart/K.png", UriKind.RelativeOrAbsolute));
                            back = new BitmapImage(new Uri("/CardGame;component/Images/Card/Heart/S.png", UriKind.RelativeOrAbsolute));
                            break;
                    }
                    break;
                case Suits.Diamond:
                    symbol = '♦';
                    switch (Face)
                    {
                        case Faces.Ace:
                            Value = 11;
                            front = new BitmapImage(new Uri("/CardGame;component/Images/Card/Diamond/A.png", UriKind.RelativeOrAbsolute));
                            back = new BitmapImage(new Uri("/CardGame;component/Images/Card/Diamond/S.png", UriKind.RelativeOrAbsolute));
                            break;
                        case Faces.Two:
                            Value = 2;
                            front = new BitmapImage(new Uri("/CardGame;component/Images/Card/Diamond/2.png", UriKind.RelativeOrAbsolute));
                            back = new BitmapImage(new Uri("/CardGame;component/Images/Card/Diamond/S.png", UriKind.RelativeOrAbsolute));
                            break;
                        case Faces.Three:
                            Value = 3;
                            front = new BitmapImage(new Uri("/CardGame;component/Images/Card/Diamond/3.png", UriKind.RelativeOrAbsolute));
                            back = new BitmapImage(new Uri("/CardGame;component/Images/Card/Diamond/S.png", UriKind.RelativeOrAbsolute));
                            break;
                        case Faces.Four:
                            Value = 4;
                            front = new BitmapImage(new Uri("/CardGame;component/Images/Card/Diamond/4.png", UriKind.RelativeOrAbsolute));
                            back = new BitmapImage(new Uri("/CardGame;component/Images/Card/Diamond/S.png", UriKind.RelativeOrAbsolute));
                            break;
                        case Faces.Five:
                            Value = 5;
                            front = new BitmapImage(new Uri("/CardGame;component/Images/Card/Diamond/5.png", UriKind.RelativeOrAbsolute));
                            back = new BitmapImage(new Uri("/CardGame;component/Images/Card/Diamond/S.png", UriKind.RelativeOrAbsolute));
                            break;
                        case Faces.Six:
                            Value = 6;
                            front = new BitmapImage(new Uri("/CardGame;component/Images/Card/Diamond/6.png", UriKind.RelativeOrAbsolute));
                            back = new BitmapImage(new Uri("/CardGame;component/Images/Card/Diamond/S.png", UriKind.RelativeOrAbsolute));
                            break;
                        case Faces.Seven:
                            Value = 7;
                            front = new BitmapImage(new Uri("/CardGame;component/Images/Card/Diamond/7.png", UriKind.RelativeOrAbsolute));
                            back = new BitmapImage(new Uri("/CardGame;component/Images/Card/Diamond/S.png", UriKind.RelativeOrAbsolute));
                            break;
                        case Faces.Eight:
                            Value = 8;
                            front = new BitmapImage(new Uri("/CardGame;component/Images/Card/Diamond/8.png", UriKind.RelativeOrAbsolute));
                            back = new BitmapImage(new Uri("/CardGame;component/Images/Card/Diamond/S.png", UriKind.RelativeOrAbsolute));
                            break;
                        case Faces.Nine:
                            Value = 9;
                            front = new BitmapImage(new Uri("/CardGame;component/Images/Card/Diamond/9.png", UriKind.RelativeOrAbsolute));
                            back = new BitmapImage(new Uri("/CardGame;component/Images/Card/Diamond/S.png", UriKind.RelativeOrAbsolute));
                            break;
                        case Faces.Ten:
                            Value = 10;
                            front = new BitmapImage(new Uri("/CardGame;component/Images/Card/Diamond/10.png", UriKind.RelativeOrAbsolute));
                            back = new BitmapImage(new Uri("/CardGame;component/Images/Card/Diamond/S.png", UriKind.RelativeOrAbsolute));
                            break;
                        case Faces.Jack:
                            Value = 10;
                            front = new BitmapImage(new Uri("/CardGame;component/Images/Card/Diamond/J.png", UriKind.RelativeOrAbsolute));
                            back = new BitmapImage(new Uri("/CardGame;component/Images/Card/Diamond/S.png", UriKind.RelativeOrAbsolute));
                            break;
                        case Faces.Queen:
                            Value = 10;
                            front = new BitmapImage(new Uri("/CardGame;component/Images/Card/Diamond/Q.png", UriKind.RelativeOrAbsolute));
                            back = new BitmapImage(new Uri("/CardGame;component/Images/Card/Diamond/S.png", UriKind.RelativeOrAbsolute));
                            break;
                        case Faces.King:
                            Value = 10;
                            front = new BitmapImage(new Uri("/CardGame;component/Images/Card/Diamond/K.png", UriKind.RelativeOrAbsolute));
                            back = new BitmapImage(new Uri("/CardGame;component/Images/Card/Diamond/S.png", UriKind.RelativeOrAbsolute));
                            break;
                    }
                    break;
            }
        }
        public BitmapImage Front { get { return front; } }
        public BitmapImage Back { get { return back; } set { back = value; } }
        public char Symbol { get { return symbol; } }
        public int Value { get { return value; } set { this.value = value; } }
        public Faces Face { get { return face; } }
        public Suits Suit { get { return suit; } }
    }
}
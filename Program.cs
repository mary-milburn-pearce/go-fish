using System;
using System.Text;
using System.Collections.Generic;

namespace GoFish
{
    class Card
    {
        public Card (string suit, string stringVal, int val) {
            StringVal = stringVal;
            Suit = suit;
            Val = val;
        }
        public string StringVal { get; }
        public string Suit { get; }
        public int Val {get; }
        public string shortName(bool mask) {
            if (mask) return "*:*";
            string ab = Suit.Substring(0,1) + ":";
            if (Val > 1 && Val < 10) {
                ab += Val.ToString();
            } else {
                ab += StringVal.Substring(0,1);
            }
            return ab;
        }
        public void Show() {
            System.Console.WriteLine($"{StringVal} of {Suit}");
        }
    }
    class Deck 
    {
        string[] suits = {"hearts", "diamonds", "clubs", "spades"};
        Dictionary<int, string> vals = new Dictionary<int, string>() {
            { 1, "ace" }, { 2, "two" }, { 3, "three" }, { 4, "four" },
            { 5, "five" }, { 6, "six" }, { 7, "seven" }, { 8, "eight" },
            { 9, "nine" }, { 10, "ten" }, { 11, "jack" }, { 12, "queen" },
            { 13, "king" } 
        };
        List<Card> cards;
        public Deck(){
            Reset();
        }
        public void Reset(){
            cards = new List<Card>();
            for (int s=0; s<suits.Length; s++) {
                for (int n=1; n <= 13; n++) {
                    cards.Add(new Card(suits[s], vals[n], n));
                }
            }
        }
        public void Shuffle() {
            // Credit: https://bost.ocks.org/mike/shuffle/
            List<Card> newCards = new List<Card>();
            int i, n = cards.Count;
            Random rand = new Random();
            while (n>0) {
                i = rand.Next(n--);
                newCards.Add(cards[i]);
                cards.RemoveAt(i);
            }
            cards = newCards;
        }
        public Card dealCard() {
            Card card = this.cards[0];
            cards.RemoveAt(0);
            card.Show();
            return (card);
        }
        public void Show() {
            foreach (Card card in cards) {
                card.Show();
            }
        }
    }
    class Player {
        public string Name {set; get;}
        public int Position {set; get;}
        public Hand hand = new Hand();

        public Player (string name, Deck deck, int handSize)
        {
            Name = name;
            System.Console.WriteLine($"***** Player: {Name} *****");
            for (int i = 1; i <= handSize; i++) {
                drawCard(deck);
            }
        }
        public void drawCard(Deck deck)
        {
            Card card = deck.dealCard();
            hand.addCard(card);
        }
        public Card discard(int index) {
            Card card = null;
            if (index < hand.cardCount()) {
                card = hand.discardAt(index);
                Console.WriteLine($"{Name} has discarded the {card.StringVal} of {card.Suit}.");
            } else {
                Console.WriteLine($"{Name} does not have a card at that index.");
            }
            return card;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            System.Console.WriteLine(game.myNum);
            Deck deck = new Deck();
            deck.Shuffle();
            //deck.Show();
            Player bob = new Player("Bob", deck, 5);
            Player jim = new Player("Jim", deck, 5);
            Player jan = new Player("Jan", deck, 5);
            bob.discard(3);
            jim.discard(1);

        }
    }
}
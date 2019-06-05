using System;
using System.Text;
using System.Collections.Generic;

namespace GoFish
{
    public interface IDisplayable
    {
        void Render(char[] screenMap, int sRow, int sCol, int rows, int cols);
    }
    class Table : IDisplayable{
        public void Render(char[] map, int sRow, int sCol, int rows, int cols)
        {

        } 
    }
    class Hand : IDisplayable{
        public List<Card> cards;
        public Hand () {
            cards = new List<Card>();
        }
        public void Render(char[] map, int sRow, int sCol, int rows, int cols){
        }
        public void addCard(Card card) {
            cards.Add(card);
        }
        public Card discardAt(int Index){
            Card card = cards[Index];
            cards.RemoveAt(Index);
            return card;
        }
        public int cardCount(){
            return cards.Count;
        }
    }
    class cardSets : IDisplayable{
        public List<string> sets = new List<string>();
        public void Render(char[] map, int sRow, int sCol, int rows, int cols){

        }
        public void addSet(Card card) {
            //pass in any suit of the foursome
            sets.Add(card.shortName(false).Substring(2,1) + "s");
        }        
    }
    class Screen{
        const int ht = 40;
        const int wt = 120;
        private char[,] map = new char[ht,wt];
        public void blankMap () {
            for (int i=0; i<ht; i++) {
                for (int j=0; j<wt; j++) {
                    map[ht, wt] = ' ';
                }
            }
        }
        public void displayMap() {
            StringBuilder sb = new StringBuilder();
            for (int i=0; i<ht; i++) {
                sb.Clear();
                for (int j=0; j<wt; j++) {
                    sb.Append(map[ht,wt]);
                }
                Console.WriteLine(sb.ToString());
            }
        }
    }
}

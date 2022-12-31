using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card
{
    
    public int palo;
    public int num;
    public int cardID;
    public int hierarchy;
    public Card(int n, int p)
    {
        palo = p;
        num = n;
    }
    public Card(int n)
    {
        cardID = n;
        palo = n - (n % 10);
        palo /= 10;
        num = n - palo*10;
    }
    public int IsPieza()
    {
        if(palo == GlobalVariables.muestra.palo)
        {
            if(num == 1 || num == 2 || num == 4 || num == 7 || num == 8)
            {
                return Mathf.Abs(num-10);
            }
        }
        return 0;
    }
    public int IsMata()
    {
        if(num == 0)
        {
            if(palo == 2)
                return 14;
            if(palo == 3)
                return 13;
        }
        if(num == 6)
        {
            if(palo == 2)
                return 12;
            if(palo == 0)
                return 11;
        }
        return 0;
    }
    
}

public class CardStack
{
    Card[] cards = new Card[40];

    int counter = 0;

    public void Push(Card c)
    {
        cards[counter] = c;
        counter++;
    }
    public Card Pop()
    {
        counter--;
        return cards[counter];
    }
    /*public Card Peek()
    {
        return cards[counter - 1];
    }*/
    public bool Check()
    {
        if(counter >= cards.Length)
        {
            return false;
        }
        return true;
    }
}


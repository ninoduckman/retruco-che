using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    int player;
    public DealingManager dm;
    public SpriteRenderer[] cards = new SpriteRenderer[3];
    public SpriteRenderer muestraRenderer;
    public Sprite[] cardSprites = new Sprite[42];

    private void FixedUpdate() {
        if(dm.dealed == false)
            return;
        for(int i = 0; i < 3; i++)
        {
            cards[i].sprite = cardSprites[GlobalVariables.players[player,i].cardID];
        }
        if(checkFlor(GlobalVariables.players))
        {
            Debug.Log("flor");
        }
        Muestra();

    }

    void Muestra()
    {
        muestraRenderer.sprite = cardSprites[GlobalVariables.muestra.cardID];
    }

    bool checkFlor(Card[,] mano)
    {
        int piezas = 0;
        bool juego = true;
        for (int i = 0; i<3; i++)
        {
            if (mano[player,i].IsPieza() > 0)
                piezas++;
            else
            {
                if (mano[player,i].palo != mano[player,0].palo)
                    juego=false;
            }
        }
        if (piezas > 1 || juego)
        {
            return true;
        }
        else
            return false;
    }
}

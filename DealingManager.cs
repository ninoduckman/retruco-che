using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalVariables
{
    public static Card muestra;
    public static int playerNum = 2;
    public static Card[,] players = new Card[playerNum,3];
}
public class DealingManager : MonoBehaviour
{

    CardStack mazo = new CardStack();

    public bool deal;
    public bool dealed = false;

    private void Start() {
        FillAndShuffle();
    }

    private void Update() {
        if(deal)
        {
            Deal();
            deal = false;
            dealed = true;
        }
    }
    
    public void FillAndShuffle()
    {
        List<int> used = new List<int>(new int[40]);
        for(int i = 0; i < used.Count; i++)
        {
            used[i] = i;
        }
        bool[] mazoActual = new bool[40];
        int safe = 0;
        while(mazo.Check() && safe < 100)
        {
            safe++;
            if(safe == 100)
                Debug.Log("ran out");
            int randomCard = Random.Range(0,used.Count);
            int card = used[randomCard];
            used.Remove(used[randomCard]);
            mazoActual[card] = true;
            mazo.Push(new Card(card));
            //Debug.Log(card);
        }
    }

    void Deal()
    {
        for(int j = 0; j < 3; j++)
        {
            for(int i = 0; i < GlobalVariables.playerNum; i++)
            {
                GlobalVariables.players[i,j] = mazo.Pop();
            }
        }
        Muestra();
        Debug.Log(GlobalVariables.players[0,0].palo +" "+ GlobalVariables.players[0,0].num );
        Debug.Log(GlobalVariables.players[0,1].palo +" "+ GlobalVariables.players[0,1].num );
        Debug.Log(GlobalVariables.players[0,2].palo +" "+ GlobalVariables.players[0,2].num );
    }
    void Muestra()
    {
        GlobalVariables.muestra = mazo.Pop();
    }

}

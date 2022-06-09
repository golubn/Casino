using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Balance : MonoBehaviour
{

    public Text textforbalance, textforbet;
    public decimal allBalance = 0;
    public decimal bet = 5;
    Game game = new Game();

    decimal AllBalance
    {
        get { return allBalance; }
        set { allBalance = value; }
    }
    decimal Bet
    {
        get { return bet; }
        set { bet = value; }
    }
    void Start()
    {
        textforbalance = GameObject.Find("TextBalance").GetComponent<Text>();
        textforbet = GameObject.Find("TextBet").GetComponent<Text>();
    }

    public static void Win(int? x, int? y, int? z)
    {
        decimal balance = Connection.GetBalance("maks");
        if (balance == null)
        {
            Debug.Log("balance null");
        }
        else
        {
            if (x == y && y == z)
            {
                Connection.UpdateBalance(balance, 5, true, "maks");
                Connection.CloseBd();
            }
            else
            {
                Connection.UpdateBalance(balance, 5, false, "maks");
                Connection.CloseBd();
            }
        }

    }
    public void Click()
    {

        decimal balance = Connection.GetBalance("maks");
        Debug.Log(balance);
        textforbalance.text = balance.ToString();
        textforbet.text = Bet.ToString();

    }
}

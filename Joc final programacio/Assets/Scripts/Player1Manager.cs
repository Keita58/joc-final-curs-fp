using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;

public class Player1Manager : MonoBehaviour
{
    // Start is called before the first frame update
    private Player1Manager() { }
    private static Player1Manager instance;
    private int money = 20;
    public static Player1Manager getInstance()
    {
        if (instance == null)
        {
            instance = new Player1Manager();
        }
        return instance;
    }
    public int getMoney()
    {
        return money;
    }
    public void setMoney(int money)
    {
        this.money += money;
    }
}

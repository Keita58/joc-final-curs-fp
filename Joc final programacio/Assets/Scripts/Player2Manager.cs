using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;

public class Player2Manager : MonoBehaviour
{
    // Start is called before the first frame update
    private Player2Manager() { }
    private static Player2Manager instance;
    private int money = 20;
    public static Player2Manager getInstance()
    {
        if (instance == null)
        {
            instance = new Player2Manager();
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

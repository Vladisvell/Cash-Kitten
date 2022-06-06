using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoneyScript : MonoBehaviour
{
    public Player Player;
    public TextMeshProUGUI moneyDisplay;
    // Start is called before the first frame update
    void Start()
    {
        Player.Money = 100;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMoney();
    }

    public void AddMoney(int count)
    {
        Player.Money += count;
        UpdateMoney();
    }

    public void SubstractMoney(int count)
    {
        if (Player.Money >= count)
            Player.Money -= count;
        else
            Debug.Log("Not enough money to perfom this operation!");
        UpdateMoney();
    }

    void UpdateMoney()
    {
        moneyDisplay.text = Player.Money.ToString();
    }
}

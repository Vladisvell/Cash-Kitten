using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player : MonoBehaviour
{
    public int Money;
    public int Profit = 0;
    public int Deficit = 0;
    public string Name;

    public void AddMoney(int count)
    {
        Money += count;
    }

    public void RemoveMoney(int count)
    {
        if (HasEnoughMoneyToPerfomOperation(count))
            Money -= count;
    }

    public void MoneyTick()
    {
        Money += Profit - Deficit;
    }

    public void AddProfit(int count)
    {
        Profit += count;
    }
    public void AddDeficit(int count)
    {
        Deficit += count;
    }

    public void BuyWorker(WorkerType type)
    {
        if (type == WorkerType.Cat && HasEnoughMoneyToPerfomOperation(100))
        {
            RemoveMoney(100);
            AddProfit(10);
        }
    }

    public void BuyCat() => BuyWorker(WorkerType.Cat); 

    public bool HasEnoughMoneyToPerfomOperation(int count)
    {
        if (Money >= count)
            return true;
        return false;
    }

    [System.Serializable]
    public enum WorkerType
    {
        None,
        Cat,
        MegaCat,
        SuperCat
    }

    public struct Worker
    {
        public int Cost;
        public int Profit;
    }
}

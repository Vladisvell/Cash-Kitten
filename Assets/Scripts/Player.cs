using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class Player : MonoBehaviour
{
    public int Money;
    public int Profit = 0;
    public int Deficit = 0;
    public string Name;
    public int CatEmployees = 0;
    public int Worktables = 1;
    public int CanHire = 10;
    public TextMeshProUGUI catEmployers;
    public TextMeshProUGUI catUpkeep;
    public TextMeshProUGUI worktablesInfo;
    public TextMeshProUGUI canHireInfo;

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
        if (type == WorkerType.Cat && HasEnoughMoneyToPerfomOperation(100) && CatEmployees < Worktables * 10)
        {
            RemoveMoney(100);
            AddProfit(10);
            AddDeficit(2);
            CatEmployees++;
            catEmployers.text = "Котов: " + CatEmployees.ToString();
            catUpkeep.text = "Содержание: " + CatEmployees * 2;
            CanHire -= 1;
            canHireInfo.text = "Можно нанять: " + CanHire;
        }
        if (type == WorkerType.Worktable && HasEnoughMoneyToPerfomOperation(1000))
        {
            RemoveMoney(1000);
            CanHire += 10;
            Worktables++;
            worktablesInfo.text = "Оборудования: " + Worktables;
            canHireInfo.text = "Можно нанять: " + CanHire;
        }
    }

    public void BuyCat() => BuyWorker(WorkerType.Cat);
    public void BuyWorkTable() => BuyWorker(WorkerType.Worktable);

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
        Worktable,
    }

    public struct Worker
    {
        public int Cost;
        public int Profit;
    }
}

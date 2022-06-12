using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeScript : MonoBehaviour
{
    int days = 0;
    bool isPaused;
    bool isStarted;
    //TextMeshPro time;
    public TextMeshProUGUI Time;
    public TextMeshProUGUI Profits;
    public TextMeshProUGUI NonProfits;
    public Player Player;
    public EventDialogueHandler eventDisplay;
    public Dictionary<int, Event> events = new Dictionary<int, Event>(20);
    public List<Event> dayEvents = new List<Event>(20);
    public float timeSpeed = 1;
    

    private void Start()
    {
        foreach (var ev in dayEvents)
        {
            ev.IsActive = ev.defaultState;
            events.Add(ev.DayToAppear, ev);
        }
        timeSpeed = 1;
        StartTimer();
    }

    public void AddCreditEvent(Event ev)
    {
        int appday = days + 14;
        if (events.ContainsKey(appday))
            appday++;
        else
            events.Add(appday, ev);
    }

    public void SetDay(int day)
    {
        days = day;
    }

    void TimeUpdate()
    {
        if (isPaused)
            return;
        days++;
        Player.day = days;
        UpdateStatistics();
        EconomicsUpdate();
        CycleEvents();
    }

    void EconomicsUpdate()
    {
        Player.Money += (Player.Profit - Player.Deficit);
    }

    void UpdateStatistics()
    {
        Time.text = "День " + days.ToString();
        Profits.text = ShowProfits();
        NonProfits.text = ShowNonProfits();
    }

    void CycleEvents()
    {
        if(events.ContainsKey(days))
            if(events[days].IsActive)
            eventDisplay.Assign(events[days]);
    }

    public void StartTimer()
    {
        isPaused = false;
        if (!isStarted)
        {
            InvokeRepeating("TimeUpdate", 0, timeSpeed);
            isStarted = true;
        }
           

    }

    public void PauseTimer() => isPaused = true;
    public void ResumeTimer() => isPaused = false;

    public string ShowProfits()
    {
        return "Доход: " + Player.Profit.ToString();
    }

    public string ShowNonProfits()
    {
        return "Расход: " + Player.Deficit.ToString();
    }

    [System.Serializable]
    public struct DayEvent
    {
        public int day;
        public Event Event;
    }
}

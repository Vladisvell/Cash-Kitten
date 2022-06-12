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
    public Dictionary<int, Event> events = new Dictionary<int, Event>(10);
    public List<Event> dayEvents = new List<Event>(10);
    

    private void Start()
    {
        foreach (var ev in dayEvents)
        {
            ev.IsActive = ev.defaultState;
            events.Add(ev.DayToAppear, ev);
        }
            
        StartTimer();
    }

    void TimeUpdate()
    {
        if (isPaused)
            return;
        days++;
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
            InvokeRepeating("TimeUpdate", 0, 1);
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

using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


[CreateAssetMenu(fileName = "New Event", menuName = "Event")]
[System.Serializable]
public class Event : ScriptableObject
{
    public string Header;
    public string Description;
    public string ButtonDesc1;
    public string ButtonDesc2;
    public int DayToAppear;
    public Player Player;
    public bool defaultState;
    public bool IsActive;
    public Event NextEventEffect1;
    public Event NextEventEffect2;
    public List<Effect> Effects1 = new List<Effect>(3);
    public List<Effect> Effects2 = new List<Effect>(3);

    
    public virtual void Effect1()
    {
        foreach(var effect in Effects1)
        {
            if (effect.effect == EffectType.Money)
                Player.AddMoney(effect.count);
            if (effect.effect == EffectType.Profit)
                Player.AddProfit(effect.count);
            if (effect.effect == EffectType.Deficit)
                Player.AddDeficit(effect.count);
            if (effect.effect == EffectType.ActivateEvent)
                ActivateNextEvent1();
        }
    }

    public virtual void Effect2()
    {
        foreach (var effect in Effects2)
        {
            if (effect.effect == EffectType.Money)
                Player.AddMoney(effect.count);
            if (effect.effect == EffectType.Profit)
                Player.AddProfit(effect.count);
            if (effect.effect == EffectType.Deficit)
                Player.AddDeficit(effect.count);
            if (effect.effect == EffectType.ActivateEvent)
                ActivateNextEvent2();
        }
    }

    public void ActivateNextEvent1()
    {
        if(NextEventEffect1 != null)
            NextEventEffect1.IsActive = true;
    }

    public void ActivateNextEvent2()
    {
        if (NextEventEffect2 != null)
            NextEventEffect2.IsActive = true;
    }

    public enum EffectType
    {
        None,
        Money,
        Profit,
        Deficit,
        ActivateEvent
    }

    [System.Serializable]
    public struct Effect
    {
        public EffectType effect;
        public int count;
    }
}

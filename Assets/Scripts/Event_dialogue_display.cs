using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class Event_dialogue_display : MonoBehaviour
{
    public Event Event;

    public TextMeshProUGUI Header;
    public TextMeshProUGUI Body;
    public TextMeshProUGUI ButtonDesc1;
    public TextMeshProUGUI ButtonDesc2;
    public Button Button1;
    public Button Button2;

    public Player Player;

    private UnityAction m_MyFirstAction;
    private UnityAction m_MySecondAction;

    // Start is called before the first frame update
    void Start()
    {
        Event.Player = Player;
        Header.text = Event.Header;
        Body.text = Event.Description;
        ButtonDesc1.text = Event.ButtonDesc1;
        ButtonDesc2.text = Event.ButtonDesc2;
        m_MyFirstAction += () => Event.Effect1();
        m_MySecondAction += () => Event.Effect2();
        Button1.onClick.AddListener(m_MyFirstAction);
        Button2.onClick.AddListener(m_MySecondAction);
    }

}

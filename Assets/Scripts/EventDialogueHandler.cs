using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using System.Text;
using UnityEngine.Events;
using UnityEngine.UI;

public class EventDialogueHandler : MonoBehaviour
{
    public TextMeshProUGUI header;
    public TextMeshProUGUI description;
    public TextMeshProUGUI buttonDesc1;
    public TextMeshProUGUI buttonDesc2;
    Event dialogue;
    public GameObject panel;
    public Button Button1;
    public Button Button2;

    public Player Player;

    private UnityAction m_MyFirstAction;
    private UnityAction m_MySecondAction;
    private UnityAction removeListeners;

    public TimeScript timeScript;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Assign(Event dialogue)
    {
        timeScript.PauseTimer();
        Button1.onClick.RemoveAllListeners();
        Button2.onClick.RemoveAllListeners();
        this.dialogue = dialogue;
        this.dialogue.Player = Player;
        if(this.dialogue == null)
        {
            header.text = "KEKW";
            description.text = "Вас заскамиили!";
            buttonDesc1.text = "Партия отнять миска риса!";
            buttonDesc2.text = "Партия отнять кошка жена!";
        }
        else
        {
            header.text = dialogue.Header;
            description.text = dialogue.Description;
            buttonDesc1.text = dialogue.ButtonDesc1;
            buttonDesc2.text = dialogue.ButtonDesc2;
        }
        Button1.onClick.AddListener(FirstAction);
        Button2.onClick.AddListener(SecondAction);
        if (buttonDesc2.text == "")
            Button2.gameObject.SetActive(false);
        panel.SetActive(true);
    }

    void FirstAction()
    {
        panel.SetActive(false);
        dialogue.Effect1();
        timeScript.ResumeTimer();
    }

    void SecondAction()
    {
        panel.SetActive(false);
        dialogue.Effect2();
        timeScript.ResumeTimer();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public struct Ship
{
    public int weight;
    public int amount;
}

public class CtrlShipSel : MonoBehaviour
{
    public Ship[] ships;
    public static Button So4Btn, So3Btn, So2Btn, So1Btn;

    private void Awake()
    {
        So4Btn = GameObject.Find("Ship of 4").GetComponent<Button>();
        So3Btn = GameObject.Find("Ship of 3").GetComponent<Button>();
        So2Btn = GameObject.Find("Ship of 2").GetComponent<Button>();
        So1Btn = GameObject.Find("Ship of 1").GetComponent<Button>();

        So1Btn.onClick.AddListener(() => BtnDeactivator(1));
        So1Btn.onClick.AddListener(() => ShowShip());
    }
    private void Start()
    {
        ships = new Ship[4] { new Ship { weight = 4, amount = 1 }, new Ship { weight = 3, amount = 2 }, new Ship { weight = 2, amount = 3 }, new Ship { weight = 1, amount = 4 } };
        foreach (GameObject get in GetShootables.selectables)
        {
            EventTrigger eventTrigger = get.GetComponent<EventTrigger>();
            if (eventTrigger == null)
            {
                EventTrigger.Entry enterUIEntry = new EventTrigger.Entry
                {
                    eventID = EventTriggerType.PointerEnter
                };
                enterUIEntry.callback.AddListener((eventData) => { ShowShip(); });
                eventTrigger.triggers.Add(enterUIEntry);

                EventTrigger.Entry exitUIEntry = new EventTrigger.Entry
                {
                    eventID = EventTriggerType.PointerExit
                };
                exitUIEntry.callback.AddListener((eventData) => { ClearShip(); });
                eventTrigger.triggers.Add(exitUIEntry);
            }
        }
    }

    private void Update()
    {
    }

    public void BtnDeactivator(int btn)
    {
        switch (btn)
        {
            case 1:
                So1Btn.interactable = false;
                break;
        }
    }

    public void ShowShip()
    {
        GetComponent<Button>().interactable = false;
    }

    public void ClearShip()
    {
        GetComponent<Button>().interactable = true;
    }
}

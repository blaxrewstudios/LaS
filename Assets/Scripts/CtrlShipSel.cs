using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using System.IO;

public struct Ship
{
    public int weight;
    public int amount;
}

public class CtrlShipSel : MonoBehaviour
{
    public Ship[] ships;
    public static Button So4Btn, So3Btn, So2Btn, So1Btn;
    public GameObject So1, So2;
    public Transform[] anchors;
    public List<Transform> anchors_vertical2_1;
    public List<Transform> anchors_vertical2_2;
    float distance = 49.0f;
    bool rotated = false;
    public float rotation = 0;
    int ShipNow = -1;
    public Color col;

    private void Awake()
    {
        So4Btn = GameObject.Find("Ship of 4").GetComponent<Button>();
        So3Btn = GameObject.Find("Ship of 3").GetComponent<Button>();
        So2Btn = GameObject.Find("Ship of 2").GetComponent<Button>();
        So1Btn = GameObject.Find("Ship of 1").GetComponent<Button>();

        So1Btn.onClick.AddListener(() => BtnDeactivator(1));
        So2Btn.onClick.AddListener(() => BtnDeactivator(2));
    }


    private void Start()
    {
        ships = new Ship[4] { new Ship { weight = 4, amount = 1 }, new Ship { weight = 3, amount = 2 }, new Ship { weight = 2, amount = 3 }, new Ship { weight = 1, amount = 4 } };
        foreach (GameObject get in GetShootables.selectables)
        {
            get.GetComponent<Button>().onClick.AddListener(() => AddShip(get.GetComponent<Button>()));
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
        for (int a = 0; a < GetShootables.selectables.Count; a++)
        {
            anchors[a] = GetShootables.selectables[a].transform;
        }
        for (int b = 0; b < GetShootables.selectables.Count; b++)
        {
            if (!(b == 9 || b == 19 || b == 29 || b == 39 || b == 49 || b == 59 || b == 69 || b == 79 || b == 89 || b == 99))
            {
                anchors_vertical2_1.Add(GetShootables.selectables[b].transform);
            }
            else
            {
                anchors_vertical2_2.Add(GetShootables.selectables[b].transform);
            }
        }
    }

    void AddShip(Button clicked)
    {
        if (ShipNow == 1)
        {
            clicked.interactable = false;
            clicked.image.color = col;
            ships[3].amount -= 1;
            ShipNow = -1;
            Destroy(GameObject.Find("RCHObject"));
            if (ships[3].amount >= 1)
                So1Btn.interactable = true;
        }
    }

    private void Update()
    {
        if (GameObject.Find("RCHObject") != null)
        {
            Transform RCH = GameObject.Find("RCHObject").GetComponent<Transform>();
            Snap(RCH);
        }
    }

    void Snap(Transform RCH)
    {
        switch (ShipNow)
        {
            case 1:
                foreach (Transform anchor in anchors)
                {
                    if (Vector3.Distance(Input.mousePosition, anchor.position) < distance)
                    {
                        RCH.position = anchor.position;
                    }
                }
                break;
            case 2:
                if (!rotated)
                {
                    foreach (Transform anchor in anchors_vertical2_1)
                    {
                        if (Vector3.Distance(Input.mousePosition, anchor.position) < distance)
                        {
                            RCH.position = new Vector3(anchor.position.x + distance, anchor.position.y, anchor.position.z);
                        }
                    }
                    foreach (Transform anchor in anchors_vertical2_2)
                    {
                        if (Vector3.Distance(Input.mousePosition, anchor.position) < distance)
                        {
                            RCH.position = new Vector3(anchor.position.x - distance, anchor.position.y, anchor.position.z);
                        }
                    }
                }
                break;
        }
    }

    public void BtnDeactivator(int btn)
    {
        switch (btn)
        {
            case 1:
                ShipNow = 1;
                GameObject RCH = Instantiate(So1, GameObject.Find("Canvas").transform);
                RCH.name = "RCHObject";

                So1Btn.interactable = false;
                break;
            case 2:
                ShipNow = 2;
                GameObject RCH2 = Instantiate(So2, GameObject.Find("Canvas").transform);
                RCH2.name = "RCHObject";

                So2Btn.interactable = false;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GetShootables : MonoBehaviour
{
    public static List<GameObject> selectables = new List<GameObject>();

    private void Awake()
    {
        for (int letters = 0; letters < 10; letters++)
        {
            for (int numbs= 0; numbs < 10; numbs++)
            {
                char letter = ' ';
                switch (letters + 1)
                {
                    case 1:
                        letter = 'A';
                        break;
                    case 2:
                        letter = 'B';
                        break;
                    case 3:
                        letter = 'C';
                        break;
                    case 4:
                        letter = 'D';
                        break;
                    case 5:
                        letter = 'E';
                        break;
                    case 6:
                        letter = 'F';
                        break;
                    case 7:
                        letter = 'G';
                        break;
                    case 8:
                        letter = 'H';
                        break;
                    case 9:
                        letter = 'I';
                        break;
                    case 10:
                        letter = 'J';
                        break;
                }

                string sndLetterString;
                if (numbs <= 8)
                    sndLetterString = (numbs + 1).ToString();
                else
                {
                    sndLetterString = "A";
                }

                selectables.Add(GameObject.Find(letter + sndLetterString));
            }
        }
        for (int i = 0; i < selectables.Count; i++)
        {
            selectables[i].AddComponent(typeof(EventTrigger));
        }
    }
}

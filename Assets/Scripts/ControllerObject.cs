using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerObject : MonoBehaviour
{
    public GameObject FieldSelection;
    GameObject Canvas;

    private void Awake()
    {
        Canvas = GameObject.Find("Canvas");
    }

    private void Start()
    {
        Instantiate(FieldSelection, Canvas.transform);
    }
}

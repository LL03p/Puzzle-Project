using UnityEngine;
using System.Collections.Generic;

public class Level2Check : MonoBehaviour
{
    public List<GameObject> Objects;
    public List<GameObject> Hexagon;
    public GameObject Canvas;

    private bool allTrue;

    public static Level2Check Instance;

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        SlotCheck script1 = Objects[0].GetComponent<SlotCheck>();
        SlotCheck script2 = Objects[1].GetComponent<SlotCheck>();
        SlotCheck script3 = Objects[2].GetComponent<SlotCheck>();
        SlotCheck script4 = Objects[3].GetComponent<SlotCheck>();

        int number1 = script1.GetNumber(SlotCheck.ConnectionPoint.BottomRight);
        int number2 = script2.GetNumber(SlotCheck.ConnectionPoint.TopLeft);
        int number3 = script2.GetNumber(SlotCheck.ConnectionPoint.MiddleRight);
        int number4 = script2.GetNumber(SlotCheck.ConnectionPoint.BottomLeft);
        int number5 = script3.GetNumber(SlotCheck.ConnectionPoint.MiddleLeft);
        int number6 = script4.GetNumber(SlotCheck.ConnectionPoint.TopRight);

        if (number1 != 0 && number2 != 0 && number3 != 0 && number4 != 0 && number5 != 0 && number6 != 0)
        {
            if (number1 == number2 && number3 == number5 && number4 == number6)
            {
                allTrue = true;
                Canvas.SetActive(true);
            }
        }

        else
        {
            allTrue = false;
            Canvas.SetActive(false);
        }

        if (!allTrue)
        {
            Canvas.SetActive(false);
        }
    }

    public void CloseUI()
    {
        Reset();
        allTrue = false;
        Canvas.SetActive(false);
    }

    public void Reset()
    {
        foreach (GameObject obj in Hexagon)
        {
            ScriptGamePlay script = obj.GetComponent<ScriptGamePlay>();
            script.transform.SetParent(script.Level.transform);
            script.transform.position = script.objectInitPost;
        }

        foreach (GameObject slot in Objects)
        {
            SlotCheck slotCheck = slot.GetComponent<SlotCheck>();
            int[] defaultNumbers = { 0, 0, 0, 0, 0, 0 };
            slotCheck.ReceiveNumbers(defaultNumbers);
        }
    }
}
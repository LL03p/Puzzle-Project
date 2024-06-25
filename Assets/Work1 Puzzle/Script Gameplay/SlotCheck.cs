using System;
using System.Collections.Generic;
using UnityEngine;

public class SlotCheck : MonoBehaviour
{
    [Serializable]
    public class SlotData
    {
        public ConnectionPoint point;
        public int number;
    }

    public List<SlotData> SlotDataList;

    public enum ConnectionPoint
    {
        TopLeft,
        TopRight,
        MiddleLeft,
        MiddleRight,
        BottomLeft,
        BottomRight
    }

    private void Start()
    {
        SlotDataList = new List<SlotData>()
        {
            new SlotData() { point = ConnectionPoint.TopLeft, number = 0 },
            new SlotData() { point = ConnectionPoint.TopRight, number = 0 },
            new SlotData() { point = ConnectionPoint.MiddleLeft, number = 0 },
            new SlotData() { point = ConnectionPoint.MiddleRight, number = 0 },
            new SlotData() { point = ConnectionPoint.BottomLeft, number = 0 },
            new SlotData() { point = ConnectionPoint.BottomRight, number = 0 }
        };
    }

    void Update()
    {
        if (transform.childCount == 0)
        {
            SlotDataList = new List<SlotData>()
            {
                new SlotData() { point = ConnectionPoint.TopLeft, number = 0 },
                new SlotData() { point = ConnectionPoint.TopRight, number = 0 },
                new SlotData() { point = ConnectionPoint.MiddleLeft, number = 0 },
                new SlotData() { point = ConnectionPoint.MiddleRight, number = 0 },
                new SlotData() { point = ConnectionPoint.BottomLeft, number = 0 },
                new SlotData() { point = ConnectionPoint.BottomRight, number = 0 }
            };
        }
    }

    public int GetNumber(ConnectionPoint point)
    {
        foreach (var data in SlotDataList)
        {
            if (data.point == point)
            {
                return data.number;
            }
        }
        
        return 0;
    }

    public void ReceiveNumbers(int[] numbers)
    {
        for (int i = 0; i < numbers.Length && i < SlotDataList.Count; i++)
        {
            SlotDataList[i].number = numbers[i];
        }
    }
}
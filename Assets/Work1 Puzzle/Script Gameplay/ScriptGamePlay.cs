using System.Collections.Generic;
using UnityEngine;

public class ScriptGamePlay : MonoBehaviour
{
    public GameObject Level;
    public GameObject Dragobject;

    public List<GameObject> Slot;

    public int[] numbers = new int[6];

    public float DropDistance;

    [HideInInspector] public Vector2 objectInitPost;

    void Start()
    {
        objectInitPost = Dragobject.transform.position;
    }

    public void DragObject()
    {
        Dragobject.transform.position = Input.mousePosition;
        Dragobject.transform.SetParent(Level.transform);
    }

    public void DropObject()
    {
        bool isDrop = false;

        foreach (GameObject slot in Slot)
        {
            float slotDistance = Vector3.Distance(Dragobject.transform.position, slot.transform.position);

            if (slotDistance < DropDistance)
            {
                if (slot.transform.childCount == 0)
                {
                    Dragobject.transform.position = slot.transform.position;
                    Dragobject.transform.SetParent(slot.transform);
                    isDrop = true;
                    SlotCheck slotCheck = slot.GetComponent<SlotCheck>();
                    slotCheck.ReceiveNumbers(numbers);
                }
                
                else
                {
                    Dragobject.transform.position = objectInitPost;
                    Dragobject.transform.SetParent(Level.transform);
                    SlotCheck slotCheck = slot.GetComponent<SlotCheck>();
                    int[] defaultNumbers = { 0, 0, 0, 0, 0, 0 };
                    slotCheck.ReceiveNumbers(defaultNumbers);
                }

                break;
            }
        }

        if (!isDrop)
        {
            Dragobject.transform.position = objectInitPost;
            Dragobject.transform.SetParent(Level.transform);
        }
    }
}
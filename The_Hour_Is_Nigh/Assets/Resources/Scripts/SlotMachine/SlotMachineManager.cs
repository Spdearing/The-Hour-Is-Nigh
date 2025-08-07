using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotMachineManager : MonoBehaviour
{
    private float[] slotValue = new float[3];
    private Material slotsMat;

    private void Start()
    {
        slotsMat = transform.GetChild(15).GetComponent<Material>();
        for (int i = 0; i < slotValue.Length; i++)
        {
            slotValue[i] = 0.1f;
            Debug.Log(slotValue[i]);
        }
        slotsMat.SetFloat("_Slot1", slotValue[0]);
        slotsMat.SetFloat("_Slot1", slotValue[1]);
        slotsMat.SetFloat("_Slot1", slotValue[2]);
    }
}

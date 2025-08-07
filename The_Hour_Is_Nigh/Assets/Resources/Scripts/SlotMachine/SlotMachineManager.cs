using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotMachineManager : MonoBehaviour
{
    private float[] slotValue = new float[3];
    [SerializeField] private Renderer slotsRend;
    private Material slotsMat;

    private void Start()
    {
        slotsMat = slotsRend.material;
        for (int i = 0; i < slotValue.Length; i++)
        {
            slotValue[i] = 0.1f;
            Debug.Log(slotValue[i]);
        }
        slotsMat.SetFloat("_Slot1", slotValue[0]);
        slotsMat.SetFloat("_Slot2", slotValue[1]);
        slotsMat.SetFloat("_Slot3", slotValue[2]);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpinSlots();
        }
    }

    private void SpinSlots()
    {
        //Start spin animation
        StartCoroutine(SpinSlotsCoroutine());
        //Calculate the landing position for each slot
        //Stop spin animation and begin the slowdown for landing
    }
    private IEnumerator SpinSlotsCoroutine()
    {
        float duration = 5f;
        float elapsed = 0f;
        float t = 0f;
        while (t < duration)
        {
            t = elapsed * elapsed/duration;
            float spinSpeed = Mathf.Lerp(0f, 1f, t);
            Debug.Log(spinSpeed);
            slotsMat.SetFloat("_SlotSpeed", spinSpeed);

            elapsed += Time.deltaTime;
            yield return null;
        }
        slotsMat.SetFloat("_SlotSpeed", 1f);
    }

    private void SetSlotValue(int slot, float value)
    {
        slotValue[slot] = value;
        switch (slot)
        {
            case 0:
                slotsMat.SetFloat("_Slot1", value);
                break;
            case 1:
                slotsMat.SetFloat("_Slot1", value);
                break;
            case 2:
                slotsMat.SetFloat("_Slot1", value);
                break;
            default:
                Debug.Log("Slot value broke");
                break;
        }
    }
}

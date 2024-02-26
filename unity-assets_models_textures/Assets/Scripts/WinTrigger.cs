using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Timer timerStamp = other.GetComponent<Timer>();
        if (timerStamp != null)
            timerStamp.enabled = false;
    }
}
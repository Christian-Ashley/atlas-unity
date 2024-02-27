using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerTrigger : MonoBehaviour
{
    public Timer timerScript;

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            timerScript.gameObject.SetActive(true);
        }
    }
}
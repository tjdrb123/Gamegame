using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeCheck : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeTxt;

    private void Update()
    {
        timeTxt.text = Time.time.ToString("N2");
    }
}

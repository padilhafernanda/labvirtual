using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


[RequireComponent(typeof(TextMeshProUGUI))]
public class SliderTextMonitor : MonoBehaviour
{
    private Slider slider;
    private TextMeshProUGUI text;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        slider = GetComponentInParent<Slider>();
    }
    // Update is called once per frame
    void Update()
    {
        text.text = Utils.FloatToLimitedSizeString(slider.value, 4);
    }
}
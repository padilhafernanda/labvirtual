using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class SevenSegmentDisplay : Observer
{

    public float value;
    public FontController.ObserverServices subscribingService;
    public TextMeshProUGUI[] sevenSegmentCharacters;

    // Start is called before the first frame update
    void Start()
    {
        FontController.singleton.SubscribeObserverService(subscribingService, this);
    }

    // Update is called once per frame
    void Update()
    {
        string formatStr;
        if (subscribingService == FontController.ObserverServices.CurrentLeft || subscribingService == FontController.ObserverServices.CurrentRight)
        {
            formatStr = "0.00";
        }
        else
        {
            formatStr = "00.0";
        }
        char[] text = Utils.FloatToLimitedSizeString(value, 4, formatStr).ToCharArray();
        //Debug.Log(Utils.FloatToLimitedSizeString(value, 4, formatStr));
        
        for (int i = 0; i < text.Length; i++)
        {
            sevenSegmentCharacters[i].text = text[i].ToString();
        }
     }


    public override void UpdateObserver(object value)
    {
        this.value = (float) value;
    }

}

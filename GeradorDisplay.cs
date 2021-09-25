using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class GeradorDisplay : Observer
{

    public float value;
    public GeradorController.ObserverServices subscribingService;
    public TextMeshProUGUI[] sevenSegmentCharacters;

    // Start is called before the first frame update
    void Start()
    {
        GeradorController.singleton.SubscribeObserverService(subscribingService, this);
    }

    // Update is called once per frame
    void Update()
    {
        string formatStr;
        if (subscribingService == GeradorController.ObserverServices.Freq)
        {
            formatStr = "000.000";
        }
        else
        {
            formatStr = "00.000";
        }
        char[] text = Utils.FloatToLimitedSizeString(value, 6, formatStr).ToCharArray();
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

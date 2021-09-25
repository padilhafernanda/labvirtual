using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Singleton
/// </summary>
public class FontController : MonoBehaviour
{

    public static FontController singleton = null;

    /// <summary>
    /// Types of toggles on the font. In our case, left or right
    /// </summary>
    public enum ToggleType {
        Right = 1,
        Left = 2
    }

    /// <summary>
    /// Enumeration of the possible modes the font may be in. The mode is calculated based on which toggles are on. If only toggle Left (value 2) is on, then mode = 2 = Series left. 
    /// If both toggles are on, then the mode is calculated as 1 (right toggle) + 2 (left toggle) = 3 (Parallel).
    /// </summary>
    public enum FontMode
    {
        INDEP = 0,
        SERIES_RIGHT = 1,
        SERIES_LEFT = 2,
        PARALEL = 3
    }


    public enum ObserverServices
    {
        VoltageLeft,
        CurrentLeft,
        VoltageRight,
        CurrentRight
    }

    /// <summary>
    /// To children UI toggles
    /// </summary>
    private List<FontSwitch> toggles;

    /// <summary>
    /// The current mode the font is in
    /// </summary>
    public FontMode mode;



    private List<float> CurrentVoltageMeasurements;

    /// <summary>
    /// Voltage provided by the left potentiomenter 
    /// </summary>
    public float VoltageLeft
    {
        get { return CurrentVoltageMeasurements[(int)ObserverServices.VoltageLeft]; }
        set { CurrentVoltageMeasurements[(int)ObserverServices.VoltageLeft] = value; }
    }
    /// <summary>
    /// Current provided by the left potentiomenter 
    /// </summary>
    public float CurrentLeft
    {
        get { return CurrentVoltageMeasurements[(int)ObserverServices.CurrentLeft]; }
        set { CurrentVoltageMeasurements[(int)ObserverServices.CurrentLeft] = value; }
    }
    /// <summary>
    /// Voltage provided by the right potentiomenter 
    /// </summary>
    public float VoltageRight
    {
        get { return CurrentVoltageMeasurements[(int)ObserverServices.VoltageRight]; }
        set { CurrentVoltageMeasurements[(int)ObserverServices.VoltageRight] = value; }
    }
    /// <summary>
    /// Current provided by the right potentiomenter 
    /// </summary>
    public float CurrentRight
    {
        get { return CurrentVoltageMeasurements[(int)ObserverServices.CurrentRight]; }
        set { CurrentVoltageMeasurements[(int)ObserverServices.CurrentRight] = value; }
    }

    // public List<float> CurrentVoltageMeasurements1 { get => CurrentVoltageMeasurements; set => CurrentVoltageMeasurements = value; }

    private Hashtable services;

    private System.Array obsServices;


    /// <summary>
    /// Fetches the children
    /// </summary>
    void Awake()
    {

        if (singleton == null)
        {
            //if not, set instance to this
            singleton = this;
        }
        //If instance already exists and it's not this:
        else if (singleton != this)
        {
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
        }

        mode = 0;
        toggles = new List<FontSwitch>(GetComponentsInChildren<FontSwitch>());
        for (int i = 0; i < toggles.Count; i++)
        {
            if (toggles[i].GetComponent<Toggle>().isOn)
            {
                mode += (int)toggles[i].toggleType;
            }
        }

        obsServices = System.Enum.GetValues(typeof(ObserverServices));
        services = new Hashtable();
        CurrentVoltageMeasurements = new List<float>();

        for (int i = 0; i < obsServices.Length; i++)
        {
            services.Add(obsServices.GetValue(i), new List<Observer>());
            CurrentVoltageMeasurements.Add(0f);
        }


    }


    public void FuncaoLouca(float f, ObserverServices obs)
    {
        Debug.Log("Good boy");
    }

    public void SubscribeObserverService(ObserverServices service, Observer observer)
    {
        if (services.ContainsKey(service))
        {

            ((services[service] as List<Observer>)).Add(observer);

        }
        else
        {
            Debug.LogWarning("You are trying to subscribe to an unexisting service. Check your code, I think you have fucked up. I will ignore and move on");
        }
    }



    void Update()
    {
       // Debug.Log(mode);
        switch (mode)
        {
            case FontMode.INDEP:
                for (int i = 0; i < obsServices.Length; i++)
                {
                    var observerList = (services[obsServices.GetValue(i)] as List<Observer>);
                    for (int j = 0; j < observerList.Count; j++)
                    {
                        observerList[j].UpdateObserver(CurrentVoltageMeasurements[(int)obsServices.GetValue(i)]);
                    }

                }
                break;
            case FontMode.PARALEL:
                break;
            case FontMode.SERIES_LEFT:
                break;
            case FontMode.SERIES_RIGHT:
                break;

            default:
                Debug.LogWarning("Well, congratulations. Somehow you managed to configure me in a way it was not predicted by my stupid programmer. " +
                    "But I suspect it is you who fucked up.");
                break;
        }
    }


    public void SetValue(ObserverServices service, float value)
    {
        CurrentVoltageMeasurements[(int)service] = value;
    }

    public float GetValue(ObserverServices service)
    {
        return CurrentVoltageMeasurements[(int)service];
    }

    // Update is called once per frame
    public void UpdateMode(bool buttonNewValue, ToggleType type)
    {
        Debug.Log(type);
        if (buttonNewValue == false)
        {
            mode -= (int) type;
        }
        else
        {
            mode += (int) type;
        }

        
    }

    
}


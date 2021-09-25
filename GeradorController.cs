using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Singleton
/// </summary>
public class GeradorController : MonoBehaviour
{

    public static GeradorController singleton = null;


    /// <summary>
    /// Enumeration of the possible modes the Gerador may be in. The mode is calculated based on which toggles are on. If only toggle Left (value 2) is on, then mode = 2 = Series left. 
    /// If both toggles are on, then the mode is calculated as 1 (right toggle) + 2 (left toggle) = 3 (Parallel).
    /// </summary>
    public enum GeradorMode
    {
        SINE = 0,
        SQUARE = 1,
        RAMP = 2,
        PULSE = 3,
        NOISE = 4
        
    }


    public enum ObserverServices
    {
        Freq,
        Ampl
        //Offset,
        //Phase,
        //AligPha
    }


    /// <summary>
    /// The current mode the Gerador is in
    /// </summary>
    public GeradorMode mode;



    private List<float> GeradorMeasurements;

    /// <summary>
    /// Voltage provided by the left potentiomenter 
    /// </summary>
    public float Freq
    {
        get { return GeradorMeasurements[(int)ObserverServices.Freq]; }
        set { GeradorMeasurements[(int)ObserverServices.Freq] = value; }
    }
    /// <summary>
    /// Current provided by the left potentiomenter 
    /// </summary>
    public float Ampl
    {
        get { return GeradorMeasurements[(int)ObserverServices.Ampl]; }
        set { GeradorMeasurements[(int)ObserverServices.Ampl] = value; }
    }


    // public List<float> GeradorMeasurements1 { get => GeradorMeasurements; set => GeradorMeasurements = value; }

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

        obsServices = System.Enum.GetValues(typeof(ObserverServices));
        services = new Hashtable();
        GeradorMeasurements = new List<float>();

        for (int i = 0; i < obsServices.Length; i++)
        {
            services.Add(obsServices.GetValue(i), new List<Observer>());
            GeradorMeasurements.Add(0f);
        }


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
            case GeradorMode.SINE:
                for (int i = 0; i < obsServices.Length; i++)
                {
                    var observerList = (services[obsServices.GetValue(i)] as List<Observer>);
                    for (int j = 0; j < observerList.Count; j++)
                    {
                        observerList[j].UpdateObserver(GeradorMeasurements[(int)obsServices.GetValue(i)]);
                    }

                }
                break;
            case GeradorMode.SQUARE:
                break;
            case GeradorMode.RAMP:
                break;
            case GeradorMode.PULSE:
                break;
            case GeradorMode.NOISE:
                break;
             

            default:
                Debug.LogWarning("Well, congratulations. Somehow you managed to configure me in a way it was not predicted by my stupid programmer. " +
                    "But I suspect it is you who fucked up.");
                break;
        }
    }


    public void SetValue(ObserverServices service, float value)
    {
        GeradorMeasurements[(int)service] = value;
    }

    public float GetValue(ObserverServices service)
    {
        return GeradorMeasurements[(int)service];
    }

    // Update is called once per frame
  //  public void UpdateMode(int newValue)
 //   {
  //      mode = (int) newValue;
  //  }

    
}


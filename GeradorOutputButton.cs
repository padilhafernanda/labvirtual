using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GeradorOutputButton : MonoBehaviour
{

    public bool power;
  //  public GameObject circuito;
    Color offColor = new Color(0.85f,0.85f,0.85f);
    Color onColor = new Color(0.85f,1.2f,0.85f);

    // Update is called once per frame
    public void OnPress()
    {
        power = !power;
        
    }

    private void Update()
    {   
        if(power){
            GetComponent<Renderer>().material.color = onColor;
        }
        else{
            GetComponent<Renderer>().material.color = offColor;
        } 
         
    }
}

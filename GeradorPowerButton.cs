using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GeradorPowerButton : MonoBehaviour
{

    public bool power;
    public GameObject botaoSine;
  //  public GameObject[] botoes;
    public GameObject visorOff;
    public GameObject visorAmpl;
    public GameObject visorFreq;
    public GameObject outputBtn;
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
            botaoSine.GetComponent<Renderer>().material.color = onColor;
            if(visorAmpl.activeSelf)
                visorFreq.SetActive(false);    
            else 
                visorFreq.SetActive(true);    
        }
        else{
            botaoSine.GetComponent<Renderer>().material.color = offColor;
            GetComponent<Renderer>().material.color = offColor;
            visorAmpl.SetActive(false);
            visorFreq.SetActive(false);
        } 
            
        outputBtn.SetActive(power); 
        visorOff.SetActive(!power);
       // for(int i=0; i<botoes.Length; i++)
       //     botoes[i].SetActive(power);
        
    }



}

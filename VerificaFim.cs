using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VerificaFim : MonoBehaviour
{   
    public GameObject prontoQuest;
    public GameObject circuito;
    public GameObject emptyCir;
    public Image grafico;
    public GameObject questOsc;
    
    private void Start(){
        circuito.SetActive(false);
        questOsc.SetActive(false);
        grafico.enabled = false;
    }
    private void Update(){
        if(prontoQuest==null){
            circuito.SetActive(true);
            grafico.enabled = true;
            questOsc.SetActive(true);
            emptyCir.SetActive(true);
        }
    }   
}

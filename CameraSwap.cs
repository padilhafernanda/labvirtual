using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraSwap : MonoBehaviour
{
    public SetCursorLockState2 cursor;
    public Camera focusCamera;
    public Camera playerCamera;
    public Button voltarBtn;
    public Collider objCollider;
    
    public void FocusCamera(){
        if(voltarBtn)
            voltarBtn.gameObject.SetActive(true);      
        cursor.BloqueiaMouse(false);
        focusCamera.gameObject.SetActive(true);
        playerCamera.gameObject.SetActive(false);
        objCollider.enabled = false;
    }
    
    public void BackCamera()
    {   
        objCollider.enabled = true;
        if(voltarBtn)
            voltarBtn.gameObject.SetActive(false);
        cursor.BloqueiaMouse(true);
        focusCamera.gameObject.SetActive(false);
        playerCamera.gameObject.SetActive(true);           
    }

}
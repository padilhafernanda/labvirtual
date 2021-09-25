using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ClickableCollider))]
public class FontPowerButton : MonoBehaviour
{

    public bool power;

    public GameObject fontScreens;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<ClickableCollider>().downAction.AddListener(OnPress);
    }

    // Update is called once per frame
    void OnPress()
    {
        power = !power;
        
    }

    private void Update()
    {
        fontScreens.SetActive(power);
    }



}

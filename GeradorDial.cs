using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ClickableCollider))]
public class GeradorDial : MonoBehaviour
{

    public float minValue;

    public float maxValue;

    public float rateOfChange;

    public float dialSpeed;

    public GeradorController.ObserverServices measurementToControl;

    private Vector3 previousMousePosition;


    // Start is called before the first frame update
    void Start()
    {
        GetComponent<ClickableCollider>().downAction.AddListener(OnPress);
        GetComponent<ClickableCollider>().upAction.AddListener(OnRelease);
        GetComponent<ClickableCollider>().dragAction.AddListener(OnDrag);

    }

    public void OnPress()
    {
        //slider.gameObject.SetActive(true);
        //slider.GetComponent<RectTransform>().position = Input.mousePosition - (slider.handleRect.position - slider.transform.position);

        previousMousePosition = Input.mousePosition;


    }

    public void OnRelease()
    {

        ///TODO: Implement Hint
        //  slider.gameObject.SetActive(false);

    }

    public void OnDrag()
    {

        var offset = rateOfChange * (Input.mousePosition - previousMousePosition).x;
        previousMousePosition = Input.mousePosition;
        //Debug.Log("----->" + offset);
        GeradorController.singleton.SetValue(measurementToControl, Mathf.Clamp(GeradorController.singleton.GetValue(measurementToControl) + offset, minValue, maxValue));
        if (GeradorController.singleton.GetValue(measurementToControl) < maxValue && GeradorController.singleton.GetValue(measurementToControl) > minValue)
            gameObject.transform.Rotate(-Vector3.down * offset * dialSpeed);
    }
}
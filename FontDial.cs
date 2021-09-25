using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ClickableCollider))]
public class FontDial : MonoBehaviour
{

    public Slider slider;

    public GameObject hint;

    public float minValue;

    public float maxValue;

    public float rateOfChange;

    public float dialSpeed;

    public FontController.ObserverServices measurementToControl;

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
        Debug.Log("----->" + offset);
        FontController.singleton.SetValue(measurementToControl, Mathf.Clamp(FontController.singleton.GetValue(measurementToControl) + offset, minValue, maxValue));
        if (FontController.singleton.GetValue(measurementToControl) < maxValue && FontController.singleton.GetValue(measurementToControl) > minValue)
            gameObject.transform.Rotate(Vector3.down * offset * dialSpeed);
    }
}
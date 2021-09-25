using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class FontSwitch : MonoBehaviour
{

    /// <summary>
    /// Contains the type of the toggle (Left or Right). This information is used by the fontController to update its state. More info on FontController
    /// </summary>
    public FontController.ToggleType toggleType;
    /// <summary>
    /// The value of the switch
    /// </summary>
    public bool value = false;




    /// <summary>
    /// Function to be associated with the OnClick event of ClickableCollider component of the game object. It informs the fontController of state change, 
    /// providing its new status (On or Off) and its type of button (Left or Right), which impacts on the calculation of the new mode. More info on FontController
    /// </summary>
    public void OnPress()
    {
        Debug.Log(toggleType);
        value = !value;
        FontController.singleton.UpdateMode(value, toggleType);
    }
}

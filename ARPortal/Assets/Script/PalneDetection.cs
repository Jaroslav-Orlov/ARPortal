using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARFoundation;


[RequireComponent(typeof(ARPlaneManager))]
public class PalneDetection : MonoBehaviour
{
    private ARPlaneManager aRPlaneManager;
    [SerializeField] 
    private Text toggleButtonText;

    private void Awake()
    {
        aRPlaneManager = GetComponent<ARPlaneManager>();
        toggleButtonText.text = "Disable";
    }

    public void TogglePlaneDetection()
    {
        aRPlaneManager.enabled = !aRPlaneManager.enabled;
        string toggleButtonMesage = "";

        if (aRPlaneManager.enabled)
        {
            toggleButtonMesage = "Disable";
            SetAllPlanesActiv(false);
        }
        else
        {
            toggleButtonMesage = "Enable";
            SetAllPlanesActiv(false);
        }
        toggleButtonText.text = toggleButtonMesage;
    }

    private void  SetAllPlanesActiv(bool value)
    {
        foreach(var plane in aRPlaneManager.trackables)
        {
            plane.gameObject.SetActive(value);
        }
    }
}

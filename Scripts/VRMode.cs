using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class VRMode : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    

    // Update is called once per frame
    public void ToggleVRMode()
    {
        GvrViewer.Instance.VRModeEnabled = !GvrViewer.Instance.VRModeEnabled;
    }
}

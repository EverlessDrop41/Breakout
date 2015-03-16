using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class ResolutionManager : MonoBehaviour {

    public Toggle Fullscreen;
    public InputField widthInput;
    public InputField heightInput;
    public Text errorDisplay;

    private int MonitorHeight;
    private int MonitorWidth;

    private int desiredHeight;
    private int desiredWidth;

    void Start()
    {
        MonitorHeight = Screen.currentResolution.height;
        MonitorWidth = Screen.currentResolution.width;
        Fullscreen.isOn = Screen.fullScreen;
    }

    void Update()
    {
            //TODO: WORKING CODE
    }

    public void UpdateWidth(int width)
    {
        desiredWidth = width;
    }

    public void UpdateHeight(dynamic height)
    {
        object varHeight = height;
        string strHeight = Convert.ToString(varHeight);
        int.TryParse(strHeight, out desiredHeight);
        Debug.Log(desiredHeight);
    }

    public void UpdateResolution()
    {
        if (desiredWidth > MonitorWidth || desiredHeight > MonitorHeight)
        {
            errorDisplay.text = "Monitor is too small";
        }
        else
        {
            Screen.SetResolution(desiredHeight, desiredWidth, Screen.fullScreen);
        }
    }

    public void ToggleFullscreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
}

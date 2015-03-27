using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class ResolutionManager : MonoBehaviour {

    public Toggle Fullscreen;
    public Text errorDisplay;

    private bool initialToggleDone = false;

    private int MonitorHeight;
    private int MonitorWidth;

    private int desiredHeight;
    private int desiredWidth;

    void Start()
    {
        MonitorHeight = Screen.currentResolution.height;
        MonitorWidth = Screen.currentResolution.width;
        Fullscreen.isOn = Screen.fullScreen;
        initialToggleDone = true;
    }

    public void UpdateWidth(dynamic width)
    {
        object varWidth = width;
        string strWidth = Convert.ToString(varWidth);
        if (!int.TryParse(strWidth, out desiredWidth))
        {
            errorDisplay.text = "Width must be a number";
        }
        else
        {
            errorDisplay.text = "";
        }
        Debug.Log(desiredHeight);
    }

    public void UpdateHeight(dynamic height)
    {
        object varHeight = height;
        string strHeight = Convert.ToString(varHeight);
        if (!int.TryParse(strHeight, out desiredHeight))
        {
            errorDisplay.text = "Height must be a number";
        }
        else
        {
            errorDisplay.text = "";
        }
        Debug.Log(desiredHeight);
    }

    public void UpdateResolution()
    {
        if (desiredWidth > MonitorWidth || desiredHeight > MonitorHeight)
        {
            errorDisplay.text = "Monitor is too small";
        }
        else if (desiredWidth < 640 || desiredHeight < 480)
        {
            errorDisplay.text = "Chose a higher resolution";
        }
        else
        {
            Screen.SetResolution(desiredWidth, desiredHeight, Screen.fullScreen);
            errorDisplay.text = "";
        }
    }

    public void ToggleFullscreen()
    {
        if (initialToggleDone)
            Screen.fullScreen = !Screen.fullScreen;
    }
}

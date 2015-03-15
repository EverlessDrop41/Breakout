using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResolutionManager : MonoBehaviour {

    public Toggle Fullscreen;
    public InputField widthInput;
    public InputField heightInput;

    private int MonitorHeight;
    private int MonitorWidth;

    private int desiredHeight;
    private int desiredWidth;

    void Start()
    {
        MonitorHeight = Screen.currentResolution.height;
        MonitorWidth = Screen.currentResolution.width;
    }

    void Update()
    {
            //TODO: WORKING CODE
    }

    void UpdateWidth(int width)
    {
        desiredWidth = width;
    }

    void UpdateHeight(int height)
    {
        desiredHeight = height;
    }
}

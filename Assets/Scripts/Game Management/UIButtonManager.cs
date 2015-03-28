using UnityEngine;
using System.Collections;

public class UIButtonManager : MonoBehaviour
{
    public Fader fader;

    public void LoadScene(string level)
    {
        //Application.LoadLevel(level);
        fader.StartCoroutine("LoadLevel",level);
        Debug.Log(0);
    }

    public void LoadScene(int level)
    {
        Application.LoadLevel(level);
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    public void setQuality(int quality)
    {
        QualitySettings.SetQualityLevel(quality);
    }
}
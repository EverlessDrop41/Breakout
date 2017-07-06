using UnityEngine;
using UnityEngine.SceneManagement;
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
		fader.StartCoroutine("LoadLevelInt",level);
		Debug.Log(0);
    }

    public void CloseGame()
    {
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.Quit();
		#endif 
    }

    public void setQuality(int quality)
    {
        QualitySettings.SetQualityLevel(quality);
    }
}
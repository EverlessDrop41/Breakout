using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class UIButtonManager : MonoBehaviour
{
    public Fader fader;

    public void LoadScene(string level)
    {
		if (!fader) { 
			SceneManager.LoadScene (level);
			return;
		}
        fader.StartCoroutine("LoadLevel",level);
    }

    public void LoadScene(int level)
    {
		if (!fader) { 
			SceneManager.LoadScene (level);
			return;
		}
		fader.StartCoroutine("LoadLevelInt",level);
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
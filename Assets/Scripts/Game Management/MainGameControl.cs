using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainGameControl : MonoBehaviour {

    public Transform BallSpawnPosition;
    public GameObject Ball;

    public Button MobileButton;

    public Text LivesDisplayer;
    public string LivesMessageFormat = "Lives Left: {0}";
    public int maxLives = 3;
    private int currentLives;

    private GameObject currentBall;

    void Start()
    {
        if (FindObjectsOfType<MainGameControl>().Length > 1)
        {
            Destroy(this);
        }

        #if !UNITY_ANDROID
            MobileButton.gameObject.SetActive(false);
        #endif
    }

    public void MobileLaunchButton()
    {
        try
        {
            currentBall.GetComponent<BallBehaviour>().MobileLaunch();
            MobileButton.gameObject.SetActive(false);
        }
        catch
        {
            Debug.Log("Ball does not have  BallBehaviour script attached");
        }
    }

    void Awake()
    {
        CreateBall();
        currentLives = maxLives;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            Application.LoadLevel("MainMenu");
        }

        LivesDisplayer.text = string.Format(LivesMessageFormat, currentLives);
    }

    private void CreateBall()
    {
        currentBall = (Instantiate(Ball, BallSpawnPosition.position, Quaternion.identity) as GameObject);
        MobileButton.gameObject.SetActive(true);
    }

    public void ResetBall()
    {
        Destroy(currentBall);
        currentLives--;
        if (currentLives < 0)
        {
            EndGame(false);
        }
        CreateBall();
#if !UNITY_ANDROID
        MobileButton.gameObject.SetActive(false);
#endif
    }

    public static void EndGame(bool won)
    {       
        Application.LoadLevel(Application.loadedLevel);
    }
}

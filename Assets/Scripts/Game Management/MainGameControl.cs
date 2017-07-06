using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

using System.Collections;

public class MainGameControl : MonoBehaviour {

    public Transform BallSpawnPosition;
    public GameObject Ball;

    public Fader fader;

    public Button MobileButton;

    public Text LivesDisplayer;
    public string LivesMessageFormat = "Lives Left: {0}";
    public int maxLives = 3;
    private int currentLives;

    private GameObject currentBall;

    private bool startedGame;

    void Start()
    {
        if (FindObjectsOfType<MainGameControl>().Length > 1)
        {
            Destroy(this);
        }
        Advertisement.Initialize("28602");
        #if !UNITY_ANDROID
            MobileButton.gameObject.SetActive(false);
        #endif
    }

    public void MobileLaunchButton()
    {
        if (!startedGame)
        {
            GetComponent<ScoreManager>().StartTimer();
            startedGame = true;
        }

        try
        {
            currentBall.GetComponent<BallBehaviour>().Launch();
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
			fader.StartCoroutine("LoadLevel", "MainMenu");
        }

        if (Input.GetButtonDown("Start") /*|| Input.touches.Length > 0*/)
        {
            if (!startedGame)
            {
                GetComponent<ScoreManager>().StartTimer();
                startedGame = true;
            }
            currentBall.GetComponent<BallBehaviour>().Launch();
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
            this.EndGame(false);
        }
        CreateBall();
#if !UNITY_ANDROID
        MobileButton.gameObject.SetActive(false);
#endif
    }

    public void EndGame(bool won)
    {
        if ((Application.internetReachability != NetworkReachability.NotReachable &&  !won) && Advertisement.isInitialized)
        {
            StartCoroutine(ShowAdWhenReady());
        }
        else
        {
			fader.StartCoroutine("LoadLevelInt", SceneManager.GetActiveScene().buildIndex);
        }
    }

    IEnumerator ShowAdWhenReady()
    {
        while (!Advertisement.isReady())
            yield return null;

        if (Advertisement.isReady())
        {
            Advertisement.Show(null, new ShowOptions {
                resultCallback = result => {
                    Debug.Log(result.ToString());
					fader.StartCoroutine("LoadLevelInt",  SceneManager.GetActiveScene().buildIndex);
                }
            });
        }
    }
}

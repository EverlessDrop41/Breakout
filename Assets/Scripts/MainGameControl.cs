using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainGameControl : MonoBehaviour {

    public Transform BallSpawnPosition;
    public GameObject Ball;

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
    }

    void Awake()
    {
        CreateBall();
        currentLives = maxLives;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.LoadLevel("MainMenu");
        }

        LivesDisplayer.text = string.Format(LivesMessageFormat, currentLives);
    }

    private void CreateBall()
    {
        currentBall = Instantiate(Ball, BallSpawnPosition.position, Quaternion.identity) as GameObject;
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

    }

    public static void EndGame(bool won)
    {       
        Application.LoadLevel(Application.loadedLevel);
    }
}

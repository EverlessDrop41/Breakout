using UnityEngine;
using System.Collections;

public class MainGameControl : MonoBehaviour {

    public Transform BallSpawnPosition;
    public GameObject Ball;

    private static bool hasSingleton;

    private GameObject currentBall;

    void Start()
    {
        if (MainGameControl.hasSingleton)
        {
            Destroy(this);
        }
        else
        {
            hasSingleton = true;
        }
    }

    void Awake()
    {
        CreateBall();
    }

    private void CreateBall()
    {
        currentBall = Instantiate(Ball, BallSpawnPosition.position, Quaternion.identity) as GameObject;
    }

    public void ResetBall()
    {
        Destroy(currentBall);
        CreateBall();
    }
}

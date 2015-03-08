using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D),typeof(AudioSource))]
public class BallBehaviour : MonoBehaviour {

	public float MaxVelocity;
	public int StuckAmountMax = 60;

	private Rigidbody2D RB;
	private AudioSource speaker;

	float PrevY;
	float CurrentY;
	int StuckCounter;

    bool hasStarted = false;
    bool startInputReceived = false;

	void Start () {
		RB = this.gameObject.GetComponent<Rigidbody2D>();
		speaker = this.gameObject.GetComponent<AudioSource>();
	}

    void Update()
    {
        if (Input.GetButtonDown("Start"))
        {
            startInputReceived = true;
        }
    }

	void FixedUpdate () {
        if (!hasStarted)
        {
            if (startInputReceived)
            {
                RB.AddForce(Vector2.up, ForceMode2D.Impulse);
                hasStarted = true;
            }
            
        }
        else
        {
            RB.velocity = Vector2.ClampMagnitude(RB.velocity, MaxVelocity);

            CurrentY = this.gameObject.transform.position.y;
            if (CurrentY == PrevY)
            {
                StuckCounter++;
            }
            else
            {
                StuckCounter = 0;
            }
            if (StuckCounter > StuckAmountMax)
            {
                RB.AddForce(Vector2.up, ForceMode2D.Impulse);
            }
            PrevY = CurrentY; 
        }
		
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "Block") {
			coll.gameObject.SendMessage("TakeDamage");
			speaker.Play();
		}
        else if (coll.gameObject.tag == "BallCatcher") {
            speaker.Play();
            FindObjectOfType<MainGameControl>().ResetBall(); //MainGameControll is a singleton
        }
	}
}

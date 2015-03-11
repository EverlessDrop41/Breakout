using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D),typeof(AudioSource))]
public class BallBehaviour : MonoBehaviour {

	public float MaxVelocity;

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
                RB.AddForce(Vector2.right, ForceMode2D.Impulse);
                hasStarted = true;
            }
            
        }
        else
        {
            RB.velocity = Vector2.ClampMagnitude(RB.velocity, MaxVelocity);
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

        if (RB.velocity.y < 0.5 && RB.velocity.y >= -0.05)
        {
            float rand = Random.Range(1, 0);
            RB.velocity = new Vector2(RB.velocity.x, RB.velocity.y + rand);
        }
	}
}

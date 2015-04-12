using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D),typeof(AudioSource))]
public class BallBehaviour : MonoBehaviour {

	public float MaxVelocity;

	private Rigidbody2D RB;
	private AudioSource speaker;

    public bool GodMode = false;

	float PrevY;
	float CurrentY;
	int StuckCounter;

    bool hasStarted = false;
    bool startInputReceived = false;

	void Start () {
		RB = this.gameObject.GetComponent<Rigidbody2D>();
		speaker = this.gameObject.GetComponent<AudioSource>();
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
        }
		
	}

    public void Launch()
    {
        startInputReceived = true;
    }

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "Block") {
			coll.gameObject.SendMessage("TakeDamage");
			speaker.Play();
		}
        else if (coll.gameObject.tag == "BallCatcher" && !GodMode) {
            speaker.Play();
            FindObjectOfType<MainGameControl>().ResetBall(); //MainGameControll is a singleton
        }
        else if (coll.gameObject.tag == "TopWall")
        {
            if (coll.relativeVelocity.y < 1 && coll.relativeVelocity.y > -0.001)
            {
                RB.AddForce(new Vector2(0, -1), ForceMode2D.Impulse);
                Debug.Log("TopWall");
            }
        }

        if (coll.relativeVelocity.y < 0.5 && coll.relativeVelocity.y >= -0.001)
        {
            float rand = Random.Range(1, 0);
            RB.velocity = new Vector2(RB.velocity.x, RB.velocity.y + rand);
        }
	}
}

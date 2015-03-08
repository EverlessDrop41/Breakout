using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class PaddleControl : MonoBehaviour {

	public float speed;
	public bool LockY = true;

	private Rigidbody2D RB;
	private float AxisInput;
	private float YPos;

	public float rayDist = 2.4f;

	void Start() {
		RB = this.gameObject.GetComponent<Rigidbody2D>();
		if (LockY) {
			YPos = this.transform.position.y;
			InvokeRepeating("YPosLock",0,0.1F);
		}
	}

	void FixedUpdate () {
		AxisInput = Input.GetAxis("Horizontal");
		this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(AxisInput * speed,0);

		RaycastHit2D moveRightDetect = Physics2D.Raycast(this.transform.position,Vector2.right,rayDist);
		RaycastHit2D moveLeftDetect = Physics2D.Raycast(this.transform.position,-Vector2.right,rayDist);

		//Right Ray
		if (moveRightDetect.collider != null && moveRightDetect.collider.tag != "Ball"){
			//Debug.Log("MoveRight hit detected");
			Debug.DrawRay(RB.position,new Vector2(rayDist,0),Color.red);
			//If input for moving left is not received we stop the paddle from moving
			if (!(AxisInput <= 0)){
				RB.velocity = new Vector2(0,0);
			}
		}
		else {
			Debug.DrawRay(this.transform.position,new Vector2(rayDist,0),Color.green);
		}

		//Left Ray
		if (moveLeftDetect.collider != null && moveLeftDetect.collider.tag != "Ball"){
			//Debug.Log("MoveLeft hit detected");
			Debug.DrawRay(RB.position,new Vector2(-rayDist,0),Color.red);
			//If input for moving right is not received we stop the paddle from moving
			if (!(AxisInput >= 0)){
				RB.velocity = new Vector2(0,0);
			}
		}
		else {
			Debug.DrawRay(this.transform.position,new Vector2(rayDist,0),Color.green);
		}
	}
	
	void YPosLock() {
		this.transform.position = new Vector3(this.transform.position.x,YPos,this.transform.position.z);
	}
}

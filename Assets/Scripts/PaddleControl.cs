using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class PaddleControl : MonoBehaviour {

	public float speed;
    public bool VerticalMovement = false;
	public bool LockY = false;
    public bool LockX = false;

	private Rigidbody2D RB;
	private float AxisInput;
	private float YPos;
    private float XPos;

    private float VertSpeed;
    private float HorzSpeed;

	public float rayDist = 2.4f;

	void Start() {
		RB = this.gameObject.GetComponent<Rigidbody2D>();
		if (LockY || LockX) {
			YPos = this.transform.position.y;
            XPos = this.transform.position.x;
			InvokeRepeating("PosLock",0,0.1F);
		}
	}

    void Update()
    {
        HorzSpeed = Input.GetAxis("Horizontal");
        VertSpeed = Input.GetAxis("Vertical");
    }

	void FixedUpdate () {
        if (VerticalMovement)
        {
            AxisInput = VertSpeed;
            this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, AxisInput * speed);

            RaycastHit2D moveUpDetect = Physics2D.Raycast(this.transform.position, Vector2.up, rayDist);
            RaycastHit2D moveDownDetect = Physics2D.Raycast(this.transform.position, -Vector2.up, rayDist);

            //Up Ray
            if (moveUpDetect.collider != null && moveUpDetect.collider.tag != "Ball")
            {
                Debug.DrawRay(RB.position, new Vector2(0, rayDist), Color.red);
                //If input for moving left is not received we stop the paddle from moving
                if (!(AxisInput <= 0))
                {
                    RB.velocity = new Vector2(0, 0);
                }
            }
            else
            {
                Debug.DrawRay(this.transform.position, new Vector2(0, rayDist), Color.green);
            }

            //Down Ray
            if (moveDownDetect.collider != null && moveDownDetect.collider.tag != "Ball")
            {
                //Debug.Log("MoveLeft hit detected");
                Debug.DrawRay(RB.position, new Vector2(0, -rayDist), Color.red);
                //If input for moving right is not received we stop the paddle from moving
                if (!(AxisInput >= 0))
                {
                    RB.velocity = new Vector2(0, 0);
                }
            }
            else
            {
                Debug.DrawRay(this.transform.position, new Vector2(0, -rayDist), Color.green);
            }
        }
        else
        {
            AxisInput = HorzSpeed;
            this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(AxisInput * speed, 0);

            RaycastHit2D moveRightDetect = Physics2D.Raycast(this.transform.position, Vector2.right, rayDist);
            RaycastHit2D moveLeftDetect = Physics2D.Raycast(this.transform.position, -Vector2.right, rayDist);

            //Right Ray
            if (moveRightDetect.collider != null && moveRightDetect.collider.tag != "Ball")
            {
                //Debug.Log("MoveRight hit detected");
                Debug.DrawRay(RB.position, new Vector2(rayDist, 0), Color.red);
                //If input for moving left is not received we stop the paddle from moving
                if (!(AxisInput <= 0))
                {
                    RB.velocity = new Vector2(0, 0);
                }
            }
            else
            {
                Debug.DrawRay(this.transform.position, new Vector2(rayDist, 0), Color.green);
            }

            //Left Ray
            if (moveLeftDetect.collider != null && moveLeftDetect.collider.tag != "Ball")
            {
                //Debug.Log("MoveLeft hit detected");
                Debug.DrawRay(RB.position, new Vector2(-rayDist, 0), Color.red);
                //If input for moving right is not received we stop the paddle from moving
                if (!(AxisInput >= 0))
                {
                    RB.velocity = new Vector2(0, 0);
                }
            }
            else
            {
                Debug.DrawRay(this.transform.position, new Vector2(rayDist, 0), Color.green);
            }
        }
	}
	
	void PosLock() {
        if (LockY)
		    this.transform.position = new Vector3(this.transform.position.x,YPos,this.transform.position.z);
        if (LockX)
            this.transform.position = new Vector3(XPos, transform.position.y, transform.position.z);
	}
}

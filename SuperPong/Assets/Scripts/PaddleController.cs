using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour {

    public GameObject paddle;
    private Rigidbody paddleRigidBody;
    public Transform floor;

	// Use this for initialization
	void Start ()
    {
        //Make the paddle red to make it stand out more
        paddle.GetComponent<Renderer>().material.color = Color.red;

        //Add a rigid body to the Paddle game object
        paddleRigidBody = paddle.AddComponent<Rigidbody>();
        paddleRigidBody.isKinematic = false;

        //Prevent any vertical movement of the paddle
        paddleRigidBody.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ;

        //Tag the paddle with walls so that the ball controller will treat paddles the same as walls
        paddle.tag = "Walls";

        //Create a spring joint to tie the floor to the paddle
        //SpringJoint springJoint = new SpringJoint();
        //springJoint.anchor = Vector3.zero;

        //Constrain the paddle along an axis between itself and the center of the play field
        //springJoint.axis = Vector3.zero - paddle.GetComponent<Transform>().position;

        //Make the force needed to seperate the paddle from the floor effectively infinite
        //springJoint.breakForce = float.MaxValue;
        //springJoint.breakTorque = float.MaxValue;

        //Allow the Paddle to move only half of the magnitude of the floor
        //springJoint.maxDistance = 2; //.5f * (floor.GetComponent<Mesh>().bounds.size.x);
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Since the paddle will be tied to the floor
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

        paddleRigidBody.AddForce(movement * 5);
    }
}
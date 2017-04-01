using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody sphere;
    private int velocityRange = 200;
    private float initialHeight;

	// Use this for initialization
	void Start ()
    {
        sphere = GetComponent<Rigidbody>();
        initialHeight = sphere.position.y;
        resetBall(sphere);
        sphere.AddForce(new Vector3(Random.Range(velocityRange, velocityRange*2), 0, Random.Range(velocityRange, velocityRange*2)));
    }
	
	// Update is called once per frame
	void Update ()
    {

    }

    private void OnCollisionExit(Collision collision)
    {
        //The qualifier of initial height is needed because the ball sometimes rises a bit
        //when it bounces off of a wall.
        if (collision.gameObject.tag.Equals("Floor") && sphere.position.y <= initialHeight)
        {
            resetBall(sphere);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        float forceMagnitudeAppliedByWalls = 500;
        if(collision.gameObject.tag.Equals("Walls"))
        {
            Vector3 currentVelocity = sphere.GetComponent<Rigidbody>().velocity;
            Vector3 reflectedVector = Vector3.Reflect(collision.contacts[0].normal, currentVelocity);
            
            //Only want the normal in the X/Z plane
            reflectedVector.y = 0;

            if (sphere.rotation.x < .1 && sphere.rotation.x > -.1)
            {
                reflectedVector.z += .01f;
            }

            sphere.GetComponent<Rigidbody>().AddForce(forceMagnitudeAppliedByWalls * reflectedVector);
        }
    }

    //TODO: Make this reset the ball to the side of the player who just scored (initially is random direction)
    void resetBall (Rigidbody sphere)
    {
        //Arbitrary position until we have a way of keep tracking of the last player to score
        sphere.transform.position = new Vector3(0, 0.75f, 0);
        sphere.velocity = Vector3.zero;
        sphere.AddForce(new Vector3(Random.Range(velocityRange, velocityRange * 2),
            0f, Random.Range(velocityRange, velocityRange * 2)));
    }
}

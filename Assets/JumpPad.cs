using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour {

	Vector3 direction; 
	public float jumpForce;
	private float gravity  = 9.81f;
	private Vector3 movement;
	private bool jump = false;


    // Start is called before the first frame update
    void Start() {
    	movement.y = jumpForce;
    }

    // Update is called once per frame
    void Update() {
        // direction = transform.TransformDirection(Vector3.up * jumpForce);
        // direction *= Time.deltaTime;

    	if (jump) {
	   		movement.y -= gravity * Time.deltaTime;
	    	GameObject.FindWithTag("Player").GetComponent<CharacterController>().Move(movement * Time.deltaTime);
	    }

    }

    void OnTriggerEnter(Collider collision) {
    	Debug.Log(collision);
		if (collision.gameObject.CompareTag("Player")) {
			Debug.Log("Two");
			// Apply jump force		
			// collision.gameObject.GetComponent<Rigidbody>().isKinematic = false;
			// collision.gameObject.GetComponent<Rigidbody>().useGravity = true;
			jump = true;
		}
	}

}
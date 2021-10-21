using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class JumpPad : MonoBehaviour {

	Vector3 direction; 
	public float jumpForce;
	private float gravity  = 9.81f;
	private Vector3 movement;
	private bool jump = false;
	private LocomotionProvider loco;


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
		if (collision.gameObject.CompareTag("Player")) {
			// Debug.Log("We've made contact");
			// Apply jump force		
			// collision.gameObject.GetComponent<Rigidbody>().isKinematic = false;
			// collision.gameObject.GetComponent<Rigidbody>().useGravity = true;
			jump = true;
			// enableTeleportationSystem();
			// GameObject.FindWithTag("Player").GetComponent<LocomotionController>().disableContinousMove();
		}
	}

	// void enableTeleportationSystem() {
	// 	loco = GameObject.Find("Locomotion System").GetComponent<LocomotionProvider>();

	// 	if (loco.CanBeginLocomotion()) {
	// 		loco.BeginLocomotion("enableTeleportationSystem");
	// 	}

	// }

}
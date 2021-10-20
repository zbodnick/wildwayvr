using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour {

	Vector3 direction; 
	public float jumpForce = 50f;


    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        direction = transform.TransformDirection(Vector3.up * jumpForce);
    }

    void OnCollisionEnter(Collision collision) {
		
		if (collision.gameObject.CompareTag("Player")) {
			// Apply jump force
			collision.gameObject.GetComponent<Rigidbody>().AddForce(direction, ForceMode.Impulse);
		}
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginGame : MonoBehaviour
{

    // Start is called before the first frame update
    void Start() {
    	
    }

    // Update is called once per frame
    void Update() {
        
    }

    private void OnTriggerEnter(Collider other) {

        if (other.gameObject.CompareTag("Player")) {
			// Apply jump force		
			// collision.gameObject.GetComponent<Rigidbody>().isKinematic = false;
			// collision.gameObject.GetComponent<Rigidbody>().useGravity = true;
			other.gameObject.GetComponent<PlayerController>().enabled = true;
		}
    }
}

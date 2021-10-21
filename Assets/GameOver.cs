using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

	public float speed = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    	if (GameObject.FindWithTag("Player").transform.position.z  > -20) {
    		transform.position += Time.deltaTime * new Vector3(0, 0, speed);
    	}
    }

    void OnTriggerEnter(Collider collision) {
		if (collision.gameObject.CompareTag("Player")) {
			collision.gameObject.GetComponent<PlayerController>().Dead();
		}
	}
}

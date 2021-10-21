using UnityEngine;

using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour {

	public float speed;
    private Transform playerTransform;

	private Rigidbody rb;

	void Start () {

		rb = GetComponent<Rigidbody>();
		playerTransform = GameObject.Find("XR Rig").transform;
	}

	void Update() {
		
		Vector3 tempVect = new Vector3(0, 0, 1);
        tempVect = tempVect.normalized * speed * Time.deltaTime;
        rb.MovePosition(transform.position + tempVect);
		// transform.position += Time.deltaTime * new Vector3(0, 0, speed);
	}

}
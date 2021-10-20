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
		// transform.position += Time.deltaTime * new Vector3(0, 0, 2);
	}

	void FixedUpdate () {
		
		playerTransform.Translate(0, 0, speed * Time.deltaTime, Space.Self);

	}

}

// transform.position += Time.deltaTime * new Vector3(0, 0, 2);
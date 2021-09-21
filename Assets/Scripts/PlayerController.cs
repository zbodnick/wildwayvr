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

	void FixedUpdate () {
		
		playerTransform.Translate(0, 0, speed * Time.deltaTime, Space.Self);

	}

}
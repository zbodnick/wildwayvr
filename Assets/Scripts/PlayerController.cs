using UnityEngine;

using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour {

	public float speed;
    private float movementX;
    private float movementY;
    private Transform playerTransform;

	private Rigidbody rb;

	void Start () {

		rb = GetComponent<Rigidbody>();
		playerTransform = GameObject.Find("Player").transform;
	}

	void FixedUpdate () {
		
		playerTransform.Translate(0, 0, speed * Time.deltaTime, Space.Self);

	}

}
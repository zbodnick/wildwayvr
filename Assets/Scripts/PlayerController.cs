using UnityEngine;

using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour {

	public float speed;
    private Transform playerTransform;

	private Rigidbody rb;

	void Start () {

	}

	void Update() {
		
	}

	public void Dead() {
		Time.timeScale = 0;
	}

}
using UnityEngine;
using UnityEngine.InputSystem;

public class CarController : MonoBehaviour {

    public float speed;

    private Transform carTransform;
    private Rigidbody rb;
    private GameObject car;
    private float distTraveled;
    private Vector3 prevPos;
    public float wheelRadius;

    private GameObject backLeftWheel;
    private GameObject backRightWheel;
    private GameObject frontLeftWheel;
    private GameObject frontRightWheel;

	void Start () {

		rb = GetComponent<Rigidbody>();
		carTransform = GameObject.Find("Car").transform;

		prevPos = carTransform.position;

		backLeftWheel = carTransform.GetChild(8).gameObject;
		backRightWheel = carTransform.GetChild(9).gameObject;

		frontLeftWheel = carTransform.GetChild(10).gameObject;
		frontRightWheel = carTransform.GetChild(11).gameObject;
	}

	void FixedUpdate () {
		
		carTransform.Translate(0, 0, speed * Time.deltaTime, Space.Self);

		float distance = Vector3.Distance(prevPos, carTransform.position);
     	distTraveled += distance;
     	prevPos = carTransform.position;

     	float rotationRad = distTraveled / wheelRadius;
		float rotationDeg = rotationRad * Mathf.Rad2Deg;

		backLeftWheel.transform.Rotate(rotationDeg, 0, 0);
		backRightWheel.transform.Rotate(rotationDeg, 0, 0);
		frontLeftWheel.transform.Rotate(-rotationDeg, 0, 0);
		frontRightWheel.transform.Rotate(-rotationDeg, 0, 0);

	}

}
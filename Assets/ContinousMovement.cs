using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class ContinousMovement : MonoBehaviour {

	public XRNode inputSource;
	private Vector2 inputAxis;
	private CharacterController character;
	private XRRig rig;
	private float fallSpeed;

	public LayerMask groundLayer;
	public float addedHeight;

	public float gravity = -9.81f;
	public float speed;


    // Start is called before the first frame update
    void Start() {

    	character = GetComponent<CharacterController>();
    	rig = GetComponent<XRRig>();
        
    }

    // Update is called once per frame
    void Update() {
        
    	InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
    	device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis);

    }


    bool isGrounded() {
    	// Returns true if player is onthe ground, 0 if falling/in space
    	Vector3 rayStart = transform.TransformPoint(character.center);
    	float rayLength = character.center.y + 0.01f;

    	bool hasHit = Physics.SphereCast(rayStart, character.radius, Vector3.down, out RaycastHit hitInfo, rayLength, groundLayer);
    	return hasHit;
    }

    void FixedUdpdate() {

    	CapsuleFollowHeadset();

    	Quaternion headYaw = Quaternion.Euler(0, rig.cameraGameObject.transform.eulerAngles.y, 0);
    	Vector3 direction = headYaw * new Vector3(inputAxis.x, 0, inputAxis.y);
    	character.Move(direction * Time.fixedDeltaTime  * speed);

    	// Applying gravity so that we can move in the horizontal plane

    	if (isGrounded()) {
    		fallSpeed = 0;
    	} else {
    		fallSpeed += gravity * Time.fixedDeltaTime;
    	}
    	character.Move(Vector3.up * fallSpeed * Time.fixedDeltaTime);

    }

    void CapsuleFollowHeadset() {
    	character.height= rig.cameraInRigSpaceHeight + addedHeight;
    	// Centers capsule collider on head
    	Vector3 capsuleCenter = transform.InverseTransformPoint(rig.cameraGameObject.transform.position);
    	character.center = new Vector3(capsuleCenter.x, character.height/2 + character.skinWidth, capsuleCenter.z);
    }

}

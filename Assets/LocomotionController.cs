using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LocomotionController : MonoBehaviour {

    public XRController leftTeleportRay;
    public XRController rightTeleportRay;
    public InputHelpers.Button teleportActivationButton;
    public float activationThreshold = 0.1f;

    public bool EnableLeftTeleport { get; set; } = true;
    public bool EnableRightTeleport { get; set; } = true;

    void Update() {

        if (leftTeleportRay) {
            leftTeleportRay.gameObject.SetActive(EnableLeftTeleport && isActivated(leftTeleportRay));
        }

        if (rightTeleportRay) {
            rightTeleportRay.gameObject.SetActive(EnableRightTeleport && isActivated(rightTeleportRay));
        }
    }

    public bool isActivated(XRController controller) {
        InputHelpers.IsPressed(controller.inputDevice, teleportActivationButton, out bool isActivated, activationThreshold);
        return isActivated;
    }

    public void disableContinousMove() {
    	gameObject.GetComponent<DeviceBasedContinuousMoveProvider>().enabled = false;
    }
}
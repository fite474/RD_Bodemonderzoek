using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRCharacterController : MonoBehaviour
{
    public enum MovementType { CONTINUES, TELEPORTATION }

    public MovementType currentMovementType;
    
    // Continues movement properties
    public float movementSpeed;

    // Teleportation movement properties
    public float maxTeleportDistance;

    // Hands
    public VRHand leftHand;
    public VRHand rightHand;

    //private Rigidbody rigidBody;

    void Start()
    {
        //this.rigidBody = this.gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector2 leftJoystickAxis = this.leftHand.GetJoystickAxis();
        Vector2 rightJoystickAxis = this.rightHand.GetJoystickAxis();

        //Debug.Log("Left axis: X " + leftJoystickAxis.x + " Y " + leftJoystickAxis.y + " Right axis: X " + rightJoystickAxis.x + " Y " + rightJoystickAxis.y);

        if (this.currentMovementType == MovementType.CONTINUES)
        {
            Vector3 movementVector = new Vector3(rightJoystickAxis.x, 0.0f, rightJoystickAxis.y);

            //this.rigidBody.AddForce(movementVector.normalized * (this.movementSpeed * Time.deltaTime), ForceMode.Impulse);
            this.transform.Translate(movementVector.normalized * (this.movementSpeed * Time.deltaTime));
        }
    }
}

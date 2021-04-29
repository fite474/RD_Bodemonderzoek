using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class VRHand : MonoBehaviour
{
    public enum HandType { LEFT, RIGHT }

    public HandType handType;

    private XRController controller;
    private XRDirectInteractor interactor;
    private SphereCollider interractionCollider;

    private InputDevice targetDevice;

    void Start()
    {
        this.controller = this.gameObject.AddComponent<XRController>();
        this.interactor = this.gameObject.AddComponent<XRDirectInteractor>();
        this.interractionCollider = this.gameObject.AddComponent<SphereCollider>();

        this.controller.controllerNode = (this.handType == HandType.LEFT) ? UnityEngine.XR.XRNode.LeftHand : UnityEngine.XR.XRNode.RightHand;
        this.interractionCollider.radius = 0.1f;

        TryInitializeController();
    }

    void Update()
    {
        if (this.targetDevice.isValid)
        {

        }
        else
            TryInitializeController();
    }

    public Vector2 GetJoystickAxis()
    {
        if(this.targetDevice.isValid)
        {
            if (this.targetDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 axisValue))
                return axisValue;
        }
        return Vector2.zero;
    }

    private void TryInitializeController()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(((this.handType == HandType.LEFT) ? InputDeviceCharacteristics.Left : InputDeviceCharacteristics.Right) | InputDeviceCharacteristics.Controller, devices);
        
        if(devices.Count > 0)
        {
            this.targetDevice = devices[0];

            Debug.Log(this.targetDevice.name);
        }
    }
}
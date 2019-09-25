using UnityEngine;

public class VRActorController : ActorController
{
    public Transform controllersParent;
    public OVRInput.Handedness dominantHand = OVRInput.Handedness.RightHanded;

    public override void Update()
    {
        ReadInput();
        base.Update();
    }

    public void ReadInput()
    {
        primaryTriggerValue = OVRInput.Get(dominantHand == OVRInput.Handedness.RightHanded ? OVRInput.RawAxis1D.RIndexTrigger : OVRInput.RawAxis1D.LIndexTrigger, OVRInput.Controller.All);
        primaryJoystick = OVRInput.Get(dominantHand == OVRInput.Handedness.RightHanded ? OVRInput.RawAxis2D.RThumbstick : OVRInput.RawAxis2D.LThumbstick, OVRInput.Controller.All);
        primaryGripValue = OVRInput.Get(dominantHand == OVRInput.Handedness.RightHanded ? OVRInput.RawAxis1D.RHandTrigger : OVRInput.RawAxis1D.LHandTrigger, OVRInput.Controller.All);
        primaryJoystickButton = OVRInput.Get(dominantHand == OVRInput.Handedness.RightHanded ? OVRInput.RawButton.RThumbstick : OVRInput.RawButton.LThumbstick, OVRInput.Controller.All);

        secondaryGripValue = OVRInput.Get(dominantHand == OVRInput.Handedness.RightHanded ? OVRInput.RawAxis1D.LHandTrigger : OVRInput.RawAxis1D.RHandTrigger, OVRInput.Controller.All);
        controllerPosition = controllersParent.TransformPoint(OVRInput.GetLocalControllerPosition(dominantHand == OVRInput.Handedness.RightHanded ? OVRInput.Controller.LTouch : OVRInput.Controller.RTouch));
        controllerRotation = controllersParent.rotation * OVRInput.GetLocalControllerRotation(dominantHand == OVRInput.Handedness.RightHanded ? OVRInput.Controller.LTouch : OVRInput.Controller.RTouch);
    }
}

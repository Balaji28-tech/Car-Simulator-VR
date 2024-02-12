
namespace CS.Inputs
{
    public class OculusInput : IPlayerInput
    {
        public bool IsAccelButtonPressed()
        {
            return OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch);
        }

        public bool IsReversePressed()
        {
            return OVRInput.GetDown(OVRInput.Button.Two);
        }

        public bool IsForwardPressed()
        {
            return OVRInput.GetDown(OVRInput.Button.One);
        }

        public bool IsBreakButtonPressed()
        {
            return OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger, OVRInput.Controller.RTouch);
        }

        public bool IsTurningLeftButtonPressed()
        {
            return OVRInput.GetDown(OVRInput.Button.PrimaryThumbstickLeft, OVRInput.Controller.RTouch);
        }

        public bool IsTurningRightButtonPressed()
        {
            return OVRInput.GetDown(OVRInput.Button.PrimaryThumbstickRight, OVRInput.Controller.RTouch);
        }
    }

}

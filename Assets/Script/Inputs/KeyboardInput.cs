using UnityEngine;

namespace CS.Inputs
{
    public class KeyboardInput : IPlayerInput
    {
        public bool IsAccelButtonPressed()
        {
            return Input.GetKey(KeyCode.W);
        }

        public bool IsReversePressed()
        {
            return Input.GetKeyDown(KeyCode.R);
        }

        public bool IsForwardPressed()
        {
            return Input.GetKeyDown(KeyCode.F);
        }

        public bool IsBreakButtonPressed()
        {
            return Input.GetKey(KeyCode.Space);
        }

        public bool IsTurningLeftButtonPressed()
        {
            return Input.GetKey(KeyCode.A);
        }

        public bool IsTurningRightButtonPressed()
        {
            return Input.GetKey(KeyCode.D);
        }
    }

}

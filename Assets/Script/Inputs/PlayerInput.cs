using UnityEngine;
using CS.Helper;

namespace CS.Inputs
{
    public class PlayerInput : MonoBehaviour
    {
        private IPlayerInput keyBoardInput;
        private IPlayerInput oculusInput;

        

        private void Start() {
            keyBoardInput = new KeyboardInput();
            oculusInput = new OculusInput();
        }
        private void Update() {
            DefaultControls();
        }

        private void DefaultControls()
        {
            GetPlayerControllerInput();

            GlobalConstants.Acceleration = GlobalConstants.IsAccel ? GlobalConstants.AccelValue : (GlobalConstants.IsBreak ? -0.5f : 0f);

            GlobalConstants.Steering = GlobalConstants.IsTurningLeft ? -1f : (GlobalConstants.IsTurningRight ? 1f : 0f);
        }

        private void GetPlayerControllerInput()
        {
            bool isAccelButtonPressed = oculusInput.IsAccelButtonPressed() || keyBoardInput.IsAccelButtonPressed();
            bool isBreakButtonPressed = oculusInput.IsBreakButtonPressed() || keyBoardInput.IsBreakButtonPressed();
            bool isTurningLeftButtonPressed = oculusInput.IsTurningLeftButtonPressed() || keyBoardInput.IsTurningLeftButtonPressed();
            bool isTurningRightButtonPressed = oculusInput.IsTurningRightButtonPressed() || keyBoardInput.IsTurningRightButtonPressed();

            bool isReverse = oculusInput.IsReversePressed() || keyBoardInput.IsReversePressed();
            bool isForward = oculusInput.IsForwardPressed() || keyBoardInput.IsForwardPressed();

            GlobalConstants.IsAccel = isAccelButtonPressed;
            GlobalConstants.IsBreak = isBreakButtonPressed;
            GlobalConstants.IsTurningLeft = isTurningLeftButtonPressed;
            GlobalConstants.IsTurningRight = isTurningRightButtonPressed;
            
            if(isReverse)
                GlobalConstants.AccelValue = -1f;
            else if(isForward)
                GlobalConstants.AccelValue = 1f;

        }
    }
}

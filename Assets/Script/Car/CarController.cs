using CS.Helper;
using UnityEngine;

namespace CS.Car.Controller
{
    public class CarController : AbstractCarController
    {
        protected override void HandleMotor()
        {
            frontLeftWheelCollider.motorTorque = GlobalConstants.Acceleration * GlobalConstants.MotorForce * Time.deltaTime;
            frontRightWheelCollider.motorTorque = GlobalConstants.Acceleration * GlobalConstants.MotorForce * Time.deltaTime;
            currentBreakForce = GlobalConstants.IsBreak ? GlobalConstants.BreakForce : 0f;
            ApplyBraking();
        }

        protected override void HandleSteering()
        {
            currentSteerAngle = GlobalConstants.MaxSteerAngle * GlobalConstants.Steering;
            frontLeftWheelCollider.steerAngle = currentSteerAngle;
            frontRightWheelCollider.steerAngle = currentSteerAngle;
        }

        protected override void ApplyBraking()
        {
            ApplyBrake(currentBreakForce);
        }

        protected override void UpdateWheels()
        {
            UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
            UpdateSingleWheel(frontRightWheelCollider, frontRightWheelTransform);
            UpdateSingleWheel(rearRightWheelCollider, rearRightWheelTransform);
            UpdateSingleWheel(rearLeftWheelCollider, rearLeftWheelTransform);
        }
    }
}

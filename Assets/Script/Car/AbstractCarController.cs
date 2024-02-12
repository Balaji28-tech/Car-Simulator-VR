using CS.Helper;
using UnityEngine;

namespace CS.Car.Controller
{
    public abstract class AbstractCarController : MonoBehaviour
    {
        [SerializeField] protected WheelCollider frontLeftWheelCollider, frontRightWheelCollider;
        [SerializeField] protected WheelCollider rearLeftWheelCollider, rearRightWheelCollider;

        // Wheels
        [SerializeField] protected Transform frontLeftWheelTransform, frontRightWheelTransform;
        [SerializeField] protected Transform rearLeftWheelTransform, rearRightWheelTransform;
        [SerializeField] protected GameObject steeringWheel;
        public float maxSteerAngle = 70f;
        public float rotationSpeed = 100f;
        protected float rotationAmount;

        protected float currentSteerAngle, currentBreakForce;

        protected abstract void HandleMotor();

        protected abstract void HandleSteering();

        protected abstract void ApplyBraking();

        protected abstract void UpdateWheels();

        protected void FixedUpdate()
        {
            HandleMotor();
            HandleSteering();
            SteeringWheel();
            UpdateWheels();
        }

        private void SteeringWheel()
        {
            rotationAmount = GlobalConstants.Steering * maxSteerAngle;
            float rotationTarget = Mathf.MoveTowardsAngle(steeringWheel.transform.localRotation.eulerAngles.z,
                                -rotationAmount, rotationSpeed * Time.deltaTime);

            steeringWheel.transform.localRotation = Quaternion.Euler(27.451f, 0, rotationTarget);
        }

        protected void ApplyBrake(float currentBreakForce)
        {
            frontRightWheelCollider.brakeTorque = currentBreakForce;
            frontLeftWheelCollider.brakeTorque = currentBreakForce;
            rearLeftWheelCollider.brakeTorque = currentBreakForce;
            rearRightWheelCollider.brakeTorque = currentBreakForce;
        }

        protected void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
        {
            Vector3 pos;
            Quaternion rot;
            wheelCollider.GetWorldPose(out pos, out rot);
            wheelTransform.rotation = rot;
            wheelTransform.position = pos;
        }
    }
}

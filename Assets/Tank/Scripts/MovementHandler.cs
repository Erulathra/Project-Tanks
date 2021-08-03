using UnityEngine;

namespace Tank.Scripts {
    public class MovementHandler
    {
        private GamepadHandler gamepad;
        private Rigidbody tankRigidBody;
    
        private float motorForce = 100f;
        private float maxSpeed = 100;

        private float breakingForce = 100f;
        private float steerAngle = 30f;

        private WheelCollider frontRightWheel;
        private WheelCollider frontLeftWheel;
        private WheelCollider rearRightWheel;
        private WheelCollider rearLeftWheel;
    
        private bool isBreaking;

        public MovementHandler(TankController tankController) {
            gamepad = tankController.Gamepad;
            tankRigidBody = tankController.TankRigidBody;

            motorForce = tankController.MotorForce;
            maxSpeed = tankController.MaxSpeed;

            breakingForce = tankController.BreakingForce;
            steerAngle = tankController.SteerAngle;

            frontRightWheel = tankController.FrontRightWheel;
            frontLeftWheel = tankController.FrontLeftWheel;
            rearRightWheel = tankController.RearRightWheel;
            rearLeftWheel = tankController.RearLeftWheel;
        }

        public void HandleMotor() {
            if (gamepad.IsBreaking) return;
            if (tankRigidBody.velocity.magnitude > maxSpeed) return;

            var acceleration = gamepad.AccelerateFront - gamepad.AccelerateBack;
            BrakeWhenAccelerateInAnotherDirection(acceleration);
            if (isBreaking) return;
            
            frontRightWheel.motorTorque = motorForce * acceleration;
            frontLeftWheel.motorTorque = motorForce * acceleration;
        }

        private void BrakeWhenAccelerateInAnotherDirection(float acceleration) {
            var velocity = tankRigidBody.transform.InverseTransformDirection(tankRigidBody.velocity);
            var isAccelerationInOppositeDirection = acceleration < 0 && velocity.z > 0.2f || acceleration > 0 && velocity.z < -0.2f;

            isBreaking = isAccelerationInOppositeDirection;
        }

        public void HandleBreaking() {
            ApplyBreaking(isBreaking || gamepad.IsBreaking ? breakingForce : 0f);
        }

        private void ApplyBreaking(float force) {
            frontRightWheel.brakeTorque = force;
            frontLeftWheel.brakeTorque = force;
            rearRightWheel.brakeTorque = force;
            rearLeftWheel.brakeTorque = force;
        }

        public void HandleSteering() {
            var actualSteerAngle = gamepad.MoveVector.x * steerAngle;
            frontLeftWheel.steerAngle = actualSteerAngle;
            frontRightWheel.steerAngle = actualSteerAngle;
        }
    }
}

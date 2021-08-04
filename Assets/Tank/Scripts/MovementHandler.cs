using UnityEngine;

namespace Tank.Scripts
{
	public class MovementHandler
	{
		private readonly float breakingForce;
		private readonly WheelCollider frontLeftWheel;

		private readonly WheelCollider frontRightWheel;
		private readonly GamepadHandler gamepad;
		private readonly float maxSpeed;

		private readonly float motorForce;
		private readonly WheelCollider rearLeftWheel;
		private readonly WheelCollider rearRightWheel;
		private readonly float steerAngle;
		private readonly Rigidbody tankRigidBody;

		private bool isBreaking;

		public MovementHandler(TankController tankController)
		{
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

		public void HandleMotor()
		{
			if (gamepad.IsBreaking) return;
			if (tankRigidBody.velocity.magnitude > maxSpeed) return;

			var acceleration = gamepad.AccelerateFront - gamepad.AccelerateBack;
			BrakeWhenAccelerateInAnotherDirection(acceleration);
			if (isBreaking) return;

			frontRightWheel.motorTorque = motorForce * acceleration;
			frontLeftWheel.motorTorque = motorForce * acceleration;
		}

		private void BrakeWhenAccelerateInAnotherDirection(float acceleration)
		{
			var velocity = tankRigidBody.transform.InverseTransformDirection(tankRigidBody.velocity);
			var isAccelerationInOppositeDirection =
				acceleration < 0 && velocity.z > 0.2f || acceleration > 0 && velocity.z < -0.2f;

			isBreaking = isAccelerationInOppositeDirection;
		}

		public void HandleBreaking()
		{
			ApplyBreaking(isBreaking || gamepad.IsBreaking ? breakingForce : 0f);
		}

		private void ApplyBreaking(float force)
		{
			frontRightWheel.brakeTorque = force;
			frontLeftWheel.brakeTorque = force;
			rearRightWheel.brakeTorque = force;
			rearLeftWheel.brakeTorque = force;
		}

		public void HandleSteering()
		{
			var actualSteerAngle = gamepad.MoveVector.x * steerAngle;
			frontLeftWheel.steerAngle = actualSteerAngle;
			frontRightWheel.steerAngle = actualSteerAngle;
		}
	}
}
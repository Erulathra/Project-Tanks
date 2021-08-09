using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

namespace Tank.Scripts
{
	public class MovementHandler
	{
		private readonly float breakingForce;
		private readonly WheelCollider frontLeftWheel;

		private readonly WheelCollider frontRightWheel;
		private readonly IGamepadHandler gamepad;
		private readonly float maxSpeed;

		private readonly float motorForce;
		private readonly float motorResistance;
		private readonly WheelCollider rearLeftWheel;
		private readonly WheelCollider rearRightWheel;
		private readonly float steerAngle;
		private readonly Rigidbody tankRigidBody;

		private bool isBreaking;

		public MovementHandler(TankMovementController tankMovementController)
		{
			gamepad = tankMovementController.GamepadHandler;
			tankRigidBody = tankMovementController.TankRigidBody;

			motorForce = tankMovementController.MotorForce;
			maxSpeed = tankMovementController.MaxSpeed;

			breakingForce = tankMovementController.BreakingForce;
			steerAngle = tankMovementController.SteerAngle;

			frontRightWheel = tankMovementController.FrontRightWheel;
			frontLeftWheel = tankMovementController.FrontLeftWheel;
			rearRightWheel = tankMovementController.RearRightWheel;
			rearLeftWheel = tankMovementController.RearLeftWheel;
			motorResistance = tankMovementController.MotorResistance;
		}

		public void HandleMotor()
		{
			if (IsBreaking()) return;
			var actualMotorTorque = motorForce * Acceleration();
			if (tankRigidBody.velocity.magnitude > maxSpeed) actualMotorTorque = 0;
			ApplyMotorTorqueToFrontWheels(actualMotorTorque);
		}

		private void ApplyMotorTorqueToFrontWheels(float actualMotorForce)
		{
			frontRightWheel.motorTorque = actualMotorForce;
			frontLeftWheel.motorTorque = actualMotorForce;
		}

		private bool IsBreaking()
		{
			return isBreaking || gamepad.IsBreaking;
		}

		private float Acceleration()
		{
			return gamepad.AccelerateFront - gamepad.AccelerateBack;
		}
		
		private void BrakeWhenAccelerateInAnotherDirection(float acceleration)
		{
			var velocity = tankRigidBody.transform.InverseTransformDirection(tankRigidBody.velocity);
			isBreaking = (acceleration < 0 && velocity.z > 0.2f) || (acceleration > 0 && velocity.z < -0.2f);
		}

		public void HandleBreaking()
		{
			BrakeWhenAccelerateInAnotherDirection(Acceleration());
			ApplyBreaking(IsBreaking() ? breakingForce : 0f);
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

		public void HandleIdleMotorResistance()
		{
			if (Acceleration() == 0 && tankRigidBody.velocity.magnitude != 0)
				ApplyBreaking(motorResistance);
		}
	}
}
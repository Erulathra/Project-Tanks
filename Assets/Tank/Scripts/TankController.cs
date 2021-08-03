using System;
using UnityEngine;

[RequireComponent(typeof(GamepadHandler))]
public class TankController : MonoBehaviour {
	[SerializeField] private Transform tower;
	[SerializeField] private Transform centerOfMass;

	[Header("Tower")] [SerializeField] private float towerRotationSpeed;

	[Header("Riding")] [SerializeField] private float motorForce = 100f;
	[SerializeField] private float maxSpeed = 100;

	[SerializeField] private float breakingForce = 100f;
	[SerializeField] private float steerAngle = 30f;

	[Header("Wheels")] [SerializeField] private WheelCollider frontRightWheel;

	[SerializeField] private WheelCollider frontLeftWheel;
	[SerializeField] private WheelCollider rearRightWheel;
	[SerializeField] private WheelCollider rearLeftWheel;
	private GamepadHandler gamepad;

	private Rigidbody tankRigidBody;
	private bool isBreaking;

	private void Start() {
		tankRigidBody = gameObject.GetComponent<Rigidbody>();
		gamepad = gameObject.GetComponent<GamepadHandler>();
		tankRigidBody.centerOfMass = centerOfMass.localPosition;
	}

	private void Update() {
		HandleAim();
	}

	private void FixedUpdate() {
		HandleMotor();
		HandleBreaking();
		HandleSteering();
	}

	private void HandleMotor() {
		if (gamepad.isBreaking) return;
		if (tankRigidBody.velocity.magnitude >= maxSpeed) return;
		
		var acceleration = gamepad.accelerateFront - gamepad.accelerateBack;

		BrakeWhenAccelerateInAnotherDirection(acceleration);

		if (isBreaking) return;
		frontRightWheel.motorTorque = motorForce * acceleration;
		frontLeftWheel.motorTorque = motorForce * acceleration;
	}

	private void BrakeWhenAccelerateInAnotherDirection(float acceleration) {
		var velocity = transform.InverseTransformDirection(tankRigidBody.velocity);
		var isAccelerationInOppositeDirection = acceleration < 0 && velocity.z > 0.2f || acceleration > 0 && velocity.z < -0.2f;

		isBreaking = isAccelerationInOppositeDirection;
	}

	private void HandleBreaking() {
		ApplyBreaking(isBreaking || gamepad.isBreaking ? breakingForce : 0f);
	}

	private void ApplyBreaking(float force) {
		frontRightWheel.brakeTorque = force;
		frontLeftWheel.brakeTorque = force;
		rearRightWheel.brakeTorque = force;
		rearLeftWheel.brakeTorque = force;
	}

	private void HandleSteering() {
		var actualSteerAngle = gamepad.moveVector.x * steerAngle;
		frontLeftWheel.steerAngle = actualSteerAngle;
		frontRightWheel.steerAngle = actualSteerAngle;
	}

	#region Tower

	private void HandleAim() {
		if (gamepad.aimVector == Vector2.zero) return;

		var angle = Vector2ToAngle(gamepad.aimVector);
		
		var newRotation = tower.localEulerAngles;
		newRotation.y = Mathf.LerpAngle(newRotation.y, angle - transform.eulerAngles.y + 90, towerRotationSpeed * Time.deltaTime);

		tower.localEulerAngles = newRotation;
	}

	private static float Vector2ToAngle(Vector2 vector2) {
		float angle;
		if (vector2.y >= 0)
			angle = (float) (-Mathf.Rad2Deg * Math.Acos(Vector2.Dot(vector2, Vector2.right) / vector2.magnitude));
		else
			angle = (float) (Mathf.Rad2Deg * Math.Acos(Vector2.Dot(vector2, Vector2.right) / vector2.magnitude));
		return angle;
	}

	#endregion
}
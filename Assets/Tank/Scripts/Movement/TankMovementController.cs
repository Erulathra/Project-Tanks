using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Tank.Scripts
{
	public class TankMovementController : MonoBehaviour
	{
		[FormerlySerializedAs("tower")] [SerializeField]
		private Transform towerTransform;

		[SerializeField] private Transform centerOfMass;

		[Header("Tower")] [SerializeField] private float towerRotationSpeed;

		[Header("Riding")] 
		[SerializeField] private float motorForce = 100f;
		[SerializeField] private float maxSpeed = 100f;
		[SerializeField] private float motorResistance = 10f;

		[SerializeField] private float breakingForce = 100f;
		[SerializeField] private float steerAngle = 30f;

		[Header("Wheels")] 
		[SerializeField] private WheelCollider frontRightWheel;
		[SerializeField] private WheelCollider frontLeftWheel;
		[SerializeField] private WheelCollider rearRightWheel;
		[SerializeField] private WheelCollider rearLeftWheel;

		private MovementHandler movementHandler;
		private AimHandler aimHandler;
		public IGamepadHandler GamepadHandler { get; private set; }

		private void Start()
		{
			TankRigidBody = GetComponent<Rigidbody>();
			GamepadHandler = GetComponent<IGamepadHandler>();
			if (GamepadHandler == null) throw new NullReferenceException("gamepadHandler");

			movementHandler = new MovementHandler(this);
			aimHandler = new AimHandler(this);

			TankRigidBody.centerOfMass = centerOfMass.localPosition;
		}

		private void Update()
		{
			aimHandler.HandleAim();
		}

		private void FixedUpdate()
		{
			movementHandler.HandleMotor();
			movementHandler.HandleBreaking();
			movementHandler.HandleIdleMotorResistance();
			movementHandler.HandleSteering();
		}

		#region Properties

		public float MotorResistance => motorResistance;

		public Transform TowerTransform => towerTransform;

		public float TowerRotationSpeed => towerRotationSpeed;

		public float MotorForce => motorForce;

		public float MaxSpeed => maxSpeed;

		public float BreakingForce => breakingForce;

		public float SteerAngle => steerAngle;

		public WheelCollider FrontRightWheel => frontRightWheel;

		public WheelCollider FrontLeftWheel => frontLeftWheel;

		public WheelCollider RearRightWheel => rearRightWheel;

		public WheelCollider RearLeftWheel => rearLeftWheel;

		public Rigidbody TankRigidBody { get; private set; }
	
		#endregion
	}
}
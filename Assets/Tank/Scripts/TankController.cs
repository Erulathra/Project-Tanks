using Tank.Scripts;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(GamepadHandler))]
public class TankController : MonoBehaviour
{
	[FormerlySerializedAs("tower")] [SerializeField]
	private Transform towerTransform;

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

	private void Start()
	{
		TankRigidBody = GetComponent<Rigidbody>();
		Gamepad = GetComponent<GamepadHandler>();

		MovementHandler = new MovementHandler(this);
		AimHandler = new AimHandler(this);

		TankRigidBody.centerOfMass = centerOfMass.localPosition;
	}

	private void Update()
	{
		AimHandler.HandleAim();
	}

	private void FixedUpdate()
	{
		MovementHandler.HandleMotor();
		MovementHandler.HandleBreaking();
		MovementHandler.HandleSteering();
	}

	#region Properties

	public GamepadHandler Gamepad { get; private set; }

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

	public MovementHandler MovementHandler { get; private set; }

	public AimHandler AimHandler { get; private set; }

	#endregion
}
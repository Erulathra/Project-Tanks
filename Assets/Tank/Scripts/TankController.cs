using Tank.Scripts;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(GamepadHandler))]
public class TankController : MonoBehaviour {
	[FormerlySerializedAs("tower")] [SerializeField] private Transform towerTransform;
	[SerializeField] private Transform centerOfMass;

	[Header("Tower")]
	[SerializeField] private float towerRotationSpeed;

	[Header("Riding")]
	[SerializeField] private float motorForce = 100f;
	[SerializeField] private float maxSpeed = 100;

	[SerializeField] private float breakingForce = 100f;
	[SerializeField] private float steerAngle = 30f;

	[Header("Wheels")]
	[SerializeField] private WheelCollider frontRightWheel;
	[SerializeField] private WheelCollider frontLeftWheel;
	[SerializeField] private WheelCollider rearRightWheel;
	[SerializeField] private WheelCollider rearLeftWheel;

	private Rigidbody tankRigidBody;

	private MovementHandler movementHandler;
	private AimHandler aimHandler;

	private GamepadHandler gamepad;

	#region Properties

	public GamepadHandler Gamepad => gamepad;

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

	public Rigidbody TankRigidBody => tankRigidBody;

	public MovementHandler MovementHandler => movementHandler;

	public AimHandler AimHandler => aimHandler;

	#endregion

	private void Start() {
		tankRigidBody = GetComponent<Rigidbody>();
		gamepad = GetComponent<GamepadHandler>();

		movementHandler = new MovementHandler(this);
		aimHandler = new AimHandler(this);
		
		tankRigidBody.centerOfMass = centerOfMass.localPosition;
	}

	private void Update() {
		aimHandler.HandleAim();
	}

	private void FixedUpdate() {
		movementHandler.HandleMotor();
		movementHandler.HandleBreaking();
		movementHandler.HandleSteering();
	}
	
}
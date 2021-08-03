using System;
using UnityEngine;

public class GamepadHandler : MonoBehaviour {
	[Header("Gamepad variables")] [SerializeField]
	private float rightAnalogDeadZone = 0.1f;

	[SerializeField] private float leftAnalogDeadZone = 0.1f;

	private TankKeyMap tankKeyMap;
	public Vector2 aimVector { get; private set; }
	public Vector2 moveVector { get; private set; }
	public float accelerateFront { get; private set; }
	public float accelerateBack { get; private set; }
	public bool isBreaking { get; private set; }

	private void Awake() {
		SetControls();
	}

	private void Update() {
		if (moveVector.magnitude < rightAnalogDeadZone) moveVector = Vector2.zero;
		if (aimVector.magnitude < leftAnalogDeadZone) aimVector = Vector2.zero;
	}

	private void OnEnable() {
		tankKeyMap.General.Enable();
	}

	private void OnDisable() {
		tankKeyMap.General.Disable();
	}

	private void SetControls() {
		tankKeyMap = new TankKeyMap();

		tankKeyMap.General.Move.performed += ctx => moveVector = ctx.ReadValue<Vector2>();
		tankKeyMap.General.Aim.performed += ctx => aimVector = ctx.ReadValue<Vector2>();
		tankKeyMap.General.AccelerateFront.performed += ctx => accelerateFront = ctx.ReadValue<float>();
		tankKeyMap.General.AccelerateBack.performed += ctx => accelerateBack = ctx.ReadValue<float>();
		tankKeyMap.General.HandBrake.performed += _ => isBreaking = true;

		tankKeyMap.General.Move.canceled += _ => moveVector = Vector2.zero;
		tankKeyMap.General.Aim.canceled += _ => aimVector = Vector2.zero;
		tankKeyMap.General.AccelerateFront.canceled += _ => accelerateFront = 0f;
		tankKeyMap.General.AccelerateBack.canceled += _ => accelerateBack = 0f;
		tankKeyMap.General.HandBrake.canceled += _ => isBreaking = false;
	}
}
using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Tank.Scripts
{
	public class GamepadHandler : MonoBehaviour, IGamepadHandler
	{
		[Header("Gamepad variables")] [SerializeField]
		private float rightAnalogDeadZone = 0.1f;

		[SerializeField] private float leftAnalogDeadZone = 0.1f;

		private TankKeyMap tankKeyMap;


		private void Awake()
		{
			SetControls();
		}

		private void OnEnable()
		{
			tankKeyMap.General.Enable();
		}

		private void OnDisable()
		{
			tankKeyMap.General.Disable();
		}

		public Vector2 AimVector { get; private set; }
		public Vector2 MoveVector { get; private set; }
		public float AccelerateFront { get; private set; }
		public float AccelerateBack { get; private set; }
		public bool IsBreaking { get; private set; }
		public bool IsShooting { get; private set; }
		public event Action OnShoot;

		private void SetControls()
		{
			tankKeyMap = new TankKeyMap();

			tankKeyMap.General.Move.performed += MoveInputAction;
			tankKeyMap.General.Aim.performed += AimInputAction;

			tankKeyMap.General.AccelerateFront.performed += ctx => AccelerateFront = ctx.ReadValue<float>();
			tankKeyMap.General.AccelerateBack.performed += ctx => AccelerateBack = ctx.ReadValue<float>();
			tankKeyMap.General.HandBrake.performed += _ => IsBreaking = true;
			tankKeyMap.General.Shoot.performed += _ => OnShoot?.Invoke();

			tankKeyMap.General.Move.canceled += _ => MoveVector = Vector2.zero;
			tankKeyMap.General.Aim.canceled += _ => AimVector = Vector2.zero;
			tankKeyMap.General.AccelerateFront.canceled += _ => AccelerateFront = 0f;
			tankKeyMap.General.AccelerateBack.canceled += _ => AccelerateBack = 0f;
		}

		private void MoveInputAction(InputAction.CallbackContext ctx)
		{
			MoveVector = ctx.ReadValue<Vector2>();
			if (MoveVector.magnitude < rightAnalogDeadZone) MoveVector = Vector2.zero;
		}

		private void AimInputAction(InputAction.CallbackContext ctx)
		{
			AimVector = ctx.ReadValue<Vector2>();
			if (AimVector.magnitude < leftAnalogDeadZone) AimVector = Vector2.zero;
		}
		
	}
}
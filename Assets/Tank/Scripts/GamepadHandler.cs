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
		
		public Vector2 AimVector { get; private set; }
		public Vector2 MoveVector { get; private set; }
		public float AccelerateFront { get; private set; }
		public float AccelerateBack { get; private set; }
		public bool IsBreaking { get; private set; }
		public bool IsShooting { get; private set; }
		public event Action OnShoot;
		
		public void OnHandBrake(InputAction.CallbackContext ctx)
		{
			IsBreaking = true;
		}

		public void Shoot(InputAction.CallbackContext ctx)
		{
			OnShoot?.Invoke();
		}

		public void OnAccelerateBack(InputAction.CallbackContext ctx)
		{
			AccelerateBack = ctx.ReadValue<float>();
		}

		public void OnAccelerateFront(InputAction.CallbackContext ctx)
		{
			AccelerateFront = ctx.ReadValue<float>();
		}

		public void OnMove(InputAction.CallbackContext ctx)
		{
			MoveVector = ctx.ReadValue<Vector2>();
			if (MoveVector.magnitude < rightAnalogDeadZone) MoveVector = Vector2.zero;
		}

		public void OnAim(InputAction.CallbackContext ctx)
		{
			AimVector = ctx.ReadValue<Vector2>();
			if (AimVector.magnitude < leftAnalogDeadZone) AimVector = Vector2.zero;
		}

	}
}
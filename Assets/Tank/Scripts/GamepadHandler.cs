using System;
using PlayerManagement;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Tank.Scripts
{
	public class GamepadHandler : MonoBehaviour, IInputHandler
	{
		public Vector2 AimVector { get; private set; }
		public Vector2 MoveVector { get; private set; }
		public float AccelerateFront { get; private set; }
		public float AccelerateBack { get; private set; }
		public bool IsBreaking { get; private set; }
		public bool IsShooting { get; private set; }
		public event Action OnShootEvent;
		
		public void OnHandBrake(InputValue value)
		{
			IsBreaking = value.Get<float>() > 0;
		}
		
		public void OnShoot(InputValue value)
		{
			OnShootEvent?.Invoke();
		}

		public void OnAccelerateBack(InputValue value)
		{
			AccelerateBack = value.Get<float>();
		}

		public void OnAccelerateFront(InputValue value)
		{
			AccelerateFront = value.Get<float>();
		}

		public void OnMove(InputValue value)
		{
			MoveVector = value.Get<Vector2>();
		}

		public void OnAim(InputValue value)
		{
			AimVector = value.Get<Vector2>();
		}

	}
}
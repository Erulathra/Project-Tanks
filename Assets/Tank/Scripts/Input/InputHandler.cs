using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Tank.Scripts.Input
{
	public class InputHandler : MonoBehaviour, IInputHandler
	{
		public IInputAimHandler AimHandler { get; set; }
		
		public Vector2 AimVector { get; private set; }
		public Vector2 MoveVector { get; private set; }
		public float AccelerateFront { get; private set; }
		public float AccelerateBack { get; private set; }
		public bool IsBreaking { get; private set; }
		public bool IsShooting { get; private set; }
		public event Action OnShootEvent;

		private void Start()
		{
			AimHandler ??= GetComponent<IInputAimHandler>();
		}

		private void Update()
		{
			AimVector = AimHandler.AimVector;
		}
		

		private void OnHandBrake(InputValue value)
		{
			IsBreaking = value.isPressed;
		}

		private void OnShoot(InputValue value)
		{
			IsShooting = value.isPressed;
			OnShootEvent?.Invoke();
		}

		private void OnAccelerateBack(InputValue value)
		{
			AccelerateBack = value.Get<float>();
		}

		private void OnAccelerateFront(InputValue value)
		{
			AccelerateFront = value.Get<float>();
		}

		private void OnMove(InputValue value)
		{
			MoveVector = value.Get<Vector2>();
		}
	}
}
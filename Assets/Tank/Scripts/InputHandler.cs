using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Tank.Scripts
{
	public class InputHandler : MonoBehaviour, IInputHandler
	{
		public Vector2 AimVector { get; private set; }
		public Vector2 MoveVector { get; private set; }
		public float AccelerateFront { get; private set; }
		public float AccelerateBack { get; private set; }
		public bool IsBreaking { get; private set; }
		public bool IsShooting { get; private set; }
		public event Action OnShootEvent;
    
		
		
		private void Start()
		{
			
		}
    
		public void OnHandBrake(InputAction.CallbackContext ctx)
		{
			IsBreaking = true;
		}
    
		public void Shoot(InputAction.CallbackContext ctx)
		{
			OnShootEvent?.Invoke();
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
		}
    
		
	}
}

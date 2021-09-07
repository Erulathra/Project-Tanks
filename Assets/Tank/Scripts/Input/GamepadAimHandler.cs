using Tank.Scripts.Input;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Tank.Scripts
{
	public class GamepadAimHandler : MonoBehaviour, IInputAimHandler
	{
		public Vector2 AimVector { get; private set; }

		public void OnAim(InputValue value)
		{
			AimVector = value.Get<Vector2>();
		}
	}
}
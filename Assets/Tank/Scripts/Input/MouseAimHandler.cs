using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Tank.Scripts.Input
{
	public class MouseAimHandler : MonoBehaviour, IInputAimHandler
	{
		public Vector2 AimVector { get; private set; }

		private Camera cam;

		private void Start()
		{
			cam = Camera.main;
			if(cam == null) Debug.Break();
		}

		private void Update()
		{
			Vector2 tankScreenPosition = GetTankScreenPosition();
			Vector2 mouseScreenPosition = GetMouseScreenPosition();

			var tankToMouseVector = mouseScreenPosition - tankScreenPosition;
			AimVector = tankToMouseVector.normalized;
		}

		private Vector2 GetTankScreenPosition()
		{
			var tankScreenPosition = cam.WorldToScreenPoint(transform.position);
			return new Vector2(tankScreenPosition.x, tankScreenPosition.y);
		}

		private Vector2 GetMouseScreenPosition()
		{
			return Mouse.current.position.ReadValue();
		}
	}
}
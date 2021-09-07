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
			AimVector = GetWorldSpaceVector();
		}

		private Vector2 GetWorldSpaceVector()
		{
			Vector2 tankPosition = GetTankPosition();
			Vector2 mouseWorldRaycast = GetMouseWorldRaycast();

			return mouseWorldRaycast - tankPosition;
		}

		private Vector2 GetMouseWorldRaycast()
		{
			var mousePosition = Mouse.current.position.ReadValue();
			var result = GetPointFromRaycastFromMousePosition(mousePosition);
			return result;
		}

		private Vector2 GetPointFromRaycastFromMousePosition(Vector2 mousePosition)
		{
			var ray = cam.ViewportPointToRay(cam.ScreenToViewportPoint(mousePosition));
			Physics.Raycast(ray, out var hit);
			var result = new Vector2(hit.point.x, hit.point.z);
			return result;
		}

		private Vector2 GetTankPosition()
		{
			var position = transform.position;
			var result = new Vector2(position.x, position.z);
			return result;
		}

		private Vector2 GetScreenSpaceVector()
		{
			Vector2 tankScreenPosition = GetTankScreenPosition();
			Vector2 mouseScreenPosition = GetMouseScreenPosition();

			var tankToMouseVector = mouseScreenPosition - tankScreenPosition;
			return tankToMouseVector.normalized;
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
using System;
using JetBrains.Annotations;
using UnityEngine;

namespace Tank.Scripts
{
	public class AimHandler
	{
		[NotNull] private readonly GamepadHandler gamepad;
		private readonly Transform tankTransform;
		private readonly float towerRotationSpeed;
		private readonly Transform towerTransform;

		public AimHandler(TankController tankController)
		{
			gamepad = tankController.Gamepad;
			towerTransform = tankController.TowerTransform;
			tankTransform = tankController.transform;
			towerRotationSpeed = tankController.TowerRotationSpeed;
		}

		public void HandleAim()
		{
			if (gamepad.AimVector == Vector2.zero) return;

			var angle = Vector2ToAngle(gamepad.AimVector);

			var newRotation = towerTransform.localEulerAngles;
			newRotation.y = Mathf.LerpAngle(newRotation.y, angle - tankTransform.eulerAngles.y + 90,
				towerRotationSpeed * Time.deltaTime);

			towerTransform.localEulerAngles = newRotation;
		}

		private static float Vector2ToAngle(Vector2 vector2)
		{
			float angle;
			if (vector2.y >= 0)
				angle = (float) (-Mathf.Rad2Deg * Math.Acos(Vector2.Dot(vector2, Vector2.right) / vector2.magnitude));
			else
				angle = (float) (Mathf.Rad2Deg * Math.Acos(Vector2.Dot(vector2, Vector2.right) / vector2.magnitude));
			return angle;
		}
	}
}
using System;
using UnityEngine;

namespace Tank.Scripts
{
	public interface IInputHandler
	{
		Vector2 AimVector { get; }
		Vector2 MoveVector { get; }
		float AccelerateFront { get; }
		float AccelerateBack { get; }
		bool IsBreaking { get; }
		bool IsShooting { get; }
		public event Action OnShootEvent;
	}
}
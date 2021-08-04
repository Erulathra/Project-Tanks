using UnityEngine;

namespace Tank.Scripts
{
	public interface IGamepadHandler
	{
		Vector2 AimVector { get; }
		Vector2 MoveVector { get; }
		float AccelerateFront { get; }
		float AccelerateBack { get; }
		bool IsBreaking { get; }
	}
}
using UnityEngine;

namespace Tank.Scripts.Input
{
	public interface IInputAimHandler
	{
		Vector2 AimVector { get; }
	}
}
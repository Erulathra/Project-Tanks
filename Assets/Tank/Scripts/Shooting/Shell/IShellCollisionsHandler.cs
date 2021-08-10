using System;
using UnityEngine;

namespace Tank.Scripts
{
	public interface IShellCollisionsHandler
	{
		event Action OnCollisionEnter;
		Vector3 GetHitPoint();
	}
}
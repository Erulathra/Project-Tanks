using System;
using System.Collections.Generic;
using UnityEngine;

namespace Tank.Scripts
{
	public interface IShellCollisionsHandler
	{
		event Action OnCollisionEnter;

		Vector3 GetHitPoint();
		void SetIgnoringGameObjects(List<GameObject> ignoringGameObjects);
	}
}
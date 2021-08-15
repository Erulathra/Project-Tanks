using System;
using UnityEngine;

namespace Tank.Scripts
{
	public class RaycastShellCollisionsHandler : MonoBehaviour, IShellCollisionsHandler
	{
		public event Action OnCollisionEnter;

		private Vector3 previousPosition;
		private Vector3 actualPosition;

		private RaycastHit hit;
		private Vector3 hitPoint;
		
		public Vector3 GetHitPoint()
		{
			return hitPoint;
		}

		private void OnEnable()
		{
			var position = transform.position;
			previousPosition = position;
			actualPosition = position;
			hitPoint = Vector3.zero;
		}

		private void Update()
		{
			UpdatePositions();
			if (CheckCollision())
			{
				hitPoint = hit.point;
				OnCollisionEnter.Invoke();
			}
		}

		private void UpdatePositions()
		{
			previousPosition = actualPosition;
			actualPosition = transform.position;
		}

		private bool CheckCollision()
		{
			return Physics.Linecast(previousPosition, actualPosition, out hit);
		}

		
	}
}
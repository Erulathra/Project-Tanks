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
		
		public Vector3 GetHitPoint()
		{
			return hit.point;
		}

		private void Start()
		{
			var position = transform.position;
			previousPosition = position;
			actualPosition = position;
		}

		private void Update()
		{
			UpdatePositions();
			if(CheckCollision()) OnCollisionEnter.Invoke();
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
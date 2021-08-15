using System;
using Pool;
using UnityEngine;

namespace Tank.Scripts
{
	public class RigidBodyShootingHandler : MonoBehaviour, IShootingHandler
	{
		[SerializeField] private Transform muzzle;
		[SerializeField] private Transform tower;

		[SerializeField] private ObjectPoolManager shellPool;

		[SerializeField] private float shellStartVelocity = 10f;
		[SerializeField] private float gunCounterForce = 50f;
		

		private new Rigidbody rigidbody;

		private void Awake()
		{
			rigidbody = GetComponent<Rigidbody>();
		}

		public void Shoot()
		{
			var shell = GetShell();
			PrepareShellToShot(shell);
			FireShell(shell);
			AddCounterForceToGun();
		}
		
		private GameObject GetShell()
		{
			var shell = shellPool.GetObject();
			return shell;
		}

		private void PrepareShellToShot(GameObject shell)
		{
			shell.transform.position = muzzle.position;
			shell.transform.rotation = tower.rotation;
			shell.SetActive(true);
		}

		private void FireShell(GameObject shell)
		{
			var shellRigidbody = shell.GetComponent<Rigidbody>();
			shellRigidbody.velocity = shell.transform.forward * shellStartVelocity + rigidbody.velocity;
			shellRigidbody.transform.rotation = Quaternion.LookRotation(shellRigidbody.velocity);
		}
		
		private void AddCounterForceToGun()
		{
			GetComponent<Rigidbody>().AddForceAtPosition(-gunCounterForce * muzzle.forward, muzzle.position);
		}
	}
}
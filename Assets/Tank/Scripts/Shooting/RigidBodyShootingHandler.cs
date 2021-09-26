using System;
using System.Collections.Generic;
using Entities_Scripts.ExplosionScripts;
using Pool;
using Tank.Scripts.Shooting;
using Tank.Scripts.Shooting.Shell;
using UnityEngine;

namespace Tank.Scripts
{
	public class RigidBodyShootingHandler : MonoBehaviour, IShootingHandler
	{
		[SerializeField] private Transform muzzle;
		[SerializeField] private Transform tower;

		private ObjectPoolManager shellPool;
		private ObjectPoolManager explosionPool;

		[SerializeField] private float shellStartVelocity = 10f;
		[SerializeField] private float gunCounterForce = 50f;
		
		private new Rigidbody rigidbody;

		private ExplosionData explosionData;

		public void ExplosionData(ExplosionData explosionData)
		{
			this.explosionData = explosionData;
		}

		private void Awake()
		{
			shellPool = GameObject.FindGameObjectWithTag("ShellPool").GetComponent<ObjectPoolManager>();
			explosionPool = GameObject.FindGameObjectWithTag("ExplosionPool").GetComponent<ObjectPoolManager>();

			rigidbody = GetComponent<Rigidbody>();
		}

		public void Shoot()
		{
			var shell = GetShell();
			PrepareShellToShot(shell);
			AddExplosionPoolReferenceToShell(shell);
			SetShellParameters(shell);
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
			var ignoringGameObjects = new List<GameObject> { gameObject };
			shell.GetComponent<RigidbodyShellScript>().SetIgnoringObjects(ignoringGameObjects);
			shell.SetActive(true);
		}

		private void AddExplosionPoolReferenceToShell(GameObject shell)
		{
			var rigidbodyShellScript = shell.GetComponent<RigidbodyShellScript>();
			rigidbodyShellScript.ExplosionPool = explosionPool;
		}
		
		private void SetShellParameters(GameObject shell)
		{
			var rigidbodyShellScript = shell.GetComponent<RigidbodyShellScript>();
			rigidbodyShellScript.ExplosionData = explosionData;
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
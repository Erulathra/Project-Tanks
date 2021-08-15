using System;
using Pool;
using UnityEngine;

namespace Tank.Scripts.Shooting.Shell
{
	public class PrepareShellHandler : MonoBehaviour
	{
		[SerializeField] private ObjectPoolManager explosionPool;
		private ObjectPoolManager shellPool;

		private void Start()
		{
			shellPool = GetComponent<ObjectPoolManager>();
			shellPool.OnCreateObject += PrepareShell;
		}

		private void PrepareShell(GameObject shell)
		{
			shell.GetComponent<RigidbodyShellScript>().ExplosionPool = explosionPool;
		}
	}
}
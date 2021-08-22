using System;
using UnityEngine;

namespace Tank.Scripts.Shooting.ExplosionScripts
{
	[System.Serializable] public struct ExplosionData
	{
		public float radius;
		public float force;
		public int damage;
		public float lifeTime;
	}
}
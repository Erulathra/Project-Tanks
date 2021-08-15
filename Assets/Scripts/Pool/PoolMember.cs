using UnityEngine;

namespace Pool
{
	public class PoolMember : MonoBehaviour
	{
		private ObjectPoolManager parentObjectPoolManager;

		public static PoolMember AddPollMemberComponent(GameObject newOwner, ObjectPoolManager parentObjectPoolManager)
		{
			var newPoolMember = newOwner.AddComponent<PoolMember>();
			newPoolMember.parentObjectPoolManager = parentObjectPoolManager;
			return newPoolMember;
		}

		public PoolMember(ObjectPoolManager parentObjectPoolManager)
		{
			this.parentObjectPoolManager = parentObjectPoolManager;
		}

		public void ReturnToPool()
		{
			parentObjectPoolManager.ReturnObject(this.gameObject);
		}
	}
}
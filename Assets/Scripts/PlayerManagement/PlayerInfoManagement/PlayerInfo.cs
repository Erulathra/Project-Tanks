using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace PlayerManagement.PlayerInfoManagement
{
	[Serializable]
	public class PlayerInfo
	{
		public string Name { get; private set; }
		public Color Color { get; private set; }
		
		public GameObject associatedGameObject;
		public int hearts;

		public PlayerInfo(string name, Color color)
		{
			this.Name = name;
			this.Color = color;
		}

		public PlayerInfo(PlayerInfo playerInfo)
		{
			Name = playerInfo.Name;
			Color = playerInfo.Color;
			associatedGameObject = playerInfo.associatedGameObject;
			hearts = playerInfo.hearts;
		}
	}
	
}
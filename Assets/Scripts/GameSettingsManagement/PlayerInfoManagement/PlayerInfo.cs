using System;
using UnityEngine;

namespace GameSettingsManagement.PlayerInfoManagement
{
	[Serializable]
	public class PlayerInfo
	{
		public string Name { get; private set; }
		public Color Color { get; private set; }

		public int score;

		public PlayerInfo(string name, Color color)
		{
			Name = name;
			Color = color;
		}

		public PlayerInfo(PlayerInfo playerInfo)
		{
			Name = playerInfo.Name;
			Color = playerInfo.Color;
		}
	}
	
}
using System;
using UnityEngine;

namespace GameSettingsManagement.PlayerInfoManagement
{
	public class ConstantPlayerInfoGetter : IPlayerInfoGetter
	{
		public PlayerInfo GetPlayerInfo(int playerIndex)
		{
			if (playerIndex == 0)
				return new PlayerInfo("Green", Color.green);
			if (playerIndex == 1)
				return new PlayerInfo("Red", Color.red);
			if (playerIndex == 2)
				return new PlayerInfo("Blue", Color.blue);
			if (playerIndex == 3)
				return new PlayerInfo("Yellow", Color.yellow);
			else
				throw new NotImplementedException();
		}
	}
}
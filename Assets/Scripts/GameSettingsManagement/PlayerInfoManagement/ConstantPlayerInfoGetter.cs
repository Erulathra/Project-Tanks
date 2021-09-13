using System;
using UnityEngine;

namespace GameSettingsManagement.PlayerInfoManagement
{
	public class ConstantPlayerInfoGetter : IPlayerInfoGetter
	{
		public PlayerInfo GetPlayerInfo(int playerIndex)
		{
			if (playerIndex == 0)
				return new PlayerInfo("Player 1", Color.green);
			if (playerIndex == 1)
				return new PlayerInfo("Player 2", Color.red);
			if (playerIndex == 2)
				return new PlayerInfo("Player 3", Color.blue);
			if (playerIndex == 3)
				return new PlayerInfo("Player 4", Color.yellow);
			else
				throw new NotImplementedException();
		}
	}
}
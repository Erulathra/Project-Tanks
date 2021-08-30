using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayerManagement
{
	[Serializable]
	public enum PlayerControllerType
	{
		None,
		MouseAndKeyboard,
		Gamepad
	}

	[Serializable]
	public struct Player
	{
		public PlayerControllerType playerControllerType;
		public InputDevice InputDevice;
	}

	public class PlayerListIsFullException : Exception
	{
		
	}

	public class PlayerInfo : MonoBehaviour
	{
		public Player[] Players { get; private set; }

		private void Start()
		{
			InitialiseGame();
		}

		private void Update()
		{
			SearchForNewPlayers();
		}

		private void InitialiseGame()
		{
			Players = new Player[4];
		}


		private void SearchForNewPlayers()
		{
			SearchForGamepads();
			SearchForKeyboards();
		}

		private void SearchForKeyboards()
		{
			var keyboard = Keyboard.current;
			if (keyboard.enterKey.wasReleasedThisFrame)
			{
				AddPlayerWhenItWasNotAdded(keyboard, PlayerControllerType.MouseAndKeyboard);
			}
		}

		private void SearchForGamepads()
		{
			var gamepad = Gamepad.current;
			if (gamepad.startButton.wasReleasedThisFrame)
			{
				AddPlayerWhenItWasNotAdded(gamepad, PlayerControllerType.Gamepad);
			}
		}

		private void AddPlayerWhenItWasNotAdded(InputDevice device, PlayerControllerType type)
		{
			if (WasDeviceAdded(device)) return;
			AddPlayer(device, type);
		}

		private void AddPlayer(InputDevice device, PlayerControllerType type)
		{
			try
			{
				var place = FindFreePlaceForPlayer();
				Players[place].InputDevice = device;
				Players[place].playerControllerType = type;
			}
			catch (PlayerListIsFullException)
			{
				return;
			}
		}

		private int FindFreePlaceForPlayer()
		{
			for (var i = 0; i < 4; i++)
			{
				if (Players[i].playerControllerType == PlayerControllerType.None)
				{
					return i;
				}
			}

			throw new PlayerListIsFullException();
		}

		private bool WasDeviceAdded(InputDevice device)
		{
			foreach (var player in Players)
				if (player.InputDevice == device)
					return true;

			return false;
		}
	}
}
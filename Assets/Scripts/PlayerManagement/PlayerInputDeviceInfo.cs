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
	public struct PlayerInput
	{
		public PlayerControllerType playerControllerType;
		public InputDevice InputDevice;
	}

	public class PlayerListIsFullException : Exception
	{
		
	}
	
	public class PlayerInputDeviceInfo : MonoBehaviour
	{
		public PlayerInput[] Players { get; private set; }

		private void Start()
		{
			DontDestroyOnLoad(gameObject);
			Players = new PlayerInput[4];
		}

		public void AddPlayerWhenItWasNotAdded(InputDevice device, PlayerControllerType type)
		{
			if (WasDeviceAdded(device)) return;
			AddPlayer(device, type);
		}

		private void AddPlayer(InputDevice device, PlayerControllerType type)
		{
			try
			{
				TryAddPlayer(device, type);
			}
			catch (PlayerListIsFullException)
			{
				Debug.Log("PlayerList is Full");
			}
		}

		private void TryAddPlayer(InputDevice device, PlayerControllerType type)
		{
			var place = FindFreePlaceForPlayer();
			Players[place].InputDevice = device;
			Players[place].playerControllerType = type;
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
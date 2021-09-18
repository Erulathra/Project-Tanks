using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

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
		[FormerlySerializedAs("playerIndex")] public int index;
		public PlayerControllerType playerControllerType;
		public InputDevice InputDevice;
	}

	public class PlayerListIsFullException : Exception
	{
		
	}
	
	public class PlayerInputDeviceInfo : MonoBehaviour
	{
		public PlayerInput[] PlayersInput { get; private set; }

		private void Start()
		{
			DontDestroyOnLoad(gameObject);
			PlayersInput = new PlayerInput[4];
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
			PlayersInput[place].InputDevice = device;
			PlayersInput[place].playerControllerType = type;
			PlayersInput[place].index = place;
		}

		private int FindFreePlaceForPlayer()
		{
			for (var i = 0; i < 4; i++)
			{
				if (PlayersInput[i].playerControllerType == PlayerControllerType.None)
				{
					return i;
				}
			}

			throw new PlayerListIsFullException();
		}

		private bool WasDeviceAdded(InputDevice device)
		{
			foreach (var player in PlayersInput)
				if (player.InputDevice == device)
					return true;

			return false;
		}
	}
}
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace PlayerManagement
{
	public class PlayerLobby : MonoBehaviour
	{
		[FormerlySerializedAs("playerInfo")] [SerializeField] private PlayerInputDeviceInfo playerInputDeviceInfo;
		
		private void Update()
		{
			SearchForNewPlayers();
		}
		
		private void SearchForNewPlayers()
		{
			SearchForGamepads();
			SearchForKeyboards();
		}

		private void SearchForKeyboards()
		{
			var keyboard = Keyboard.current;
			if (keyboard == null) return;

			if (keyboard.enterKey.wasReleasedThisFrame)
			{
				playerInputDeviceInfo.AddPlayerWhenItWasNotAdded(keyboard, PlayerControllerType.MouseAndKeyboard);
			}
		}

		private void SearchForGamepads()
		{
			var gamepad = Gamepad.current;
			if (gamepad == null) return;
			
			if (gamepad.startButton.wasReleasedThisFrame)
			{
				playerInputDeviceInfo.AddPlayerWhenItWasNotAdded(gamepad, PlayerControllerType.Gamepad);
			}
		}
	}
}
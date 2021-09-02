using UnityEngine;
using UnityEngine.InputSystem;

namespace PlayerManagement
{
	public class PlayerLobby : MonoBehaviour
	{
		[SerializeField] private PlayerInfo playerInfo;
		
		private void Start()
		{
		}

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
				playerInfo.AddPlayerWhenItWasNotAdded(keyboard, PlayerControllerType.MouseAndKeyboard);
			}
		}

		private void SearchForGamepads()
		{
			var gamepad = Gamepad.current;
			if (gamepad == null) return;
			
			if (gamepad.startButton.wasReleasedThisFrame)
			{
				playerInfo.AddPlayerWhenItWasNotAdded(gamepad, PlayerControllerType.Gamepad);
			}
		}
	}
}
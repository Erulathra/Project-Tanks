using Tank.Scripts;
using Tank.Scripts.Input;
using UnityEngine.InputSystem;
using PlayerInput = PlayerManagement.PlayerInput;

namespace GameSettingsManagement.PlayerGameObjectBuilder
{
	public class PlayerGameObjectBuilderWithKeyboard : global::GameSettingsManagement.PlayerGameObjectBuilder.PlayerGameObjectBuilder
	{
		public override void AddAimHandler()
		{
			Destroy(PlayerGameObject.GetComponent<GamepadAimHandler>());
			var mouseAimHandler = PlayerGameObject.AddComponent<MouseAimHandler>();
			var inputHandler = PlayerGameObject.GetComponent<InputHandler>();
			inputHandler.AimHandler = mouseAimHandler;
		}

		public override void AssingController()
		{
			var playerInput = PlayerGameObject.GetComponent<UnityEngine.InputSystem.PlayerInput>();
			var inputDevices = GetMouseAndKeyboard(PlayerInput);
			playerInput.SwitchCurrentControlScheme(inputDevices);
		}

		private static InputDevice[] GetMouseAndKeyboard(PlayerInput playerInput)
		{
			var inputDevices = new InputDevice[2];
			inputDevices[0] = playerInput.InputDevice;
			inputDevices[1] = Mouse.current;
			return inputDevices;
		}
	
	}
}
using PlayerManagement;
using Tank.Scripts;
using Tank.Scripts.Input;
using UnityEngine.InputSystem;

public class PlayerGameObjectBuilderWithKeyboard : PlayerGameObjectBuilder
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
		var playerInput = PlayerGameObject.GetComponent<PlayerInput>();
		var inputDevices = GetMouseAndKeyboard(Player);
		playerInput.SwitchCurrentControlScheme(inputDevices);
	}

	private static InputDevice[] GetMouseAndKeyboard(Player player)
	{
		var inputDevices = new InputDevice[2];
		inputDevices[0] = player.InputDevice;
		inputDevices[1] = Mouse.current;
		return inputDevices;
	}
	
}
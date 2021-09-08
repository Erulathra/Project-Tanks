using UnityEngine.InputSystem;

public class PlayerGameObjectBuilderWithGamepad : PlayerGameObjectBuilder
{
	public override void AddAimHandler()
	{ }
	
	public override void AssingController()
	{
		var playerInput = PlayerGameObject.GetComponent<PlayerInput>();
		playerInput.SwitchCurrentControlScheme(Player.InputDevice);
	}
}
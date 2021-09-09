using UnityEngine.InputSystem;

namespace PlayerManagement.PlayerGameObjectBuilder
{
	public class PlayerGameObjectBuilderWithGamepad : global::PlayerGameObjectBuilder
	{
		public override void AddAimHandler()
		{ }
	
		public override void AssingController()
		{
			var playerInput = PlayerGameObject.GetComponent<PlayerInput>();
			playerInput.SwitchCurrentControlScheme(Player.InputDevice);
		}
	}
}
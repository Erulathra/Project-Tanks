namespace GameSettingsManagement.PlayerGameObjectBuilder
{
	public class PlayerGameObjectBuilderWithGamepad : global::GameSettingsManagement.PlayerGameObjectBuilder.PlayerGameObjectBuilder
	{
		public override void AddAimHandler()
		{ }
	
		public override void AssingController()
		{
			var playerInput = PlayerGameObject.GetComponent<UnityEngine.InputSystem.PlayerInput>();
			playerInput.SwitchCurrentControlScheme(PlayerInput.InputDevice);
		}
	}
}
using System;
using UnityEngine.SceneManagement;

public static class SceneLoader
{
	[Serializable]
	public enum Scene
	{
		PlayerLobby,
		LoadingScene,
		DustOne,
		DustTwo,
	}

	private static Action _onLoaderCallbackAction;
	public static void LoadScene(Scene sceneEnum)
	{
		_onLoaderCallbackAction = () =>
		{
			SceneManager.LoadSceneAsync(sceneEnum.ToString());
		};
		
		SceneManager.LoadScene(Scene.LoadingScene.ToString());
	}

	public static void LoaderCallback()
	{
		if(_onLoaderCallbackAction == null) return;

		_onLoaderCallbackAction();
		_onLoaderCallbackAction = null;
	}
	
}

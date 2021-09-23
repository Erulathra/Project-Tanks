using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
		StageScene,
	}

	private class LoadingMonoBehaviour : MonoBehaviour
	{ }
	
	private static Action _onLoaderCallbackAction;
	private static LoadingMonoBehaviour loadingMonoBehaviour;

	public static void LoadMenu()
	{
		LoadScene(Scene.PlayerLobby);
	}
	
	public static void LoadScene(Scene sceneEnum)
	{
		_onLoaderCallbackAction = () =>
		{
			var loadingGameObject = new GameObject("Loading Game Object");
			loadingMonoBehaviour = loadingGameObject.AddComponent<LoadingMonoBehaviour>();
			loadingMonoBehaviour.StartCoroutine(LoadSceneAsync(sceneEnum));
		};
		
		SceneManager.LoadScene(Scene.LoadingScene.ToString());
	}

	private static IEnumerator LoadSceneAsync(Scene scene)
	{
		yield return null;
		var loadingAsyncOperation = SceneManager.LoadSceneAsync(scene.ToString());
		
		while(!loadingAsyncOperation.isDone)
			yield return null;
	}

	public static void LoaderCallback()
	{
		if(_onLoaderCallbackAction == null) return;

		_onLoaderCallbackAction();
		_onLoaderCallbackAction = null;
	}
	
}

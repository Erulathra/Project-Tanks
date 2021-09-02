using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
	[Serializable]
	public enum Scene
	{
		PlayerLobby,
		PrototypeMap,
	}

	public void LoadSceneFrom(Scene sceneEnum)
	{
		string sceneName = sceneEnum.ToString();
		SceneManager.LoadScene(sceneName);
	}
	
	public void LoadSceneFrom(string sceneName)
	{
		SceneManager.LoadScene(sceneName);
	}
	
	public void LoadSceneFrom(int sceneIndex)
	{
		SceneManager.LoadScene(sceneIndex);
	}
}

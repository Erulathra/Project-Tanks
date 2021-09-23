using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoaderMonoBehaviour : MonoBehaviour
{
	public void LoadMenu()
	{
		SceneLoader.LoadMenu(); 
	}

	public static void LoadScene(SceneLoader.Scene sceneEnum)
	{
		SceneLoader.LoadScene(sceneEnum);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempScript : MonoBehaviour
{
	public void LoadGame()
	{
		SceneLoader.TryLoadSceneWithTransition(SceneLoader.Scene.DustOne);
	}
}

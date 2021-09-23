using System;
using System.Collections;
using UnityEngine;

public interface ISceneTransition
{
	public Coroutine StartCoroutine(IEnumerator routine);
	public IEnumerator DimToTransparent();
	public IEnumerator DimToBlack(Action OnTransitionEndAction);
}
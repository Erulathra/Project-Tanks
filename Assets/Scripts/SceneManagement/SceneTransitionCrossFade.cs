using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class SceneTransitionCrossFade : MonoBehaviour, ISceneTransition
{
    [SerializeField] private CanvasGroup panel;
    [SerializeField] private float dimSpeed ;

    void Start()
    {
        StartCoroutine(DimToTransparent());
    }

    public IEnumerator DimToTransparent()
    {
        panel.gameObject.SetActive(true);
        panel.alpha = 1;
        
        while (true)
        {
            panel.alpha -= dimSpeed * Time.deltaTime;
            if (panel.alpha <= 0)
            {
                panel.alpha = 0;
                panel.gameObject.SetActive(false);
                yield break;
            }
            
            yield return null;
        }
    }
    
    public IEnumerator DimToBlack(Action OnTransitionEndAction)
    {
        panel.gameObject.SetActive(true);
        panel.alpha = 0;

        while (true)
        {
            panel.alpha += dimSpeed * Time.deltaTime;
            if (panel.alpha >= 1)
            {
                panel.alpha = 1;
                OnTransitionEndAction?.Invoke();
                yield break;
            }
            
            yield return null;
        }
    }
}

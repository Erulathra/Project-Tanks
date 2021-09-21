using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualMapManager : MonoBehaviour, IMapManager
{
    [SerializeField] private List<SceneLoader.Scene> maps;

    private int actualMap;
    void Start()
    {
        actualMap = 0;
    }

    public void LoadFirstMap()
    {
        actualMap = 0;
        SceneLoader.LoadScene(maps[actualMap]);
    }

    public void LoadNextMap()
    {
        var nextMapIndex = GetNextMapIndex();
        actualMap = nextMapIndex;
        SceneLoader.LoadScene(maps[nextMapIndex]);
    }

    private int GetNextMapIndex()
    {
        return (int)Mathf.Repeat(actualMap + 1, maps.Count);
    }
}

using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pool
{
    public class ObjectPoolManager : MonoBehaviour
    {
        [SerializeField] private int objectCount = 100;
        public int ObjectCount => this.objectCount;

        [SerializeField] private GameObject objectPrefab;
        
        private Stack<GameObject> availableObjects;

        private void Awake()
        {
            availableObjects = new Stack<GameObject>();
        }

        private void Start()
        {
            for (var i = 0; i < objectCount; i++)
            {
                var tempGameObject = Instantiate(objectPrefab, this.transform);
                    
                tempGameObject.SetActive(false);
                PoolMember.AddComponent(tempGameObject, this);
                availableObjects.Push(tempGameObject);
            }
        }

        public GameObject GetObject()
        {
            if (availableObjects.Count == 0) throw new ApplicationException("Pool \"" + this.gameObject.name + "\" is Empty");
            var tempGameObject = availableObjects.Pop();
            return tempGameObject;
        }

        public void ReturnObject(GameObject obj)
        {
            obj.SetActive(false);
            availableObjects.Push(obj);
        }
    }
}

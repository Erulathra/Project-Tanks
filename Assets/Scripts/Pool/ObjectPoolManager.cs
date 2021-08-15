using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pool
{
    public class ObjectPoolManager : MonoBehaviour
    {
        [SerializeField] private int objectCount = 100;
        [SerializeField] private GameObject objectPrefab;
        
        private Stack<GameObject> availableObjects;

        public delegate void OnCreateObjectEventDelegate(GameObject gameObject);
        public event OnCreateObjectEventDelegate OnCreateObject;

        private void Awake()
        {
            availableObjects = new Stack<GameObject>();
        }

        private void Start()
        {
            FillAvailableObjectsWithGameObjects();
        }

        private void FillAvailableObjectsWithGameObjects()
        {
            for (var i = 0; i < objectCount; i++)
            {
                var tempGameObject = CreateObject();
                PrepareObject(tempGameObject);
                availableObjects.Push(tempGameObject);
            }
        }

        private GameObject CreateObject()
        {
            return Instantiate(objectPrefab, transform);
        }

        private void PrepareObject(GameObject createdGameObject)
        {
            createdGameObject.SetActive(false);
            PoolMember.AddPollMemberComponent(createdGameObject, this);
            OnCreateObject?.Invoke(createdGameObject);
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

using System;
using System.Collections.Generic;
using Tank.Scripts.Shooting.Shell;
using UnityEngine;

namespace Tank.Scripts
{
    public class ShellContainer : MonoBehaviour
    {
        [SerializeField] private int shellCount = 100;
        public int ShellCount => this.shellCount;

        [SerializeField] private GameObject shellPrefab;
    
        public static ShellContainer Instance { get; private set; }
        
        private Stack<GameObject> availableShells;

        private void Awake()
        {
            Instance = this;
            availableShells = new Stack<GameObject>();
        }

        private void Start()
        {
            for (var i = 0; i < shellCount; i++)
            {
                var tempGameObject = Instantiate(shellPrefab, this.transform);
                    
                tempGameObject.SetActive(false);
                availableShells.Push(tempGameObject);
            }
        }

        public GameObject GetShell()
        {
            var tempGameObject = availableShells.Pop();
            return tempGameObject;
        }

        public void ReturnShell(GameObject shell)
        {
            if (shell.GetComponent<ShellScript>() == null) throw new ArgumentException("This Game Object doesn't contain ShellScript");
            shell.GetComponent<Rigidbody>().velocity = Vector3.zero;
            shell.SetActive(false);
            availableShells.Push(shell);
        }
    }
}

using UnityEngine;

namespace SceneManagement
{
    public class LoaderCallback : MonoBehaviour
    {
        private bool isFistUpdate = true;

        private void Update()
        {
            if (!isFistUpdate) return;
            isFistUpdate = false;
        
            SceneLoader.LoaderCallback();
        }
    }
}

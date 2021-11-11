using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class ButtonEvent : MonoBehaviour
    {
        public void SceneLoader(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
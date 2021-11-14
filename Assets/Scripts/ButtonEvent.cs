using System;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class ButtonEvent : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private SceneType sceneType;

        private void Start()
        {
            button.onClick
                .AsObservable()
                .Subscribe(_ =>
                    {
                        SceneManager.LoadScene(sceneType.ToString());
                    }
                );
        }
    }
}
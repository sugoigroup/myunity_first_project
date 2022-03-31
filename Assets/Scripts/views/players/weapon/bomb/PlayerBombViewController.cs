using System;
using UnityEngine;
using UnityEngine;
using System.Collections;
using DefaultNamespace.domain.valueobject;
using UniRx;

namespace DefaultNamespace
{
    public class PlayerBombViewController : MonoBehaviour
    {
        
        
        [SerializeField] private PlayerBombView _playerBombView;
        [SerializeField] private int damage = 100;
        [SerializeField] private float bombDelay = 0.5f;

        private int _owenerGameObjectId;

        private void Awake()
        {
            _playerBombView.setDamage(damage);
            _playerBombView.setBombDelay(bombDelay);
        }
        private void Start()
        {
            
            StartCoroutine("MoveToCenter");
        }
        
        private IEnumerator MoveToCenter()
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = Vector3.zero;
            float current = 0;
            float percent = 0;

            while (percent < 1)
            {
                current += Time.deltaTime;
                percent = current / bombDelay;
            
                transform.position = Vector3.Lerp(startPosition, endPosition, _playerBombView.getCurveEvaluate(percent));
                yield return null;
            }

            _playerBombView.setTrigger();
            _playerBombView.playBombAudio();

        }
        
        public void onBomb()
        {
            // Enemy, Meteriote는 죽음, 보스는 타격
            MessageBroker.Default.Publish(new BombExplodeByOutside(_owenerGameObjectId, damage));
            Destroy(gameObject);
        }
        

        public void SetOwenerGameObjectId(int getInstanceID)
        {
            _owenerGameObjectId = getInstanceID;
        }
    }
}
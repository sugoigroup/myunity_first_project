using System;
using UniRx;
using UnityEngine;

namespace DefaultNamespace.views.players.weapon.missile
{
    public class ProjectileView : MonoBehaviour
    {
        
        public IReadOnlyReactiveProperty<int> IsHitEnemy => _isHitEnemy ;
        private IntReactiveProperty _isHitEnemy = new IntReactiveProperty();
        
        

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.CompareTag("Enemy") || collision.CompareTag("Boss"))
            {
                _isHitEnemy.Value = collision.gameObject.GetInstanceID();
                Destroy(gameObject);
            }
        }
    }
}
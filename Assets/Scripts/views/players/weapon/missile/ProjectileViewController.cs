using System;
using UnityEngine;
using System.Collections;
using DefaultNamespace;
using DefaultNamespace.domain.valueobject;
using DefaultNamespace.views.players.weapon.missile;
using UniRx;
using UniRx.Triggers;
using UnityEngine.Serialization;

public class ProjectileViewController : MonoBehaviour
{
    [SerializeField] private ProjectileView _projectileView;
    [SerializeField] private int damage = -1;
    
    private int _owenerGameObjectId;
    public void SetOwenerGameObjectId(int getInstanceID)
    {
        _owenerGameObjectId = getInstanceID;
    }
    private void Start()
    {
        _projectileView.IsHitEnemy
            .DistinctUntilChanged()
            .Skip(1).Subscribe(hitGameObjectId =>
        {
            MessageBroker.Default.Publish(new HpPlusByOutside(hitGameObjectId, _owenerGameObjectId, damage));

        }).AddTo(this);
    }

    

    private void Awake()
    {

    }

}
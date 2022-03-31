using System;
using System.Collections;
using DefaultNamespace.domain.domainobject;
using DefaultNamespace.domain.valueobject;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class PlayerBombCountViewController : MonoBehaviour
    {
        [SerializeField] private PlayerBombCountView playerBombCountView;
        [SerializeField] private int debugMaxBombCount = 10;
        [SerializeField] private int debugMinBombCount = 0;

        private int MaxBombCount => debugMaxBombCount;
        private int MinBombCount => debugMinBombCount;


        private PlayerBombCountViewModel _playerBombCountViewModel;
        private int _owenerGameObjectId;

        private void Awake()
        {
            _playerBombCountViewModel = new PlayerBombCountViewModel();
        }

        private void Start()
        {
            _playerBombCountViewModel.initBombCount(_owenerGameObjectId, min: MinBombCount, MaxBombCount);
            _playerBombCountViewModel.CurrentChanged.Subscribe(value => { playerBombCountView.SetBombCount(value); })
                .AddTo(this);

            MessageBroker.Default.Receive<BombPlusByOutside>().Subscribe(newBomb =>
            {
                if (newBomb.owenerGameObjectId == _owenerGameObjectId &&
                    (_playerBombCountViewModel.CurrentBombCount + newBomb.plusMinusCount) > 0
                )
                {
                    PlusBomb(newBomb.plusMinusCount);
                    MessageBroker.Default.Publish(new BombGetCountReturnByOutside(_owenerGameObjectId,
                        _playerBombCountViewModel.CurrentBombCount));
                }
            }).AddTo(this);

            AsyncMessageBroker.Default.Subscribe<BombUseByOutside>(newBomb =>
            {
                if (newBomb.owenerGameObjectId == _owenerGameObjectId)
                {
                    var currentBombCount = _playerBombCountViewModel.CurrentBombCount - 1;
                    if (currentBombCount >= 0)
                    {
                        PlusBomb(-1);
                    }

                    MessageBroker.Default.Publish(new BombGetCountReturnByOutside(_owenerGameObjectId,
                        currentBombCount));
                }

                return Observable.ReturnUnit();
            }).AddTo(this);
        }

        public void PlusBomb(int plusMinusCount)
        {
            _playerBombCountViewModel.SaveWeaponCount(_owenerGameObjectId, plusMinusCount);
        }


        public void SetOwenerGameObjectId(int getInstanceID)
        {
            _owenerGameObjectId = getInstanceID;
        }
    }
}
using System;
using System.Collections.Generic;
using DefaultNamespace.domain.domainobject;
using DefaultNamespace.domain.valueobject;
using UnityEngine;
using UniRx;

namespace DefaultNamespace
{
    public class PlayerScoreViewController : MonoBehaviour
    {
        [SerializeField] private PlayerScoreView _playerScoreView;
        
        private PlayerScoreViewModel _playerScoreViewModel;
        private int _owenerGameObjectId;

        private void Awake()
        {
            _playerScoreViewModel = new PlayerScoreViewModel();
        }

        private void Start()
        {
            _playerScoreViewModel.CurrentChanged.Subscribe(value =>
            {
                _playerScoreView.ScoreSet(value);
            }).AddTo(this);
            
            MessageBroker.Default.Receive<ScorePlusByOutside>().Subscribe(newScore =>
            {
                if (newScore.owenerGameObjectId == _owenerGameObjectId)
                {
                    PlusScore(1, newScore.score);
                }
            }).AddTo(this);
        }

        public void PlusScore(int stageNum, int newValue)
        {
            _playerScoreViewModel.SaveScore(new Score(_owenerGameObjectId,stageNum, newValue));
        }

        public void SetOwenerGameObjectId(int getInstanceID)
        {
            _owenerGameObjectId = getInstanceID;
        }

        public int GetOwenerGameObjectId()
        {
            return _owenerGameObjectId;
        }

    }
}

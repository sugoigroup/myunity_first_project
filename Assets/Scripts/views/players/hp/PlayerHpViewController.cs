using System;
using System.Collections;
using DefaultNamespace.domain.valueobject;
using UnityEngine;
using UniRx;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public sealed class PlayerHpViewController : MonoBehaviour
    {
       /*
        //private 생성자 
        private PlayerHp() { }
        //private static 인스턴스 객체
        private static readonly Lazy<PlayerHp> _instance = new Lazy<PlayerHp> (() => new PlayerHp());
        //public static 의 객체반환 함수
        public static PlayerHp Instance { get { return _instance.Value; } }
        */
       
        [SerializeField] private PlayerHpView playerHpView;
        [SerializeField] private int debugMaxHp = 10;
        [SerializeField] private int debugMinHp = 0;
        
        private PlayerHpViewModel _playerHpViewModel;
        
        private int MaxHp => debugMaxHp;
        private int MinHp => debugMinHp;
        public IReadOnlyReactiveProperty<bool> IsDie { get; private set; }
        
        public IReadOnlyReactiveProperty<bool> IsDamaged => _isDamaged;
        private BoolReactiveProperty _isDamaged = new BoolReactiveProperty();

        private int _owenerGameObjectId;


        private void Awake()
        {
            _playerHpViewModel = new PlayerHpViewModel();
    
        }

        private void Start()
        {
            _playerHpViewModel.initEnergy(_owenerGameObjectId,min:MinHp, MaxHp);
            IsDie = _playerHpViewModel.CurrentChanged.Select(x => x <= MinHp).ToReadOnlyReactiveProperty();

            _playerHpViewModel.CurrentChanged.Subscribe(value =>
            {
                _isDamaged.Value = true;
                _isDamaged.Value = false;
                playerHpView.HpPercentageSet(_playerHpViewModel.HpPercentage());
            }).AddTo(this);;

            _playerHpViewModel.MaxChanged.Subscribe(value =>
            {
                playerHpView.HpPercentageSet(_playerHpViewModel.HpPercentage());
                
            }).AddTo(this);

            MessageBroker.Default.Receive<HpPlusByOutside>().Where(x => x.owenerGameObjectId == _owenerGameObjectId).Subscribe(newHp =>
            {
                TakeDamage(newHp.plusMinusCount);
            }).AddTo(this);
        }

        public void TakeDamage(int damage)
        {
            _playerHpViewModel.TakeDamage(_owenerGameObjectId, damage);
        }

        public void PlusHealth(int health)
        {
            _playerHpViewModel.PlusHealth(health);
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
using DefaultNamespace.domain.valueobject;
using UniRx;
using UnityEngine;

namespace DefaultNamespace
{
    public class BossHpViewController : MonoBehaviour
    {
        [SerializeField] private int debugMaxHp = 10;
        [SerializeField] private int debugMinHp = 0;

        [SerializeField] private BossHpView _bossHpView;
        
        private PlayerHpViewModel _enemyHpViewModel;     
        
        private int MaxHp => debugMaxHp;
        private int MinHp => debugMinHp;
        
        public IReadOnlyReactiveProperty<bool> IsDie { get; private set; }
        
        public IReadOnlyReactiveProperty<bool> IsDamaged => _isDamaged;
        private BoolReactiveProperty _isDamaged = new BoolReactiveProperty();

        private int _owenerGameObjectId;
        private int _lastFromGameObjectId;
        
        private void Awake()
        {
            _enemyHpViewModel = new PlayerHpViewModel();
            _enemyHpViewModel.initEnergy(_owenerGameObjectId,min:MinHp, MaxHp);

            IsDie = _enemyHpViewModel.CurrentChanged.Select(x => x <= MinHp).ToReadOnlyReactiveProperty();

        }
        
        private void Start()
        {
          
            
            _enemyHpViewModel.CurrentChanged.Subscribe(value =>
            {
                _isDamaged.Value = true;
                _isDamaged.Value = false;
                _bossHpView.HpPercentageSet(_enemyHpViewModel.HpPercentage());
            }).AddTo(this);;

            _enemyHpViewModel.MaxChanged.Subscribe(value =>
            {
                _bossHpView.HpPercentageSet(_enemyHpViewModel.HpPercentage());
                
            }).AddTo(this);
   

            MessageBroker.Default.Receive<HpPlusByOutside>().Where(x => x.owenerGameObjectId == _owenerGameObjectId).Subscribe(async newHp =>
            {
                //  print("18" + newHp.owenerGameObjectId + ":"+_owenerGameObjectId);
                // if (newHp.owenerGameObjectId == _owenerGameObjectId)
                // {
                this._lastFromGameObjectId = newHp.fromGameObjectId;
                TakeDamage(newHp.plusMinusCount);
                // }
            }).AddTo(gameObject);
        }
        

        public void TakeDamage(int damage)
        {
            _enemyHpViewModel.TakeDamage(_owenerGameObjectId, damage);
        }

        public int LastFromGameObjectId()
        {
            return _lastFromGameObjectId;
        }
        public void setOwenerGameObjectId(int owenerGameObjectId)
        { 
            _owenerGameObjectId = owenerGameObjectId;
        }

        public float HpPercentage()
        {
            return _enemyHpViewModel.HpPercentage();
        }
    }
}
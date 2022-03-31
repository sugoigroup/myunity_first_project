using DefaultNamespace.domain.domainobject;
using DefaultNamespace.Domain.UseCase;
using DefaultNamespace.domain.valueobject;
using UniRx;

namespace DefaultNamespace
{
    public class PlayerBombCountViewModel
    {
        private WeaponSaveUseCase _weaponSaveUseCase = new WeaponSaveUseCase();
        private WeaponGetUseCase _weaponGetUseCase = new WeaponGetUseCase();

        public int MaxHp
        {
            get => _maxHp.Value;
            set => _maxHp.Value = value;
        }

        public IReadOnlyReactiveProperty<int> MaxChanged => _maxHp;
        private IntReactiveProperty _maxHp = new IntReactiveProperty();


        public int CurrentBombCount
        {
            get => _currentBombCount.Value;
            set => _currentBombCount.Value = value;
        }

        public IReadOnlyReactiveProperty<int> CurrentChanged => _currentBombCount;
        private IntReactiveProperty _currentBombCount = new IntReactiveProperty();

        public MinMaxCurrent GetWeaponCount(int gameObjectId)
        {
            return _weaponGetUseCase.fetchWeaponCount(
                new WeaponGetUseCaseIO.Input(
                    gameObjectId,
                    WeaponType.BOMB)
            ).results;
        }

        public void SaveWeaponCount(int gameObjectId, int plusMinusCount)
        {
            Weapon weapon = _weaponGetUseCase.execute(
                new WeaponGetUseCaseIO.Input(
                    gameObjectId,
                    WeaponType.BOMB)
            ).results.returnData();

            CurrentBombCount = weapon.currentValue += plusMinusCount;


            _weaponSaveUseCase.execute(
                new WeaponSaveUseCaseIO.Input(weapon)
            );
        }


        public void initBombCount(int gameObjectId, int min, int max)
        {
            _weaponSaveUseCase.execute(
                new WeaponSaveUseCaseIO.Input(
                    new Weapon(
                        gameObjectId,
                        WeaponType.BOMB,
                        min,
                        max,
                        max,
                        new Energy(gameObjectId, EnergyType.WEAPON, 0, 0, 0)
                    )
                )
            );

            MaxHp = max;
            CurrentBombCount = max;
        }
    }
}
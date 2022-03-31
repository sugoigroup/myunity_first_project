using System;
using System.Collections;
using DefaultNamespace.domain.domainobject;
using DefaultNamespace.Domain.UseCase;
using DefaultNamespace.domain.valueobject;
using UnityEngine;
using UniRx;

namespace DefaultNamespace
{
    public class PlayerHpViewModel
    {
        private EnergySaveUseCase _energySaveUseCase = new EnergySaveUseCase();
        private EnergyGetUseCase _energyGetUseCase = new EnergyGetUseCase();


        public int MaxHp
        {
            get => _maxHp.Value;
            set => _maxHp.Value = value;
        }

        public IReadOnlyReactiveProperty<int> MaxChanged => _maxHp;
        private IntReactiveProperty _maxHp = new IntReactiveProperty();

        public int CurrentHp
        {
            get => _currentHp.Value;
            set => _currentHp.Value = value;
        }

        public IReadOnlyReactiveProperty<int> CurrentChanged => _currentHp;
        private IntReactiveProperty _currentHp = new IntReactiveProperty();


        public void TakeDamage(int gameObjectId, int damage)
        {
            Energy energy = (_energyGetUseCase.execute(
                new EnergyGetUseCaseIO.Input(
                    gameObjectId: gameObjectId,
                    energyType: EnergyType.HP
                )
            )).results.returnData();

            CurrentHp = energy.currentValue += damage;

            _energySaveUseCase.execute(
                new EnergySaveUseCaseIO.Input(energy)
            );
        }

        public void initEnergy(int gameObjectId, int min, int max)
        {
            _energySaveUseCase.execute(
                new EnergySaveUseCaseIO.Input(
                    new Energy(
                        gameObjectId: gameObjectId,
                        energyType: EnergyType.HP,
                        minValue: min,
                        currentValue: max,
                        maxValue: max
                    )
                )
            );

            MaxHp = max;
            CurrentHp = max;
        }

        public float HpPercentage()
        {
            return (float)CurrentHp / (float)MaxHp;
        }

        public void PlusHealth(int health)
        {
            CurrentHp += health;
        }
    }
}
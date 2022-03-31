using System;
using DefaultNamespace.data;
using DefaultNamespace.domain.repository;
using DefaultNamespace.domain.valueobject;

namespace DefaultNamespace.Domain.UseCase
{
    public class EnergyRemoveUseCase : IEnergyRemoveUseCase
    {
        private EnergyRepository _energyRepository = new EnergyRepositoryImpl();
        private RemoveEnergyUseCaseIO.Converter _converter = new RemoveEnergyUseCaseIO.Converter();

        public void execute(RemoveEnergyUseCaseIO.Input input)
        {
            _energyRepository.removeEnergy(
                _converter.toRepositoryInput(
                    input: input
                )
            );
        }
    }
}
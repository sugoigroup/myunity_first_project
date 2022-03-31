using DefaultNamespace.data;
using DefaultNamespace.domain.domainobject;
using DefaultNamespace.domain.repository;

namespace DefaultNamespace.Domain.UseCase
{
    public class EnergySaveUseCase : IEnergySaveUseCase
    {
        private EnergyRepository _energyRepository = new EnergyRepositoryImpl();

        public void execute(EnergySaveUseCaseIO.Input input)
        {
            _energyRepository.saveEnergy(
                new EnergyRepositoryIO.SaveEnergy.Input(
                    input.energy
                )
            );
        }
    }
}
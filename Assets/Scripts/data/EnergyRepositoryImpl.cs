using DefaultNamespace.data.local.staticlao;
using DefaultNamespace.domain;
using DefaultNamespace.domain.domainobject;
using DefaultNamespace.domain.repository;

namespace DefaultNamespace.data
{
    public class EnergyRepositoryImpl : EnergyRepository
    {
        private EnergyStaticLao _energyStaticLao;

        public EnergyRepositoryIO.FetchEnergy.Output fetchEnergy(EnergyRepositoryIO.FetchEnergy.Input input)
        {
            _energyStaticLao = new EnergyStaticLao(input.gameObjectId, input.energyType);
            Energy energy = _energyStaticLao.fetchOrNull();

            if (energy == null)
            {
                return new EnergyRepositoryIO.FetchEnergy.Output(
                    new Failure<Energy, EnergyRepositoryIO.FetchEnergy.Output.Error>(
                        EnergyRepositoryIO.FetchEnergy.Output.Error.OTHER
                    )
                );
            }
            else
            {
                return new EnergyRepositoryIO.FetchEnergy.Output(
                    new Success<Energy, EnergyRepositoryIO.FetchEnergy.Output.Error>(
                        energy
                    )
                );
            }
        }

        public void removeEnergy(EnergyRepositoryIO.RemoveEnergy.Input input)
        {
            _energyStaticLao = new EnergyStaticLao(input.gameObjectId, input.energyType);
            _energyStaticLao.remove();
        }

        public void saveEnergy(EnergyRepositoryIO.SaveEnergy.Input input)
        {
            _energyStaticLao = new EnergyStaticLao(input.energy.gameObjectId, input.energy.energyType);
            _energyStaticLao.save(input.energy);
        }
    }
}
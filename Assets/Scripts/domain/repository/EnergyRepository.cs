using DefaultNamespace.domain.domainobject;

namespace DefaultNamespace.domain.repository
{
    public interface EnergyRepository
    {
        public EnergyRepositoryIO.FetchEnergy.Output fetchEnergy(EnergyRepositoryIO.FetchEnergy.Input input);
        public void removeEnergy(EnergyRepositoryIO.RemoveEnergy.Input input);
        public void saveEnergy(EnergyRepositoryIO.SaveEnergy.Input input);
    }
}
using DefaultNamespace.Domain.UseCase;

namespace DefaultNamespace.Domain.UseCase
{
    public interface IEnergyGetUseCase
    {
        public EnergyGetUseCaseIO.Output execute(EnergyGetUseCaseIO.Input input);
    }
}
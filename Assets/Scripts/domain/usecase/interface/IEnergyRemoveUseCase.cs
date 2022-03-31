using DefaultNamespace.Domain.UseCase;

namespace DefaultNamespace.Domain.UseCase
{
    public interface IEnergyRemoveUseCase
    {
        public void execute(RemoveEnergyUseCaseIO.Input input);
    }
}
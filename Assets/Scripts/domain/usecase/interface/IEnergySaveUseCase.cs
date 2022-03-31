using DefaultNamespace.domain.domainobject;

namespace DefaultNamespace.Domain.UseCase
{
    public interface IEnergySaveUseCase
    {
        public void execute(EnergySaveUseCaseIO.Input input);
    }
}
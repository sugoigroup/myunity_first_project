using DefaultNamespace.domain.domainobject;

namespace DefaultNamespace.Domain.UseCase
{
    public interface IScoreSaveUseCase
    {
        public void execute(ScoreSaveUseCaseIO.Input input);
    }
}
using DefaultNamespace.Domain.UseCase;

namespace DefaultNamespace.Domain.UseCase
{
    public interface IScoreGetUseCase
    {
        public ScoreGetUseCaseIO.Output execute(ScoreGetUseCaseIO.Input input);
    }
}
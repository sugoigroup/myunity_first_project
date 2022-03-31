using DefaultNamespace.data;
using DefaultNamespace.domain.domainobject;
using DefaultNamespace.domain.repository;

namespace DefaultNamespace.Domain.UseCase
{
    public class ScoreSaveUseCase : IScoreSaveUseCase
    {
        private ScoreRepository _scoreRepository = new ScoreRepositoryImpl();

        public void execute(ScoreSaveUseCaseIO.Input input)
        {
            _scoreRepository.saveScore(
                new ScoreRepositoryIO.SaveScore.Input(
                    input.score
                )
            );
        }
    }
}
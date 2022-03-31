using DefaultNamespace.data;
using DefaultNamespace.domain.repository;

namespace DefaultNamespace.Domain.UseCase
{
    public class ScoreGetUseCase : IScoreGetUseCase
    {
        private ScoreRepository _scoreRepository = new ScoreRepositoryImpl();
        private ScoreGetUseCaseIO.Converter _converter = new ScoreGetUseCaseIO.Converter();

        public ScoreGetUseCaseIO.Output execute(ScoreGetUseCaseIO.Input input)
        {
            return new ScoreGetUseCaseIO.Output(
                results: _converter.toDomainOutput(
                    _scoreRepository.fetchScore(
                        _converter.toRepositoryInput(input)
                    )
                )
            );
        }
    }
}
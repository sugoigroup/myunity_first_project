using DefaultNamespace.data.local.staticlao;
using DefaultNamespace.domain;
using DefaultNamespace.domain.domainobject;
using DefaultNamespace.domain.repository;

namespace DefaultNamespace.data
{
    public class ScoreRepositoryImpl : ScoreRepository
    {
        private ScoreStaticLao _scoreStaticLao;

        public ScoreRepositoryIO.FetchScore.Output fetchScore(ScoreRepositoryIO.FetchScore.Input input)
        {
            _scoreStaticLao = new ScoreStaticLao(input.gameObjectId, input.stageNum);
            Score score = _scoreStaticLao.fetchOrNull();

            if (score == null)
            {
                return new ScoreRepositoryIO.FetchScore.Output(
                    new Failure<Score, ScoreRepositoryIO.FetchScore.Output.Error>(
                        ScoreRepositoryIO.FetchScore.Output.Error.OTHER
                    )
                );
            }
            else
            {
                return new ScoreRepositoryIO.FetchScore.Output(
                    new Success<Score, ScoreRepositoryIO.FetchScore.Output.Error>(
                        score
                    )
                );
            }
        }

        public void saveScore(ScoreRepositoryIO.SaveScore.Input input)
        {
            _scoreStaticLao = new ScoreStaticLao(input.score.gameObjectId, input.score.stageNum);
            _scoreStaticLao.save(input.score);
        }
    }
}
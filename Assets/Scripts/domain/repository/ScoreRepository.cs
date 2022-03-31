using DefaultNamespace.domain.domainobject;

namespace DefaultNamespace.domain.repository
{
    public interface ScoreRepository
    {
        public ScoreRepositoryIO.FetchScore.Output fetchScore(ScoreRepositoryIO.FetchScore.Input input);
        public void saveScore(ScoreRepositoryIO.SaveScore.Input input);
    }
}
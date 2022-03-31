using DefaultNamespace.domain.domainobject;
using DefaultNamespace.Domain.UseCase;
using DefaultNamespace.domain.valueobject;
using UniRx;

namespace DefaultNamespace
{
    public class PlayerScoreViewModel
    {
        private ScoreSaveUseCase _scoreSaveUseCase = new ScoreSaveUseCase();
        private ScoreGetUseCase _scoreGetUseCase = new ScoreGetUseCase();
        

        public int CurrentScore
        {
            get => _currentScore.Value;
            set => _currentScore.Value = value;
        }

        public IReadOnlyReactiveProperty<int> CurrentChanged => _currentScore;
        private IntReactiveProperty _currentScore = new IntReactiveProperty();

        public int GetScore(int gameObjectId, int stageNum)
        {
            var result = _scoreGetUseCase.execute(
                new ScoreGetUseCaseIO.Input(
                    gameObjectId,
                    stageNum)
            ).results;

            if (result.returnData() != null)
            {
                return result.returnData().currentValue;
            }
            
            return 0;
        }

        public void SaveScore(Score newScore)
        {
            newScore.currentValue = CurrentScore += newScore.currentValue;
            
            _scoreSaveUseCase.execute(
                new ScoreSaveUseCaseIO.Input(newScore)
            );
        }
        
    }
}
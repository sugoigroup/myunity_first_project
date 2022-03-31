using DefaultNamespace.domain;
using DefaultNamespace.domain.domainobject;
using DefaultNamespace.domain.repository;

namespace DefaultNamespace.Domain.UseCase
{
    public class ScoreGetUseCaseIO
    {
        
        public struct Input
        {
            // 게임오브젝트고유번호
            public int gameObjectId;
            // 스테이지번호
            public int stageNum;

            public Input(int gameObjectId,int stageNum)
            {
                this.gameObjectId = gameObjectId;
                this.stageNum = stageNum;
            }
        }

        public class Output
        {
            public Output(IResults<Score, Error> results)
            {
                this.results = results;
            }

            public IResults<Score, Error> results;
            public enum Error
            {
                ERROR
            }
        }

        public  class Converter
        {
            public ScoreRepositoryIO.FetchScore.Input toRepositoryInput(
                ScoreGetUseCaseIO.Input input
            )
            {
                return new ScoreRepositoryIO.FetchScore.Input(
                    input.gameObjectId,
                    input.stageNum
                );
            }

            public IResults<Score, Output.Error> toDomainOutput(ScoreRepositoryIO.FetchScore.Output output)
            {
                // Success
                // Effective C# Item3 is, as 활용하자 
                if (output.results is Success<Score, ScoreRepositoryIO.FetchScore.Output.Error>)
                {
                    return new Success<Score, Output.Error>(output.results.returnData());
                }
                
                // Error
                var errorCode = Output.Error.ERROR;
                if (output.results.errorCode() == ScoreRepositoryIO.FetchScore.Output.Error.OTHER)
                {
                    errorCode = Output.Error.ERROR;
                }
                return new Failure<Score, Output.Error>(errorCode);
               
            }
        }
    }
}
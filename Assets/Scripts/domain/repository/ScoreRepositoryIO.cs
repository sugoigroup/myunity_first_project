using DefaultNamespace.domain.domainobject;
using DefaultNamespace.domain.valueobject;

namespace DefaultNamespace.domain.repository
{
    public class ScoreRepositoryIO
    {
        public class SaveScore
        {
            public struct Input
            {
                // 에너지타입
                public Score score;

                public Input(Score score)
                {
                    this.score = score;
                }
            }

        }

        public class FetchScore
        {
            public struct Input
            {
                // 게임오브젝트고유번호
                public int gameObjectId;
                // 스테이지번호
                public int stageNum;

                public Input(int gameObjectId, int stageNum)
                {
                    this.gameObjectId = gameObjectId;
                    this.stageNum = stageNum;
                }
            }
            
            public struct Output
            {

                public Output(IResults<Score, Error> results)
                {
                    this.results = results;
                }
                
                // 게임오브젝트고유번호
                public IResults<Score, Error> results;


                public enum Error
                {
                    API,
                    OTHER
                }
            }
        }
    }
}
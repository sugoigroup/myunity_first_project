
using DefaultNamespace.domain.domainobject;

namespace DefaultNamespace.Domain.UseCase
{
    public class ScoreSaveUseCaseIO
    {
        public struct Input
        {
            // 에너지
            public Score score;

            public Input(Score score)
            {
                this.score = score;
            }
        }
        
        public struct Output{}
    }
}
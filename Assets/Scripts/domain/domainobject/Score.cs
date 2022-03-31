using DefaultNamespace.domain.valueobject;

namespace DefaultNamespace.domain.domainobject
{
    public class Score
    {
        // 게임오브젝트고유번호
        public int gameObjectId;
        // 에너지타입
        public int stageNum;
        // 현재값
        public int currentValue;

        public Score(int gameObjectId, int stageNum, int currentValue)
        {
            this.gameObjectId = gameObjectId;
            this.stageNum = stageNum;
            this.currentValue = currentValue;
        }
    }
}
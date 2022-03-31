using DefaultNamespace.domain.valueobject;

namespace DefaultNamespace.domain.domainobject
{
    public class Energy
    {
        // 게임오브젝트고유번호
        public int gameObjectId;
        // 에너지타입
        public EnergyType energyType;
        // 최소값
        public int minValue;
        // 현재값
        public int currentValue;
        // 최대값
        public int maxValue;

        public Energy(int gameObjectId, EnergyType energyType, int minValue, int currentValue, int maxValue)
        {
            this.gameObjectId = gameObjectId;
            this.energyType = energyType;
            this.minValue = minValue;
            this.currentValue = currentValue;
            this.maxValue = maxValue;
        }
    }
}
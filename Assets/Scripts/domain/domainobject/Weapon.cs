namespace DefaultNamespace.domain.domainobject
{
    public class Weapon
    {
        // 게임오브젝트고유번호
        public  int gameObjectId;
        // 웨폰타입
        public  WeaponType weaponType;
        // 최소값
        public  int minValue;
        // 현재값
        public  int currentValue;
        // 최대값
        public  int maxValue;
        // 폭탄의 에니지(폭탄이 별도의 캐릭터일떄 에너지바 또는 시간바를 표시)
        public  Energy energy;

        public Weapon(int gameObjectId, WeaponType weaponType, int minValue, int currentValue, int maxValue, Energy energy)
        {
            this.gameObjectId = gameObjectId;
            this.weaponType = weaponType;
            this.minValue = minValue;
            this.currentValue = currentValue;
            this.maxValue = maxValue;
            this.energy = energy;
        }
    }
}
namespace DefaultNamespace.domain.valueobject
{
    public struct EnemyHpPlusByOutside
    {
        public int owenerGameObjectId;
        public int fromGameObjectId;
        public int plusMinusCount;
        public EnemyHpPlusByOutside(int owenerGameObjectId,int fromGameObjectId, int plusMinusCount)
        {
            this.owenerGameObjectId = owenerGameObjectId;
            this.fromGameObjectId = fromGameObjectId;
            this.plusMinusCount = plusMinusCount;
        }
    }
}
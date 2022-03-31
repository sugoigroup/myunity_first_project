namespace DefaultNamespace.domain.valueobject
{
    public struct HpPlusByOutside
    {
        public int owenerGameObjectId;
        public int fromGameObjectId;
        public int plusMinusCount;
        public HpPlusByOutside(int owenerGameObjectId,int fromGameObjectId, int plusMinusCount)
        {
            this.owenerGameObjectId = owenerGameObjectId;
            this.fromGameObjectId = fromGameObjectId;
            this.plusMinusCount = plusMinusCount;
        }
    }
}
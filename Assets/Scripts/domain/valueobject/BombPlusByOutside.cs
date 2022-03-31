namespace DefaultNamespace.domain.valueobject
{
    public struct BombPlusByOutside
    {
        public int owenerGameObjectId;
        public int plusMinusCount;
        public BombPlusByOutside(int owenerGameObjectId, int plusMinusCount)
        {
            this.owenerGameObjectId = owenerGameObjectId;
            this.plusMinusCount = plusMinusCount;
        }
    }
}
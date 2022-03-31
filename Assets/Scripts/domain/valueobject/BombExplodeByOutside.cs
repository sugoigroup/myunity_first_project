namespace DefaultNamespace.domain.valueobject
{
    public struct BombExplodeByOutside
    {
        public int owenerGameObjectId;
        public int plusMinusCount;
        public BombExplodeByOutside(int owenerGameObjectId, int plusMinusCount)
        {
            this.owenerGameObjectId = owenerGameObjectId;
            this.plusMinusCount = plusMinusCount;
        }
        
    }
}
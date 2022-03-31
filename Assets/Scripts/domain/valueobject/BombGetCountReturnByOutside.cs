namespace DefaultNamespace.domain.valueobject
{
    public struct BombGetCountReturnByOutside
    {
        public int owenerGameObjectId;
        public int bombCount;
        public BombGetCountReturnByOutside(int owenerGameObjectId,int bombCount)
        {
            this.owenerGameObjectId = owenerGameObjectId;
            this.bombCount = bombCount;
        }
    }
}
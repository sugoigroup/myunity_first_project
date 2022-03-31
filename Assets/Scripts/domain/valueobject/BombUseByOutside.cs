namespace DefaultNamespace.domain.valueobject
{
    public struct BombUseByOutside
    {
        public int owenerGameObjectId;
        public BombUseByOutside(int owenerGameObjectId)
        {
            this.owenerGameObjectId = owenerGameObjectId;
        }
    }
}
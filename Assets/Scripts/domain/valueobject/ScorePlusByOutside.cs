namespace DefaultNamespace.domain.valueobject
{
    public struct ScorePlusByOutside
    {
        public int owenerGameObjectId;
        public int score;
        public ScorePlusByOutside(int owenerGameObjectId, int score)
        {
            this.owenerGameObjectId = owenerGameObjectId;
            this.score = score;
        }
    }
}
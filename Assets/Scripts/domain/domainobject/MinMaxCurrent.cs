namespace DefaultNamespace.domain.domainobject
{
    public struct MinMaxCurrent
    {
        // 최소값
        public readonly int minValue;
        // 최대값
        public readonly int maxValue;
        // 현재값
        public readonly int currentValue;

        public MinMaxCurrent(int minValue, int maxValue, int currentValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
            this.currentValue = currentValue;
        }
    }
}

using DefaultNamespace.domain.domainobject;

namespace DefaultNamespace.Domain.UseCase
{
    public class EnergySaveUseCaseIO
    {
        public struct Input
        {
            // 에너지
            public Energy energy;

            public Input(Energy energy)
            {
                this.energy = energy;
            }
        }
        
        public struct Output{}
    }
}
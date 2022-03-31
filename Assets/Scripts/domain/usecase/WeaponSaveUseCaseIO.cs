
using DefaultNamespace.domain.domainobject;

namespace DefaultNamespace.Domain.UseCase
{
    public class WeaponSaveUseCaseIO
    {
        public struct Input
        {
            // 에너지
            public Weapon weapon;

            public Input(Weapon weapon)
            {
                this.weapon = weapon;
            }
        }
        
        public struct Output{}
    }
}
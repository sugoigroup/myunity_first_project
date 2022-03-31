using DefaultNamespace.domain.domainobject;
using DefaultNamespace.domain.valueobject;

namespace DefaultNamespace.domain.repository
{
    public class WeaponRepositoryIO
    {
        public class SaveWeapon
        {
            public struct Input
            {
                // 에너지타입
                public Weapon weapon;

                public Input(Weapon weapon)
                {
                    this.weapon = weapon;
                }
            }

        }
        
        public class RemoveWeapon
        {
            public struct Input
            {
                // 게임오브젝트고유번호
                public int gameObjectId;
                // 에너지타입
                public WeaponType weaponType;

                public Input(int gameObjectId, WeaponType weaponType)
                {
                    this.gameObjectId = gameObjectId;
                    this.weaponType = weaponType;
                }
            }
        }

        public class FetchWeapon
        {
            public struct Input
            {
                // 게임오브젝트고유번호
                public int gameObjectId;
                // 에너지타입
                public WeaponType weaponType;

                public Input(int gameObjectId, WeaponType weaponType)
                {
                    this.gameObjectId = gameObjectId;
                    this.weaponType = weaponType;
                }
            }
            
            public struct Output
            {

                public Output(IResults<Weapon, Error> results)
                {
                    this.results = results;
                }
                
                // 게임오브젝트고유번호
                public IResults<Weapon, Error> results;


                public enum Error
                {
                    API,
                    OTHER
                }
            }
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace.domain.domainobject;

namespace DefaultNamespace.data.local.staticlao
{
    public class WeaponStaticLao : StaticLao<Weapon>
    {
        private static List<Weapon> _weapons = new List<Weapon>();
        private int _gameObjectId ;
        private WeaponType _weaponType  ;

        public WeaponStaticLao(int gameObjectId, WeaponType weaponType)
        {
            _gameObjectId =  gameObjectId;
            _weaponType = weaponType;
        }
        
        public void save(Weapon newValue)
        {
            // Effective C# Item1 지역변수는 var로 받아야 빠름. 단, float이나 double은 명시적으로 하는게 좋음.
            var weapon = _weapons.FirstOrDefault(x => isEqualGameIdAndType(x));
            if (weapon == null)
            {
                _weapons.Add(newValue);
            }
            else
            {
                weapon.currentValue = newValue.currentValue;
                weapon.maxValue = newValue.maxValue;
                weapon.minValue = newValue.minValue;
            }
        }

        private bool isEqualGameIdAndType(Weapon x)
        {
            return x.gameObjectId == _gameObjectId && x.weaponType == _weaponType;
        }


        public Weapon fetchOrNull()
        {
            return _weapons.FirstOrDefault(x => isEqualGameIdAndType(x));
        }

        public void remove()
        {
            _weapons.Remove(
                _weapons.FirstOrDefault(x => isEqualGameIdAndType(x))
            );
        }
    }
}
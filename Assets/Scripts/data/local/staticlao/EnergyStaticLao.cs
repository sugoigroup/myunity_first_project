using System.Collections.Generic;
using System.Linq;
using DefaultNamespace.domain.domainobject;
using DefaultNamespace.domain.valueobject;

namespace DefaultNamespace.data.local.staticlao
{
    public class EnergyStaticLao : StaticLao<Energy>
    {
        private static List<Energy> _energys = new List<Energy>();
        private int _gameObjectId ;
        private EnergyType _energyType  ;

        public EnergyStaticLao(int gameObjectId, EnergyType energyType)
        {
            _gameObjectId =  gameObjectId;
            _energyType = energyType;
        }
        
        public void save(Energy newValue)
        {
            // Effective C# Item1 지역변수는 var로 받아야 빠름. 단, float이나 double은 명시적으로 하는게 좋음.
            var energy = _energys.FirstOrDefault(x => isEqualGameIdAndType(x));
            if (energy == null)
            {
                _energys.Add(newValue);
            }
            else
            {
                energy.currentValue = newValue.currentValue;
                energy.maxValue = newValue.maxValue;
                energy.minValue = newValue.minValue;
            }
        }

        private bool isEqualGameIdAndType(Energy x)
        {
            return x.gameObjectId == _gameObjectId && x.energyType == _energyType;
        }


        public Energy fetchOrNull()
        {
            return _energys.FirstOrDefault(x => isEqualGameIdAndType(x));
        }

        public void remove()
        {
            _energys.Remove(
                _energys.FirstOrDefault(x => isEqualGameIdAndType(x))
            );
        }
    }
}
using DefaultNamespace.domain.domainobject;
using DefaultNamespace.domain.valueobject;

namespace DefaultNamespace.domain.repository
{
    public class EnergyRepositoryIO
    {
        public class SaveEnergy
        {
            public struct Input
            {
                // 에너지타입
                public Energy energy;

                public Input(Energy energy)
                {
                    this.energy = energy;
                }
            }

        }
        
        public class RemoveEnergy
        {
            public struct Input
            {
                // 게임오브젝트고유번호
                public int gameObjectId;
                // 에너지타입
                public EnergyType energyType;

                public Input(int gameObjectId, EnergyType energyType)
                {
                    this.gameObjectId = gameObjectId;
                    this.energyType = energyType;
                }
            }
        }

        public class FetchEnergy
        {
            public struct Input
            {
                // 게임오브젝트고유번호
                public int gameObjectId;
                // 에너지타입
                public EnergyType energyType;

                public Input(int gameObjectId, EnergyType energyType)
                {
                    this.gameObjectId = gameObjectId;
                    this.energyType = energyType;
                }
            }
            
            public struct Output
            {

                public Output(IResults<Energy, Error> results)
                {
                    this.results = results;
                }
                
                // 게임오브젝트고유번호
                public IResults<Energy, Error> results;


                public enum Error
                {
                    API,
                    OTHER
                }
            }
        }
    }
}
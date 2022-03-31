using DefaultNamespace.domain.valueobject;
using DefaultNamespace.domain.domainobject;
using DefaultNamespace.domain.repository;

namespace DefaultNamespace.Domain.UseCase
{
    public class RemoveEnergyUseCaseIO
    {
        public struct Input
        {
            // 게임오브젝트고유번호
            public int gameObjectId;

            // 에너지타입
            public EnergyType energyType;
        }

        public  class Converter
        {
            public EnergyRepositoryIO.RemoveEnergy.Input toRepositoryInput(
                RemoveEnergyUseCaseIO.Input input
            )
            {
                return new EnergyRepositoryIO.RemoveEnergy.Input(
                    input.gameObjectId,
                    input.energyType
                );
            }
        }
    }
}
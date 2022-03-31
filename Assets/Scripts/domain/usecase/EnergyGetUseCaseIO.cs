using DefaultNamespace.domain.valueobject;
using DefaultNamespace.domain.domainobject;
using DefaultNamespace.domain;
using DefaultNamespace.domain.repository;

namespace DefaultNamespace.Domain.UseCase
{
    public class EnergyGetUseCaseIO
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

        public class Output
        {
            public Output(IResults<Energy, Error> results)
            {
                this.results = results;
            }

            public IResults<Energy, Error> results;

            public enum Error
            {
                ERROR
            }
        }

        public  class Converter
        {
            public EnergyRepositoryIO.FetchEnergy.Input toRepositoryInput(
                EnergyGetUseCaseIO.Input input
            )
            {
                return new EnergyRepositoryIO.FetchEnergy.Input(
                    input.gameObjectId,
                    input.energyType
                );
            }

            public IResults<Energy, Output.Error> toDomainOutput(EnergyRepositoryIO.FetchEnergy.Output output)
            {
                // Success
                // Effective C# Item3 is, as 활용하자 
                if (output.results is Success<Energy, EnergyRepositoryIO.FetchEnergy.Output.Error>)
                {
                    return new Success<Energy, Output.Error>(output.results.returnData());
                }
                
                // Error
                var errorCode = Output.Error.ERROR;
                if (output.results.errorCode() == EnergyRepositoryIO.FetchEnergy.Output.Error.API)
                {
                    errorCode = Output.Error.ERROR;
                }
                return new Failure<Energy, Output.Error>(errorCode);
               
            }
        }
    }
}
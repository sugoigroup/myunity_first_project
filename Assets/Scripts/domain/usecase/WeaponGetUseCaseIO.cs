using System;
using DefaultNamespace.domain.valueobject;
using DefaultNamespace.domain.domainobject;
using DefaultNamespace.domain;
using DefaultNamespace.domain.repository;

namespace DefaultNamespace.Domain.UseCase
{
    public class WeaponGetUseCaseIO
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

        public class Output
        {
            public Output(IResults<Weapon, Error> results)
            {
                this.results = results;
            }

            public IResults<Weapon, Error> results;

            public enum Error
            {
                ERROR
            }
        }

        public class OutputForCount
        {
            public OutputForCount(MinMaxCurrent results)
            {
                this.results = results;
            }

            public MinMaxCurrent results;
        }

        public  class Converter
        {
            public WeaponRepositoryIO.FetchWeapon.Input toRepositoryInput(
                WeaponGetUseCaseIO.Input input
            )
            {
                return new WeaponRepositoryIO.FetchWeapon.Input(
                    input.gameObjectId,
                    input.weaponType
                );
            }

            public IResults<Weapon, Output.Error> toDomainOutput(WeaponRepositoryIO.FetchWeapon.Output output)
            {
                // Success
                // Effective C# Item3 is, as 활용하자 
                if (output.results is Success<Weapon, WeaponRepositoryIO.FetchWeapon.Output.Error>)
                {
                    return new Success<Weapon, Output.Error>(output.results.returnData());
                }
                
                // Error
                var errorCode = Output.Error.ERROR;
                if (output.results.errorCode() == WeaponRepositoryIO.FetchWeapon.Output.Error.API)
                {
                    errorCode = Output.Error.ERROR;
                }
                return new Failure<Weapon, Output.Error>(errorCode);
               
            }

            public MinMaxCurrent toDomainOutputForCount(WeaponRepositoryIO.FetchWeapon.Output output)
            {
                // Success
                // Effective C# Item3 is, as 활용하자 
                if (output.results is Success<Weapon, WeaponRepositoryIO.FetchWeapon.Output.Error>)
                {
                    return new MinMaxCurrent(
                        minValue: output.results.returnData().minValue,
                        maxValue: output.results.returnData().maxValue,
                        currentValue: output.results.returnData().currentValue
                     );
                }
                return new MinMaxCurrent(0,0,0);
               
            }
        }
    }
}
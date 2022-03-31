using System;
using DefaultNamespace.data;
using DefaultNamespace.domain.repository;

namespace DefaultNamespace.Domain.UseCase
{
    public class WeaponGetUseCase : IWeaponGetUseCase
    {
        private WeaponRepository _weaponRepository = new WeaponRepositoryImpl();
        private WeaponGetUseCaseIO.Converter _converter = new WeaponGetUseCaseIO.Converter();

        public WeaponGetUseCaseIO.Output execute(WeaponGetUseCaseIO.Input input)
        {
            return new WeaponGetUseCaseIO.Output(
                results: _converter.toDomainOutput(
                    output: _weaponRepository.fetchWeapon(
                        _converter.toRepositoryInput(
                            input: input
                        )
                    )
                )
            );
        }

        public WeaponGetUseCaseIO.OutputForCount fetchWeaponCount(WeaponGetUseCaseIO.Input input)
        {
            return new WeaponGetUseCaseIO.OutputForCount(
                results: _converter.toDomainOutputForCount(
                    output: _weaponRepository.fetchWeapon(
                        _converter.toRepositoryInput(
                            input: input
                        )
                    )
                )
            );
        }
    }
}
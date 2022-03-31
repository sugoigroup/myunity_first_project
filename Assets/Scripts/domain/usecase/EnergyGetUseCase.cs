using System;
using DefaultNamespace.data;
using DefaultNamespace.domain.repository;

namespace DefaultNamespace.Domain.UseCase
{
    public class EnergyGetUseCase : IEnergyGetUseCase
    {
        private EnergyRepository _energyRepository = new EnergyRepositoryImpl();
        private EnergyGetUseCaseIO.Converter _converter = new EnergyGetUseCaseIO.Converter();

        public EnergyGetUseCaseIO.Output execute(EnergyGetUseCaseIO.Input input)
        {
            return new EnergyGetUseCaseIO.Output(
                results: _converter.toDomainOutput(
                    output: _energyRepository.fetchEnergy(
                        _converter.toRepositoryInput(
                            input: input
                        )
                    )
                )
            );
        }
    }
}
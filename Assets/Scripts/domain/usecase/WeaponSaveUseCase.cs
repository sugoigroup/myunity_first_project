using DefaultNamespace.data;
using DefaultNamespace.domain.domainobject;
using DefaultNamespace.domain.repository;

namespace DefaultNamespace.Domain.UseCase
{
    public class WeaponSaveUseCase : IWeaponSaveUseCase
    {
        private WeaponRepository _weaponRepository = new WeaponRepositoryImpl();

        public void execute(WeaponSaveUseCaseIO.Input weaponSaveUseCaseInput)
        {
            _weaponRepository.saveWeapon(
                new WeaponRepositoryIO.SaveWeapon.Input(
                    weaponSaveUseCaseInput.weapon
                )
            );
        }
    }
}
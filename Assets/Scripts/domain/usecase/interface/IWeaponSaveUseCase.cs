using DefaultNamespace.domain.domainobject;

namespace DefaultNamespace.Domain.UseCase
{
    public interface IWeaponSaveUseCase
    {
        public void execute(WeaponSaveUseCaseIO.Input weaponSaveUseCaseInput);
    }
}
using DefaultNamespace.Domain.UseCase;

namespace DefaultNamespace.Domain.UseCase
{
    public interface IWeaponGetUseCase
    {
        public WeaponGetUseCaseIO.Output execute(WeaponGetUseCaseIO.Input weaponGetUseCaseInput);
        public WeaponGetUseCaseIO.OutputForCount fetchWeaponCount(WeaponGetUseCaseIO.Input weaponGetUseCaseInput);
    }
}
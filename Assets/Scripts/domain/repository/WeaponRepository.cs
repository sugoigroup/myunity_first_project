using DefaultNamespace.domain.domainobject;

namespace DefaultNamespace.domain.repository
{
    public interface WeaponRepository
    {
        public WeaponRepositoryIO.FetchWeapon.Output fetchWeapon(WeaponRepositoryIO.FetchWeapon.Input input);
        public void removeWeapon(WeaponRepositoryIO.RemoveWeapon.Input input);
        public void saveWeapon(WeaponRepositoryIO.SaveWeapon.Input input);
    }
}
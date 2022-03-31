using DefaultNamespace.data.local.staticlao;
using DefaultNamespace.domain;
using DefaultNamespace.domain.domainobject;
using DefaultNamespace.domain.repository;

namespace DefaultNamespace.data
{
    public class WeaponRepositoryImpl : WeaponRepository
    {
        private WeaponStaticLao _weaponStaticLao;

        public WeaponRepositoryIO.FetchWeapon.Output fetchWeapon(WeaponRepositoryIO.FetchWeapon.Input input)
        {
            _weaponStaticLao = new WeaponStaticLao(input.gameObjectId, input.weaponType);
            Weapon weapon = _weaponStaticLao.fetchOrNull();

            if (weapon == null)
            {
                return new WeaponRepositoryIO.FetchWeapon.Output(
                    new Failure<Weapon, WeaponRepositoryIO.FetchWeapon.Output.Error>(
                        WeaponRepositoryIO.FetchWeapon.Output.Error.OTHER
                    )
                );
            }
            else
            {
                return new WeaponRepositoryIO.FetchWeapon.Output(
                    new Success<Weapon, WeaponRepositoryIO.FetchWeapon.Output.Error>(
                        weapon
                    )
                );
            }
        }

        public void removeWeapon(WeaponRepositoryIO.RemoveWeapon.Input input)
        {
            _weaponStaticLao = new WeaponStaticLao(input.gameObjectId, input.weaponType);
            _weaponStaticLao.remove();
        }

        public void saveWeapon(WeaponRepositoryIO.SaveWeapon.Input input)
        {
            _weaponStaticLao = new WeaponStaticLao(input.weapon.gameObjectId, input.weapon.weaponType);
            _weaponStaticLao.save(input.weapon);
        }
    }
}
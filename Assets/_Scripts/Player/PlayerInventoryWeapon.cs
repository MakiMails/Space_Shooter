using Game.WeaponScripts;
using UnityEngine;
using UnityEngine.Events;

namespace Game.PlayerScripts
{
    internal class PlayerInventoryWeapon : MonoBehaviour
    {
        [SerializeField] private Weapon _weaponInHands;
        [SerializeField] private Weapon[] _weapons = new Weapon[2];

        public UnityEvent SwiftchWeaponEvent;

        public void PreesKey()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                SwitchWeapon(0);

            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                SwitchWeapon(1);
            }
        }

        private void SwitchWeapon(int i)
        {
            if (i < _weapons.Length && _weapons[i] != null)
            {
                (_weaponInHands, _weapons[i]) = (_weapons[i],  _weaponInHands);
                OnSwitchWeapon();
            }
        }

        private void OnSwitchWeapon()
        {
            SwiftchWeaponEvent.Invoke();
        }
    }
}

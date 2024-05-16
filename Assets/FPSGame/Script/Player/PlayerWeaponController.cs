using UnityEngine;

namespace FPSGame
{
    
    public class PlayerWeaponController : MonoBehaviour
    {
        [SerializeField] private Transform weaponHoler;
        [SerializeField] private PlayerWeapon weapon;
        private void Awake()
        {
            weapon.LoadWeapon(weaponHoler);
        }

        private void Update()
        {
            if (PlayerInputManager.isFire)
            {
                weapon.Fire();
            }
        }
    }
    
}

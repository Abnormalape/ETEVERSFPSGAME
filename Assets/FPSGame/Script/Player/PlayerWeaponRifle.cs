using UnityEngine;

namespace FPSGame
{
    public class PlayerWeaponRifle : PlayerWeapon
    {
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private Transform muzzleTransform;

        [SerializeField] private AudioSource audioPlayer;
        [SerializeField] private AudioClip fireSound;
        public override void Fire()
        {
            base.Fire();
            Instantiate(bulletPrefab, muzzleTransform.position, muzzleTransform.rotation);

            audioPlayer.PlayOneShot(fireSound);
        }
    }
}

using UnityEditor;
using Unity;
using UnityEngine;
using UnityEngine.Events; // 이벤트 제작시 필요

namespace FPSGame
{
    public class PlayerWeaponRifle : PlayerWeapon
    {
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private Transform muzzleTransform;

        [SerializeField] private AudioSource audioPlayer;
        [SerializeField] private AudioClip fireSound;

        [SerializeField] private ParticleSystem cartridgeEjectEffect;
        [SerializeField] private ParticleSystem muzzleFlashEffect;
        [SerializeField] private CameraShake CameraShake;

        //플레이어 데이터
        [SerializeField] private PlayerData data;
        [SerializeField] private int currentAmmo = 0;
        [SerializeField] private PlayerAnimationController animationController;

        [SerializeField] private AudioClip reloadWeaponClip;
        [SerializeField] private float fireRate = 0.1f;
        private float nextFireTime = 0f;

        public UnityEvent OnReloadEvent;
        // 발사가 가능한가?
        private bool CanFire { get { return currentAmmo > 0 && Time.time > nextFireTime; } }
        protected override void Awake()
        {
            base.Awake();
            currentAmmo = data.maxAmmo;
        }

        
        
        public override void Fire()
        {
            base.Fire();
            
            if(!CanFire)
            {
                return;
            }

            nextFireTime = Time.time + fireRate;

            --currentAmmo;

            Instantiate(bulletPrefab, muzzleTransform.position, muzzleTransform.rotation);

            audioPlayer.PlayOneShot(fireSound);

            cartridgeEjectEffect.Play();
            muzzleFlashEffect.Play();
            CameraShake.Play();

            if (currentAmmo== 0)
            {
                //재장전 처리
                //재장전 애니메이션 재생
                //재장전 애니메이션 시간 만큼 대기후 Reload 함수 실행.
                audioPlayer.PlayOneShot(reloadWeaponClip);
                
                // animationController.onReload();
                OnReloadEvent?.Invoke(); // Null이면 인보크??

                Invoke("Reload", animationController.WaitTimeToReload());
            }
        }
        private void Reload()
        {
            currentAmmo = data.maxAmmo;
        }
    }
}

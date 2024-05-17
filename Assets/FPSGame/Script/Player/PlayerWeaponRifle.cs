using UnityEditor;
using Unity;
using UnityEngine;
using UnityEngine.Events; // �̺�Ʈ ���۽� �ʿ�

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

        //�÷��̾� ������
        [SerializeField] private PlayerData data;
        [SerializeField] private int currentAmmo = 0;
        [SerializeField] private PlayerAnimationController animationController;

        [SerializeField] private AudioClip reloadWeaponClip;
        [SerializeField] private float fireRate = 0.1f;
        private float nextFireTime = 0f;

        public UnityEvent OnReloadEvent;
        // �߻簡 �����Ѱ�?
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
                //������ ó��
                //������ �ִϸ��̼� ���
                //������ �ִϸ��̼� �ð� ��ŭ ����� Reload �Լ� ����.
                audioPlayer.PlayOneShot(reloadWeaponClip);
                
                // animationController.onReload();
                OnReloadEvent?.Invoke(); // Null�̸� �κ�ũ??

                Invoke("Reload", animationController.WaitTimeToReload());
            }
        }
        private void Reload()
        {
            currentAmmo = data.maxAmmo;
        }
    }
}

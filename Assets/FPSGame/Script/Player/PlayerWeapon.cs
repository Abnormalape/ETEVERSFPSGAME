using UnityEngine;

namespace FPSGame
{
    public class PlayerWeapon : MonoBehaviour
    {
        //������ ���� �߰�
        // ��ġ �� ȸ���� ������ �ʿ��Ҷ� ����� ����
        [SerializeField] private Vector3 positionOffSet;
        [SerializeField] private Vector3 rotationOffSet;

        protected virtual void Awake()
        {

        }

        public void LoadWeapon (Transform weaponHolder)
        {
            transform.SetParent(weaponHolder);
            transform.localPosition = Vector3.zero + positionOffSet;
            transform.localRotation =   Quaternion.identity * Quaternion.Euler(rotationOffSet);
            transform.localScale = Vector3.one;
        }
        public virtual void Fire()
        {

        }
    }

    
}

using UnityEngine;

namespace FPSGame
{
    public class PlayerWeapon : MonoBehaviour
    {
        //오프셋 변수 추가
        // 위치 및 회전의 조정이 필요할때 사용할 변수
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

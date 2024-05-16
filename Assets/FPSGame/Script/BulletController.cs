using UnityEngine;

namespace FPSGame
{
    public class BulletController : MonoBehaviour
    {
        [SerializeField] private GameObject collisionDecal;

        private void OnCollisionEnter(Collision collision)
        {
            // 충돌한 물체의 레이어를 확인해서 wall이면 상호작용
            if(collision.gameObject.layer == LayerMask.NameToLayer("Wall"))
            {
                ContactPoint contact = collision.contacts[0]; // 첫번째 벽
                Quaternion rotation = Quaternion.LookRotation(contact.normal); // 부딪힌곳의 법선을 체크해서 이미지 생성
                Instantiate(collisionDecal, contact.point, rotation);
            }

            if (collision.gameObject.layer != LayerMask.NameToLayer("Bullet"))
            {
                Destroy(gameObject);
            }
        }
    }
}

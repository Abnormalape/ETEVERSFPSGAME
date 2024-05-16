using UnityEngine;

namespace FPSGame
{
    public class BulletController : MonoBehaviour
    {
        [SerializeField] private GameObject collisionDecal;

        private void OnCollisionEnter(Collision collision)
        {
            // �浹�� ��ü�� ���̾ Ȯ���ؼ� wall�̸� ��ȣ�ۿ�
            if(collision.gameObject.layer == LayerMask.NameToLayer("Wall"))
            {
                ContactPoint contact = collision.contacts[0]; // ù��° ��
                Quaternion rotation = Quaternion.LookRotation(contact.normal); // �ε������� ������ üũ�ؼ� �̹��� ����
                Instantiate(collisionDecal, contact.point, rotation);
            }

            if (collision.gameObject.layer != LayerMask.NameToLayer("Bullet"))
            {
                Destroy(gameObject);
            }
        }
    }
}

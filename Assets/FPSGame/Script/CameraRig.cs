using UnityEngine;

namespace FPSGame
{
    public class CameraRig : MonoBehaviour
    {
        //todo: �÷��̾ ����ٴϴ� ī�޶� ��� �߰�
        // ���� �Ǿ��ִ¾ִ� �۾���Ͽ� ǥ�ð� �ȴ�. => ����� ��Ʃ��� ��ɾ�

        [SerializeField] private Transform target;
        [SerializeField] private float damping = 5f;

        private Transform refTransform;

        private void Awake()
        {
            refTransform = transform;
        }

        private void LateUpdate()
        {
            // Lerp.
            refTransform.position = Vector3.Lerp(refTransform.position, target.position, damping * Time.deltaTime);
        }
    }
}

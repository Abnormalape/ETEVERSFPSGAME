using UnityEngine;

namespace FPSGame
{
    public class CameraRig : MonoBehaviour
    {
        //todo: �÷��̾ ����ٴϴ� ī�޶� ��� �߰�
        // ���� �Ǿ��ִ¾ִ� �۾���Ͽ� ǥ�ð� �ȴ�. => ����� ��Ʃ��� ��ɾ�
        [Header("�÷��̾� ����ٴϴ� ���")]
        [SerializeField] private Transform target;
        [SerializeField] private float damping = 5f;
        [SerializeField] private float ratationDamping = 5f;
        
        private Transform refTransform;

        [Header("ī�޶� ���� �巡��")]
        // ���� ȸ���� ����ϴ� ����.
        [SerializeField] private Transform cameraTransform;     // ���� ī�޶� Ʈ������.
        [SerializeField] private float minAngle = -30f;         // ���� ȸ�� �ּ� ���� ��.
        [SerializeField] private float maxAngle = 40f;          // ���� ȸ�� �ִ� ���� ��.
        [SerializeField] private float xRotation = 0f;          // ī�޶��� x�� ���� ȸ���� ����ϱ� ���� ����.

        private void Awake()
        {
            refTransform = transform;
        }

        private void LateUpdate()
        {
            // Lerp.
            refTransform.position = Vector3.Lerp(refTransform.position, target.position, damping * Time.deltaTime);

            // Lerp
            refTransform.rotation = Quaternion.Lerp(refTransform.rotation, target.rotation, ratationDamping * Time.deltaTime);

            Look();
        }

        private void Look()
        {
            float mouseY = Mathf.Clamp(PlayerInputManager.Look, -1f, 1f);

            xRotation -= mouseY;

            xRotation = Mathf.Clamp(xRotation, minAngle, maxAngle);

            Vector3 targetrotation = cameraTransform.localRotation.eulerAngles;
            targetrotation.x = xRotation * 2f;

            cameraTransform.localRotation = Quaternion.Euler(targetrotation);
        }

        public float GetXRotation()
        {
            return xRotation;
        }
    }
}

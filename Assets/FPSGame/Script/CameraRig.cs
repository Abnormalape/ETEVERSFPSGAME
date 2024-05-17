using UnityEngine;

namespace FPSGame
{
    public class CameraRig : MonoBehaviour
    {
        //todo: 플레이어를 따라다니느 카메라 기능 추가
        // 투두 되어있는애는 작업목록에 표시가 된다. => 비쥬얼 스튜디오 명령어
        [Header("플레이어 따라다니는 기능")]
        [SerializeField] private Transform target;
        [SerializeField] private float damping = 5f;
        [SerializeField] private float ratationDamping = 5f;
        
        private Transform refTransform;

        [Header("카메라 상하 드래그")]
        // 상하 회전에 사용하는 변수.
        [SerializeField] private Transform cameraTransform;     // 메인 카메라 트랜스폼.
        [SerializeField] private float minAngle = -30f;         // 상하 회전 최소 각도 값.
        [SerializeField] private float maxAngle = 40f;          // 상하 회전 최대 각도 값.
        [SerializeField] private float xRotation = 0f;          // 카메라의 x축 누적 회전을 계산하기 위한 변수.

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

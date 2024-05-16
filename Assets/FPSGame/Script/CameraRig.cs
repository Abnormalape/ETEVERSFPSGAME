using UnityEngine;

namespace FPSGame
{
    public class CameraRig : MonoBehaviour
    {
        //todo: 플레이어를 따라다니느 카메라 기능 추가
        // 투두 되어있는애는 작업목록에 표시가 된다. => 비쥬얼 스튜디오 명령어

        [SerializeField] private Transform target;
        [SerializeField] private float damping = 5f;
        [SerializeField] private float ratationDamping = 5f;

        private Transform refTransform;

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
        }
    }
}

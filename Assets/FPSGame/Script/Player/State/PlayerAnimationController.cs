using UnityEngine;
using UnityEngine.Animations;
namespace FPSGame
{
    internal class PlayerAnimationController : MonoBehaviour
    {
        [SerializeField] private Animator animator;

        [SerializeField] private CameraRig cameraRig;
        [SerializeField] private float rotationOffset = 0.5f;

        private void Update()
        {
            // AimAngle 파라미터에 값 설정.
            animator.SetFloat("AimAngle", cameraRig.GetXRotation() * rotationOffset);
        }

        public void onReload()
        {
            // Reload 트리거 파라미터를 설정.
            animator.SetTrigger("Reload");
        }

        public float WaitTimeToReload()
        {
            return animator.GetCurrentAnimatorStateInfo(2).length / animator.GetFloat("ReloadSpeed");
        }

        public void SetStateParameter(int state)
        {
            animator.SetInteger("State",state);
        }

        public void SetHorizontalParameter(float horizontal)
        {
            horizontal = horizontal > 0f ? 1f : horizontal < 0f ? -1 : 0f;
        }
        public void SetVerticalParameter(float vertical)
        {
            vertical= vertical> 0f ? 1f : vertical< 0f ? -1 : 0f;
        }
    }
}

using UnityEngine;
namespace FPSGame
{
    internal class PlayerAnimationController : MonoBehaviour
    {
        [SerializeField] private Animator animator;

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

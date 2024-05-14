using UnityEngine;
namespace FPSGame
{
    public class PlayerMoveState : PlayerState
    {
        [SerializeField] private float moveSpeed = 5f;

        protected override void Update()
        {
            base.Update(); // 부모

            Vector3 direction = new Vector3(PlayerInputManager.Horizontal, 0f , PlayerInputManager.Vertical);

            refTransform.position += direction.normalized * moveSpeed * Time.deltaTime;
        }
    }
}
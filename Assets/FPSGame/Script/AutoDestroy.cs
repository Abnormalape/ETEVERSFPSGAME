using UnityEngine;

namespace FPSGame
{
    public class AutoDestroy : MonoBehaviour
    {
        // 삭제까지 대기하는 시간 (초)
        [SerializeField] private float destroyTime = 3f;

        private void Awake()
        {
            Destroy(gameObject, destroyTime);
        }
    }
}

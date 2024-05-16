using UnityEngine;

namespace FPSGame
{
    public class AutoDestroy : MonoBehaviour
    {
        // �������� ����ϴ� �ð� (��)
        [SerializeField] private float destroyTime = 3f;

        private void Awake()
        {
            Destroy(gameObject, destroyTime);
        }
    }
}
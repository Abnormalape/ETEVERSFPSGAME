using UnityEngine;

namespace FPSGame
{
    public class PlayerControl : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 5f;

        private Transform reftransform;

        private void Awake()
        {
            reftransform = transform;
        }

        private void Update()
        {
            float hori = Input.GetAxis("Horizontal");
            float verti = Input.GetAxis("Vertical");

            reftransform.position += new Vector3(hori, 0f, verti).normalized * moveSpeed * Time.deltaTime;
        }
    }
}

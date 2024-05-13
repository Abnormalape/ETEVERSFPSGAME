using Unity.VisualScripting;
using UnityEngine;

namespace FPSGame
{
    public class PlayerControl : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 5f;
        [SerializeField] private Animator refAnimator;

        

        private Transform reftransform;

        private void Awake()
        {
            reftransform = transform;
        }

        private void Update()
        {
            float hori = Input.GetAxis("Horizontal");
            float verti = Input.GetAxis("Vertical");

            
            

            refAnimator.SetFloat("Horizontal", hori>0f?1f:hori<0f?-1f:0f);//»ïÇ×¿¬»êÀÚ
            refAnimator.SetFloat("Vertical", verti > 0f ? 1f : verti < 0f ? -1f : 0f);

            if (hori == 0 && verti==0) { refAnimator.SetInteger("State", 0); }
            else { refAnimator.SetInteger("State", 1); }

            reftransform.position += new Vector3(hori, 0f, verti).normalized * moveSpeed * Time.deltaTime;
        }
    }
}

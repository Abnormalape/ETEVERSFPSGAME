using Unity.VisualScripting;
using UnityEngine;

namespace FPSGame
{
    public enum State
    {   // 문자/이미지를 숫자로 변환시켜주는 장치
        // 난 솔직히 안 좋아해
        Idle,
        Move,
    }

    public class PlayerControl : MonoBehaviour
    {
        [SerializeField] private State currentState = State.Idle;
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

            
            

            refAnimator.SetFloat("Horizontal", hori>0f?1f:hori<0f?-1f:0f);//삼항연산자
            refAnimator.SetFloat("Vertical", verti > 0f ? 1f : verti < 0f ? -1f : 0f);

            if (hori == 0 && verti==0)   {currentState = State.Idle;}
                                    else {currentState = State.Move;}
            
            refAnimator.SetInteger("State", (int)currentState);

            reftransform.position += new Vector3(hori, 0f, verti).normalized * moveSpeed * Time.deltaTime;
        }
    }
}

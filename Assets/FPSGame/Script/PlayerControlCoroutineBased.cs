using System;
using Unity.VisualScripting;
using UnityEngine;

public enum nState
    {
        Idle,
        Move,
    }

namespace FPSGame
{
    //코루틴 기반 유한 상태 기계 스크립트.
    public class PlayerControlCoroutineBased : MonoBehaviour
    {
        [SerializeField]
        private nState currentnState = nState.Idle;
        public void SetnState(nState newState) { currentnState = newState; }
    }
}

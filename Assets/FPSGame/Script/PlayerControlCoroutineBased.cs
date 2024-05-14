﻿using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public enum State
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
        private State currentState = State.Idle;
        // 이동 속도.
        [SerializeField] private float moveSpeed = 5f;

        // Animator 컴포넌트 참조 변수.
        [SerializeField] private Animator refAnimator;

        // 트랜스폼 컴포넌트 참조 변수.
        private Transform refTransform;
        private void Awake()
        {
            refTransform = transform;
            refAnimator = GetComponentInChildren<Animator>();
            StartCoroutine("FSMStart");
        }
        public void SetState(State newState) 
        { 
            currentState = newState;
            refAnimator.SetInteger("State", (int)currentState);
        }

        private void Update()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            // 방향키 입력이 없으면.
            if (horizontal == 0f && vertical == 0f)
            {
                SetState(State.Idle);
            }
            else
            {
                SetState(State.Move);
            }
        }

        IEnumerator FSMStart()
        {
            while (true)
            {
                // 난이도가 오늘 수업 중 가장 높습니다.
                yield return StartCoroutine(currentState.ToString());
            }
        }
        IEnumerator Idle()
        {
            while (currentState == State.Idle)
            {
                yield return null;
            }
        }

        IEnumerator Move()
        {
            while (currentState == State.Move)
            {
                // 1프레임 대기.
                yield return null;

                // 방향키 입력 받기.
                float horizontal = Input.GetAxis("Horizontal");
                float vertical = Input.GetAxis("Vertical");

                // 방향에 대한 애니메이션 설정.
                refAnimator.SetFloat("Horizontal", horizontal > 0f ? 1f : horizontal < 0f ? -1f : 0f);
                refAnimator.SetFloat("Vertical", vertical > 0f ? 1f : vertical < 0f ? -1f : 0f);

                // 이동.
                refTransform.position +=
                    new Vector3(horizontal, 0f, vertical).normalized
                    * moveSpeed
                    * Time.deltaTime;
            }
        }
    }

    
}

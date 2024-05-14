using System;
using System.Collections;
using UnityEngine;

namespace FPSGame
{
    
    public class CoroutineTest : MonoBehaviour
    {
        private void Awake()
        {
            StartCoroutine(TestFunction());
        }

        private void Update()
        {
            
        }
        private IEnumerator TestFunction()
        {
            yield return new WaitForSeconds(1f);
            Debug.Log("1");
            yield return new WaitForSeconds(1f);
            Debug.Log("2");
            yield return new WaitForSeconds(1f);
            Debug.Log("3");
        }
    }
}

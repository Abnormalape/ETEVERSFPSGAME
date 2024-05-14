using Palmmedia.ReportGenerator.Core.CodeAnalysis;
using UnityEngine;
namespace FPSGame
{
    public class PlayerInputManager : MonoBehaviour
    {
        public static float Horizontal { get; private set; } = 0f;
        public static float Vertical { get; private set; } = 0f;
        private void Update()
        {
            Horizontal = Input.GetAxis("Horizontal");
            Vertical = Input.GetAxis("Vertical");
        }
    }
}
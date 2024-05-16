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
            Horizontal = Input.GetAxisRaw("Horizontal");
            Vertical = Input.GetAxisRaw("Vertical");
        }
    }
}
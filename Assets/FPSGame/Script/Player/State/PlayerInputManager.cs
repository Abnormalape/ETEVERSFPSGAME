using Palmmedia.ReportGenerator.Core.CodeAnalysis;
using UnityEngine;
namespace FPSGame
{
    public class PlayerInputManager : MonoBehaviour
    {
        public static float Horizontal { get; private set; } = 0f;
        public static float Vertical { get; private set; } = 0f;
        public static float Turn { get; private set; } = 0f; // 좌우드래그
        public static float Look { get; private set; } = 0f; // 상하드래그
        public static bool isFire { get; private set; } = false;

        private void Awake()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void Update()
        {
            Horizontal = Input.GetAxisRaw("Horizontal");
            Vertical = Input.GetAxisRaw("Vertical");

            Turn = Input.GetAxis("Mouse X"); // 마우스는 픽셀값을 리턴하는데 고작 30픽셀 이동한걸 엔진에선 30미터 이동한것으로 판정할수 있다.
            Look = Input.GetAxis("Mouse Y"); // 그래서 기본적으로 적절한 값으로 낮추는 과정이 필요한데 좌측의 명령어가 그 기능을 어느정도 대체한다

            isFire = Input.GetMouseButtonDown(0);
        }
    }
}
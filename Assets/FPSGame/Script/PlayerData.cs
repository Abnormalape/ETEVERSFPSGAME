using UnityEngine;

namespace FPSGame
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "Data/Create PlayerData")]
    public class PlayerData : ScriptableObject
    {
        // 데이터로 저장할 플레이어 데이터.
        public float moveSpeed = 3f;
        public float rotationSpeed = 540f;
        public float masHP = 100f;
        public int maxAmmo = 20;

    }
}

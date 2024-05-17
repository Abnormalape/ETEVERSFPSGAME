using FPSGame;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    protected Transform refTransform;

    [SerializeField] protected CharacterController characterController;
    [SerializeField] protected float rotationSpeed = 540f;
    

    //플레이어 데이터 ScriptableObject
    protected PlayerData data;

    //플레이어 데이터를 설정하는 함수
    public void SetData(PlayerData data)
    {
        this.data = data;
    }
    protected virtual void OnEnable() // 가상화, 자식이 부모의 기능을 바꿀수 있는 권한을 주는것
    {
        if (refTransform == null)
        {
            refTransform = transform;
        }
        
        if(characterController == null)
        {
            characterController = GetComponent<CharacterController>();  
        }
    }
    protected virtual void Update()
    {
        Vector3 gravity = new Vector3(0,-9.8f,0);
        characterController.Move(gravity*Time.deltaTime);

        Vector3 rotation = new Vector3(0f, PlayerInputManager.Turn * data.rotationSpeed * Time.deltaTime, 0f);
        refTransform.Rotate(rotation);
    }
    protected virtual void OnDisable()
    {

    }
}

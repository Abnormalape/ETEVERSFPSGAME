using UnityEngine;

public class PlayerState : MonoBehaviour
{
    protected Transform refTransform;

    [SerializeField] private CharacterController characterController;

    protected virtual void OnEnable() // ����ȭ, �ڽ��� �θ��� ����� �ٲܼ� �ִ� ������ �ִ°�
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

    }
    protected virtual void OnDisable()
    {

    }
}

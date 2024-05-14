using UnityEngine;

public class PlayerState : MonoBehaviour
{
    protected Transform refTransform;

    protected virtual void OnEnable() // 가상화, 자식이 부모의 기능을 바꿀수 있는 권한을 주는것
    {
        if (refTransform == null)
        {
            refTransform = transform;
        }
    }
    protected virtual void Update()
    {

    }
    protected virtual void OnDisable()
    {

    }
}

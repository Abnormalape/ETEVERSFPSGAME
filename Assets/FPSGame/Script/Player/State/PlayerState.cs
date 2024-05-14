using UnityEngine;

public class PlayerState : MonoBehaviour
{
    protected Transform refTransform;

    protected virtual void OnEnable() // ����ȭ, �ڽ��� �θ��� ����� �ٲܼ� �ִ� ������ �ִ°�
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

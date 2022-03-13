using System.Collections;

// вращение лопастей на ветрогенераторе

using UnityEngine;

public class RotationHead : MonoBehaviour
{
    [SerializeField] private float _speedRotate;
    private Transform _thisTransform;

    void Start()
    {
        _thisTransform = transform; 
    }
    void Update()
    {
        _thisTransform.Rotate(0, 0, _speedRotate * Time.deltaTime);
    }
}

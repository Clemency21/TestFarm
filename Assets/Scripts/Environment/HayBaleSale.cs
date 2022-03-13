using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HayBaleSale : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Transform _backpackTransform;

    public void SetData (Transform targetTransform)
    {
        _backpackTransform = targetTransform;
    }


    void FixedUpdate()
    {
        MoveHayBale();
    }

    private void MoveHayBale()
    {
        transform.position = Vector3.MoveTowards(transform.position, _backpackTransform.position, _speed * Time.deltaTime);
    }
}

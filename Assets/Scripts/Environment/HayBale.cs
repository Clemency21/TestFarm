using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HayBale : MonoBehaviour
{
    [SerializeField] private float _delayTime;
    [SerializeField] private float _speed;
    private GameObject _backpack;
    private bool _permision;
    private Transform _thisTransform, _backpackTransform;

    void Start()
    {
        _backpack = GameObject.FindGameObjectWithTag("Backpack");
        _thisTransform = transform;
        _backpackTransform = _backpack.transform;
        StartCoroutine(Permision());
        GameObject.Find("GameControl").GetComponent<PointsControl>().AddItem(1);
    }


    void FixedUpdate()
    {
        if(_permision)
        {
            MoveHayBale();
        }        
    }

    private void MoveHayBale ()
    {
        _thisTransform.position = Vector3.MoveTowards(transform.position, _backpackTransform.position, _speed * Time.deltaTime);
    }

    private IEnumerator Permision ()
    {
        yield return new WaitForSeconds(_delayTime);
        _permision = true;
        yield return new WaitForSeconds(_delayTime);       
        Destroy(this.gameObject);
        yield return null;
    }
}

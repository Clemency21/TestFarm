using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheatBehavior : MonoBehaviour
{
    [SerializeField] private float _timeGrowth, _maxScale, _minScale;
    [SerializeField] private GameObject _prefabStack, _prefabCutting;
    private PointsControl _pointsControl;
    private GameObject _cuttingEffect;

    private float _currentScale;
    private Transform _thisTransform;
    private bool _growth;

    void Start()
    {
        _pointsControl = GameObject.Find("GameControl").GetComponent<PointsControl>();
        _thisTransform = transform;
        StartGrowth();
    }

    public void StartGrowth ()
    {
        StartCoroutine(WheatGrowth());
        _currentScale = _minScale;
        _growth = false;
        SetScale();
    }

    private void Scale ()
    {
        if (!_growth)
        {
            if (_currentScale < _maxScale) SetScale();
            else
            {
                StopAllCoroutines();
                _growth = true;
                tag = "Wheat";
            }
        }        
    }

    private void SetScale ()
    {
        _thisTransform.localScale = new Vector3(2, _currentScale, 2);
    }

    private IEnumerator WheatGrowth ()
    {
        while (true)
        {
            yield return new WaitForSeconds(_timeGrowth/10);
            _currentScale += 0.1f;
            Scale();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Spit") && _pointsControl.currentItem < _pointsControl._maxItem && _growth)
        {            
            tag = "Finish";
            _growth = false;
            StartGrowth();
            Instantiate(_prefabStack, this.transform.position, Quaternion.identity);
            Destroy( _cuttingEffect =  Instantiate(_prefabCutting, this.transform.position, Quaternion.identity), 2);
        }
    }
}

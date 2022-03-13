using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBackpack : MonoBehaviour
{
    [SerializeField] private float _maxScale;
    [SerializeField] private PointsControl _pointsControl;
    private GameObject _backpack;
    private Transform _backpackTransform;
    private float _coefficientScale;

    void Start()
    {
        SearchBackpack();
    }

    private void SearchBackpack ()
    {
        _backpack = GameObject.FindGameObjectWithTag("Backpack");
        _backpackTransform = _backpack.transform;
        _coefficientScale = _maxScale / _pointsControl._maxItem;
    }

    public void SetScale (int currentItem)
    {
        float scale = _coefficientScale * currentItem;
        _backpackTransform.localScale = new Vector3(scale, scale, scale);
    }
}

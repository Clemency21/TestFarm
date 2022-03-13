using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNewScenario : MonoBehaviour
{

    [SerializeField] private Transform _startPoint;
    [SerializeField] private GameObject _prefabWheat;
    [SerializeField] private ScenarioData _dataScenario;
    [SerializeField] private int _numberScenario;
    private int _row, _col;
    private float _intervalRow, _intrvalCol;
   
    void Start()
    {
        SetDataScenario();
        CreatingSowingField();
    }

    private void SetDataScenario ()
    {
        _row = _dataScenario.ScenariosList[_numberScenario].Row;
        _col = _dataScenario.ScenariosList[_numberScenario].Col;
        _intervalRow = _dataScenario.ScenariosList[_numberScenario].IntervalRow;
        _intrvalCol = _dataScenario.ScenariosList[_numberScenario].IntervalCol;
    }

    public void CreatingSowingField ()
    {
        for(int i = 0; i < _row; i++)
        {
            for(int j = 0; j < _col; j++)
            {
             GameObject wheat = Instantiate(_prefabWheat, transform.position, Quaternion.Euler(0, Random.Range(0, 360), 0), _startPoint);
             wheat.transform.localPosition = new Vector3(_intrvalCol * j, 0, _intervalRow * i);
            }
        }
    }
}

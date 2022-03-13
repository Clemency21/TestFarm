using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/ScenarioData", fileName = "ScenarioData")]
public class ScenarioData : ScriptableObject
{
    [SerializeField] private List<ScenaSata> _scenarioList;

    public List<ScenaSata> ScenariosList { get => _scenarioList; set => _scenarioList = value; }
}

[System.Serializable]
public class ScenaSata
{
    [SerializeField] private float  _intervalRow, _intervalCol;
    [SerializeField] private int _row, _col;

    public int Row { get => _row; set => _row = value; }
    public int Col { get => _col; set => _col = value; }
    public float IntervalRow { get => _intervalRow; set => _intervalRow = value; }
    public float IntervalCol { get => _intervalCol; set => _intervalCol = value; }
}

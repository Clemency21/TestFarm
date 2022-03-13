using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaleWheat : MonoBehaviour
{
    [SerializeField] private GameObject _prafabStack, _prefabCoin, _canvas, _targetCoin, _spawnCoin;
    [SerializeField] private Transform _targetTransform;
    [SerializeField] private PointsControl _pointsControl;
    [SerializeField] private ControlAnimation _controlAnimation;
    [SerializeField] private float _delaySpawn;
    public int _stackPrice;

    private Transform _backpackTransform;
    private GameObject _backpack;
    private int _currentCoins;

    public void SearchBackpack ()
    {
        _backpack = GameObject.FindGameObjectWithTag("Backpack");
        _backpackTransform = _backpack.transform;
        StartCoroutine(StackGenerator());
    }

    private IEnumerator StackGenerator ()                // создание стогов 
    {
        while (true)
        {
            yield return new WaitForSeconds(_delaySpawn);
            GameObject stack = Instantiate(_prafabStack, _backpackTransform.position, Quaternion.identity);
            stack.GetComponent<HayBaleSale>().SetData(_targetTransform);

            Destroy(stack, 2);
            _pointsControl.AddItem(-1);
            if (_pointsControl.currentItem == 0)
            {
                _controlAnimation.changePermission = true;
                _currentCoins = _pointsControl._maxItem;
                StartCoroutine(CoinsGenerator());
                yield return null;
                break;
            }
         }
    }

    private IEnumerator CoinsGenerator ()              // создание монет
    {
        while (true)
        {
            yield return new WaitForSeconds(_delaySpawn * 2);
            GameObject coin = Instantiate(_prefabCoin, transform.position, Quaternion.identity);
            coin.transform.SetParent(_canvas.transform);
            coin.transform.localPosition = _spawnCoin.transform.localPosition;
            coin.GetComponent<CoinMove>().SetData(_targetCoin.transform);
            _currentCoins -= 1;
            if(_currentCoins == 0)
            {
                yield return null;
                break;
            }
        }
    }
}

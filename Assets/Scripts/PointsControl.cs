using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsControl : MonoBehaviour
{
    [SerializeField] private Text _textAllScore, _textHayBale;
    [SerializeField] private ControlBackpack _controlBackpack;
    [SerializeField] private Animation _currentAnimation, _coinAnimation;
    [SerializeField] private SaleWheat _saleWheat;
    [SerializeField] private GameObject _fuulText, _canvas;
    public int _maxItem;
    public int currentItem;
    public int allScore;
    private int _targetScore;
    private bool _coinCounting;

    void Start()
    {
        StartNewGame();
    }

    public void StartNewGame ()
    {
        allScore = 0;
        _targetScore = 0;
        ResetCurrentItem();
        ShowPoints();
    }

    public void ResetCurrentItem ()
    {
        currentItem = 0;
        ShowItem();
        _controlBackpack.SetScale(currentItem);
    }

     public void AddPoints ()
    {
        _coinAnimation.Play();
        _targetScore += _saleWheat._stackPrice;           // целевая сумма

        if(!_coinCounting)
        {
            StartCoroutine(AddingCoins());
            _coinCounting = true;
        }
    }

    private void ShowPoints ()
    {
        _textAllScore.text = allScore.ToString();
    }


    public void AddItem(int num)
    {
        currentItem += num;
        _controlBackpack.SetScale(currentItem);
        ShowItem();

        if(currentItem == _maxItem)
        {
            GameObject full = Instantiate(_fuulText, transform.position, Quaternion.identity, _canvas.transform);
            full.transform.localScale = new Vector3(1, 1, 1);
            full.transform.localPosition = Vector3.zero;
            Destroy(full, 1.5f);
        }

    }

    private void ShowItem()
    {
        _currentAnimation.Play();
        _textHayBale.text = currentItem.ToString() + "/" + _maxItem.ToString();
    }

    private IEnumerator AddingCoins ()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.05f);
            allScore += 1;
            if(allScore == _targetScore)
            {
                ShowPoints();
                _coinCounting = false;
                yield return null;
                break;
            }
            ShowPoints();
        }
    }
}

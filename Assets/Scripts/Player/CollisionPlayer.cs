using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionPlayer : MonoBehaviour
{
    [SerializeField] private ControlAnimation _controlAnimation;
    [SerializeField] private KnifeControl _knifeControl;
    [SerializeField] private PointsControl _pointsControl;
    [SerializeField] private SaleWheat _saleWheat;
    [SerializeField] private string _tagTrigger, _tagPoint;


    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(_tagTrigger) && _pointsControl.currentItem < _pointsControl._maxItem)
        {
            _controlAnimation.SetModePlayer(2);
            _controlAnimation.changePermission = false;
            StartCoroutine(ChangePermission());
            StartCoroutine(KnifeTurn_onDelay());            
        }
        if(other.CompareTag(_tagPoint) && _pointsControl.currentItem >= _pointsControl._maxItem && _controlAnimation.changePermission)
        {
            _controlAnimation.changePermission = false;
            _saleWheat.SearchBackpack();           
        }
    }

    private IEnumerator ChangePermission ()
    {
        yield return new WaitForSeconds(1.5f);
        _controlAnimation.changePermission = true;
        yield return null;
    }

    private IEnumerator KnifeTurn_onDelay ()
    {
        yield return new WaitForSeconds(0.5f);
        _knifeControl.KnifeSet(true);
        yield return null;
    }
}

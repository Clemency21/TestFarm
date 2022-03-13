using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _deltaPos;
    private Transform _targetTransform;

   public void SetData (Transform target)
    {
        _targetTransform = target;
        transform.localScale = new Vector3(1, 1, 1);
    }

    void FixedUpdate()
    {
        MoveCoin();
    }

    private void MoveCoin()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetTransform.position, _speed * Time.deltaTime);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AllGold"))
        {
            GameObject.Find("GameControl").GetComponent<PointsControl>().AddPoints();
            Destroy(this.gameObject);
        }
    }
}

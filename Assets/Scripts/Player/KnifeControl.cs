using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeControl : MonoBehaviour
{
    private GameObject _knife;

    void Start()
    {
        SearchKnife();
    }

    private void SearchKnife ()
    {
        _knife = GameObject.FindGameObjectWithTag("Spit");
        KnifeSet(false);
    }

    public void KnifeSet (bool set)
    {
        _knife.SetActive(set);
        if (set) StartCoroutine(DisablingKnife());
    }

    private IEnumerator DisablingKnife ()
    {
        yield return new WaitForSeconds(1.2f);
        _knife.SetActive(false);
        yield return null;
    }
}

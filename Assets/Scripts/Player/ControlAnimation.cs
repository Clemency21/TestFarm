using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    public bool changePermission;


    public void SetModePlayer (int mode)
    {
        SetTweenMode(mode);
    }

    private void SetTweenMode(int modeAnimation)
    {
        if (changePermission) _animator.SetInteger("ModePlayer", modeAnimation);
    }

    public void SetPermision (bool set)
    {
        changePermission = set;
    }

    public void SpeedAnimation (float speed)
    {
        _animator.SetFloat("SpeedPlayer", speed);
    }

}

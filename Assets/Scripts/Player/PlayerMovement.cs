using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speedPlayer, _speedRotatePlayer;
    [SerializeField]  private Transform _playerTransform, _targetTransform;
    [SerializeField] private CharacterController _controller;
    [SerializeField] private float _sizeTouchZone;
    [SerializeField] private ControlAnimation _controlAnimation;
    
    
    private float _indexSpeed;
    private Vector3 _targetVector;

    void FixedUpdate()
    {
        if (_controlAnimation.changePermission)
        {
            MovementPlayer();
            RotatePlayer();
            _targetTransform.position = _playerTransform.position;
        }
    }

    public void SpeedPlayer (Vector2 targetVector)
    {
        _indexSpeed = targetVector.magnitude / _sizeTouchZone;
        if (_indexSpeed > 1) _indexSpeed = 1;
        _targetVector = targetVector;
        _controlAnimation.SpeedAnimation(_indexSpeed);
    }

    private void MovementPlayer ()
    {
        float targetSpeedPlayer = _speedPlayer * _indexSpeed;
        Vector3 direct = _playerTransform.TransformDirection(Vector3.forward);
        _controller.SimpleMove(direct * targetSpeedPlayer);
    }

    private void RotatePlayer()
    {
        if (_targetVector.magnitude > 0.1f)
        {
            Vector3 _targetPoint = new Vector3(_playerTransform.position.x + _targetVector.x, 0, _playerTransform.position.z + _targetVector.y);
            Vector3 direction = (_targetPoint - _playerTransform.position).normalized;
            direction.y = 0f;
            _playerTransform.rotation = Quaternion.RotateTowards(_playerTransform.rotation, Quaternion.LookRotation(direction), _speedRotatePlayer);
        }
    }
}

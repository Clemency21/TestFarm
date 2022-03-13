using UnityEngine;
using UnityEngine.UI;

public class CreateStickCanvas : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private GameObject _stickObject;
    [SerializeField] private GameObject _canvas;
    [SerializeField] private Color32 _stickColor;
    [SerializeField] private ControlAnimation _controlAnimation;
    [SerializeField] private int _idleMode, _moveMode;

    private bool _presenceStick;
    private GameObject _createdStickObject;
    private RectTransform _canvasRectTransform;
    private Vector2 _mousePosition;
    private Vector3 _touchPosition;


    void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        _canvasRectTransform = _canvas.GetComponent<RectTransform>();
    }

    public void TouchingMotionPanel()
    {
        if (!_presenceStick)
        {
            _mousePosition = new Vector2((Input.mousePosition.x * _canvasRectTransform.sizeDelta.x) / Screen.width, (Input.mousePosition.y * _canvasRectTransform.sizeDelta.y) / Screen.height);
            _createdStickObject = Instantiate(_stickObject, transform.position, Quaternion.identity, _canvasRectTransform);
            _createdStickObject.GetComponent<Image>().color = _stickColor;
            _createdStickObject.transform.localPosition = new Vector2(-(_canvasRectTransform.sizeDelta.x / 2 - _mousePosition.x), -(_canvasRectTransform.sizeDelta.y / 2 - _mousePosition.y));
            _presenceStick = true;
        }
    }

    public void ReleasingMotionPanel()
    {
        if (_createdStickObject != null) Destroy(_createdStickObject);
    }

    public void Pointer_Down()
    {
        _touchPosition = Input.mousePosition;
        TouchingMotionPanel();
    }
    public void Pointer_Up()
    {
        _touchPosition = Vector3.zero;
        ReleasingMotionPanel();
        _playerMovement.SpeedPlayer(Vector3.zero);
        _presenceStick = false;
        _controlAnimation.SetModePlayer(_idleMode);
    }

    public void Pointer_Drag()
    {
        _playerMovement.SpeedPlayer(Input.mousePosition - _touchPosition);
        _controlAnimation.SetModePlayer(_moveMode);
    }
}

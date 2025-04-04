using DG.Tweening;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
  public static TargetManager Instance;

  [Header("References")]
  [SerializeField] private ArrowManager _arrowManager;

  [Header("Settings")]
  [SerializeField] private float _targetSpeed;
  private Transform _targetTransform;
  private TargetState _currentState = TargetState.Rigth;
  private bool mirror;
  public enum TargetState
  {
    Rigth, Left, Pause
  }
  public void ChangeState(TargetState newState)
  {
    if(_currentState != newState) _currentState = newState;
  }

  public TargetState GetTargetState()
  {
    return _currentState;
  }
  private void Awake() 
  {
    DOTween.SetTweensCapacity(7000, 2500);
    Instance = this;  
    _targetTransform = GetComponent<Transform>();
  }
  private void Update() 
  {
      var currentState = GetTargetState();  
      var currentGameState = GameManager.Instance.GetGameState();
      if(currentGameState == GameManager.GameState.GameOver || currentGameState == GameManager.GameState.Pause)
      {
        ChangeState(TargetState.Pause);
      } 
      switch (currentState)
        {
          case TargetState.Rigth:
            _targetTransform.DORotate(new Vector3(0f, 0f, 360f), _targetSpeed, RotateMode.LocalAxisAdd);
            break;
          case TargetState.Left:
            _targetTransform.DORotate(new Vector3(0f, 0f, -360f), _targetSpeed, RotateMode.LocalAxisAdd);
            break;
          case TargetState.Pause:
            _targetTransform.DORotate(new Vector3(0f, 0f, 0f), 0.1f, RotateMode.LocalAxisAdd);
            break;
        }
         
  }
  private void OnCollisionEnter2D(Collision2D collision)
  {
     if(collision.gameObject.CompareTag("Arrow"))
     {
       collision.transform.SetParent(transform);
       _arrowManager.DecreaseArrow();
        if(mirror)
        {
           ChangeState(TargetState.Rigth);
           mirror = false;
        }
        else if(!mirror)
        {
          ChangeState(TargetState.Left);
          mirror = true;
        }
     }
  }

  public void SetTargetSpeed(float newSpeed)
  {
    _targetSpeed = newSpeed;
  }
}

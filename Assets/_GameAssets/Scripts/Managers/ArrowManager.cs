using TMPro;
using UnityEngine;
public class ArrowManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private GameObject _arrow;
    [SerializeField] private TMP_Text _arrowAmountText;
    [SerializeField] private RectTransform _tapToClickText;

    [Header("Settings")]
    [SerializeField] private float _arrowSpeed;
    [SerializeField] private int _arrowAmount;
    [SerializeField] private float _coolDown;
    [SerializeField] private GameObject[] arrowList;
    private int _currentAmount;
    private float _currentCooldown;
    private int border;

    private void Awake() 
    {
        _currentAmount = _arrowAmount;

    }
    private void Update() 
    {
       
        _arrowAmountText.text = _currentAmount.ToString();
        var currentState = GameManager.Instance.GetGameState();

        if(currentState != GameManager.GameState.GameOver && currentState != GameManager.GameState.Pause)
        {
            _currentCooldown -= Time.deltaTime;

            if(_currentCooldown <= 0)
            {
                 CreateArrow();  
            }
            
        }
         
    }
    private void CreateArrow()
    {
        if(Input.GetMouseButtonDown(0) && _currentAmount > 0f)
        {
            _currentCooldown = _coolDown;

            _tapToClickText.gameObject.SetActive(false);

            GameObject arrow = Instantiate(_arrow, _spawnPoint.position, Quaternion.identity);
            
            arrowList[_arrowAmount - (_currentAmount)] = arrow;

            Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();
            AudioManager.Instance.Play(SoundType.ArrowSound);
            var currentState = GameManager.Instance.GetGameState();

            if(currentState != GameManager.GameState.Pause && currentState != GameManager.GameState.GameOver)
            {
              rb.linearVelocity = rb.transform.up * _arrowSpeed;
            }
        }
        if(_currentAmount <= 0f && EnemyManager.Instance.GetCurrentEnemy() <= 0)
        {
            if(border == 0)
            {
                //GameWin
                
                GameManager.Instance.GameWin();
                border++;
            }
        }
        if(_currentAmount <= 0f && EnemyManager.Instance.GetCurrentEnemy() > 0)
        {
            // GameLose
             GameManager.Instance.GameLose();
        }
    }

    public void DecreaseArrow()
    {
       _currentAmount--;
    }

    public GameObject[] GetArrowList()
    {
        return arrowList;
    }

    public float GetArrowSpeed()
    {
        return _arrowSpeed;
    }

    public void SetArrowAmount(int newAmount)
    {
        _arrowAmount = newAmount;
        _currentAmount = _arrowAmount;
    }
    public void SetArrowSpeed(float arrowSpeed)
    {
        _arrowSpeed = arrowSpeed;
    }

    public void BorderReset()
    {
        border = 0;
    }
}

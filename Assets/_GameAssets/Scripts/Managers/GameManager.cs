using UnityEngine;
using DG.Tweening;
using TMPro;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private GameState _currentState = GameState.Play;

    public enum GameState
    {
        Play, Pause, GameOver
    }

    public void ChangeState(GameState newState)
    {
        if(_currentState != newState) _currentState = newState;
    }

    public GameState GetGameState()
    {
        return _currentState;
    }

    [Header("References")]

    [SerializeField] private ArrowManager _arrowManager;
    [SerializeField] private LevelManager _levelManager;
    [SerializeField] private TargetManager _targetManager;
    [SerializeField] private EnemyManager _enemyManager;
    [SerializeField] private BlockManager _blockManager;
    [SerializeField] private GameObject _arrowAnim;
    [SerializeField] private RectTransform _tapToClickText;
    [SerializeField] private RectTransform _settingButton;
    [SerializeField] private RectTransform _currentLevelGameobject;
    [SerializeField] private TMP_Text _currentLevelText;
    [SerializeField] private TMP_Text _settingCurrentLevelText;


    private void Awake() 
    {
        Instance = this;

        var loadLevel = PlayerPrefs.GetInt("PathOfStart");

        if(loadLevel == 0)// MainMenu
        {
            _levelManager.SetCurrentLevel(PlayerPrefs.GetInt(Conts.Prefs.GLOBAL_LEVEL));
            _levelManager.SetLevel();
        }
        else if(loadLevel == 1)// Levels
        {
            _levelManager.SetCurrentLevel(PlayerPrefs.GetInt("levels"));
            _levelManager.SetLevel();
        }
    }

    public void GameWin()
    {
        GameManager.Instance.ChangeState(GameManager.GameState.GameOver);
        TargetManager.Instance.ChangeState(TargetManager.TargetState.Pause);
        
        var arrows = _arrowManager.GetArrowList();
        var blocks = BlockManager.Instance.GetBlockList();

        Camera.main.backgroundColor = Color.green;

        _arrowAnim.SetActive(false);

        _settingButton.DOScale(0f, 0.1f).SetEase(Ease.InBack);
        _currentLevelGameobject.DOScale(0f, 0.1f).SetEase(Ease.InBack);

        WinPopup.Instance.OpenWinPopup();

        foreach (GameObject e in blocks)
        {
            if(e != null)
            {
                e.SetActive(false);
            }
        }
        foreach(GameObject e in arrows)
        {
            if(e != null)
            {
               e.gameObject.GetComponent<Collider2D>().isTrigger = true;
            }
        }
        foreach(GameObject e in arrows)
        {
            if(e != null)
            {   
                e.gameObject.transform.DOScaleX(5, 0.5f);
                e.gameObject.transform.DOScaleY(100, 0.5f);
            }
        }
    }

    public void GameLose()
    {
        GameManager.Instance.ChangeState(GameManager.GameState.GameOver);
        TargetManager.Instance.ChangeState(TargetManager.TargetState.Pause);
        var enemys = EnemyManager.Instance.GetEnemyList();
        foreach(GameObject e in enemys)
        {
            if( e != null)
            {
                e.gameObject.GetComponent<Animator>().enabled = false;
            }
        }
        Camera.main.backgroundColor = Color.red;
        _settingButton.DOScale(0f, 0.1f).SetEase(Ease.InBack);
        _currentLevelGameobject.DOScale(0f, 0.1f).SetEase(Ease.InBack);
        _arrowAnim.SetActive(false);

        LosePopup.Instance.OpenLosePopup();
    }

    public void ClearGame(int arrowAmount, float arrowSpeed, float targetSpeed, TargetManager.TargetState targetState = TargetManager.TargetState.Rigth, GameManager.GameState gameState = GameState.Play)
    {
        var arrows = _arrowManager.GetArrowList();

        foreach(GameObject e in arrows)
        {
            if(e != null)
            {
                Destroy(e);
            }
        }
        
        var blocks = _blockManager.GetBlockList();

        foreach (GameObject e in blocks)
        {
            if(e != null)
            {
                e.SetActive(false);
            }
        }

        var enemys = _enemyManager.GetEnemyList();

        foreach (GameObject e in enemys)
        {
            if(e != null)
            {
                e.SetActive(false);
                e.gameObject.GetComponent<Animator>().enabled = true;
                if(e.TryGetComponent<IResetborder>(out IResetborder a))
                {
                    a.ResetBorder();
                }
            }
        }
        
        _enemyManager.ResetCurrentEnemy();

        Camera.main.backgroundColor = Color.white;


        _arrowAnim.SetActive(true);

        _currentLevelText.text = _levelManager.GetCurrentLevel().ToString();
        _settingCurrentLevelText.text = _levelManager.GetCurrentLevel().ToString();

        _arrowManager.BorderReset();
        _arrowManager.SetArrowAmount(arrowAmount);
        _arrowManager.SetArrowSpeed(arrowSpeed);

        _targetManager.SetTargetSpeed(targetSpeed);
        _targetManager.ChangeState(targetState);

        _settingButton.DOScale(1f, 0.1f).SetEase(Ease.InBack);
        _currentLevelGameobject .DOScale(1f, 0.1f).SetEase(Ease.InBack);

        ChangeState(gameState);
        
        if(WinPopup.Instance.transform.localScale == new Vector3(1f, 1f, 1f))
        {
            WinPopup.Instance.CloseWinPopup();
        }
        else if(LosePopup.Instance.transform.localScale == new Vector3(1f, 1f, 1f))
        {
            LosePopup.Instance.CloseLosePopup();
        }
        else return;
    }

}

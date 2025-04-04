using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using MaskTransitions;
public class SettingsUI : MonoBehaviour
{
   [Header("Buttons")]
   [SerializeField] private Button _mainMenuButton;
   [SerializeField] private Button _quitButton;
   [SerializeField] private Button _exitButton;
   [SerializeField] private Button _settingButton;
   [SerializeField] private Button _musicButton;
   [SerializeField] private Button _soundButton;

   [Header("Sprites")]
   [SerializeField] private Sprite _musicActiveSprite;
   [SerializeField] private Sprite _musicPassiveSprite;
   [SerializeField] private Sprite _soundActiveSprite;
   [SerializeField] private Sprite _soundPassiveprite;

   [Header("Other References")]
   [SerializeField] private RectTransform _settingsUI;
   [SerializeField] private ArrowManager _arrowManager;
   [SerializeField] private RectTransform _currentLevel;

   private bool _isSoundActive, _isMusicActive;
   private void Awake() 
   {
        _mainMenuButton.onClick.AddListener(MainMenuButtonClicked); 
        _quitButton.onClick.AddListener(QuitButtonClicked); 
        _settingButton.onClick.AddListener(SettingsButtonClicked); 
        _exitButton.onClick.AddListener(ExitButtonClicked); 
        _musicButton.onClick.AddListener(MusicButtonClicked); 
        _soundButton.onClick.AddListener(SoundButtonClicked); 
   }

    private void SoundButtonClicked()
    {
        AudioManager.Instance.Play(SoundType.ButtonClickSound);

        if(_isSoundActive)
        {
            _isSoundActive = false;
            _soundButton.image.sprite = _soundActiveSprite;
            AudioManager.Instance.SetSoundEffectsMute(false);
        }
        else if(!_isSoundActive)
        {
            _isSoundActive = true;
            _soundButton.image.sprite = _soundPassiveprite;
            AudioManager.Instance.SetSoundEffectsMute(true);
        }
    }

    private void MusicButtonClicked()
    {
        AudioManager.Instance.Play(SoundType.ButtonClickSound);

        if(_isMusicActive)
        {
            _isMusicActive = false;
            _musicButton.image.sprite = _musicActiveSprite;
        }
        else if(!_isMusicActive)
        {
            _isMusicActive = true;
            _musicButton.image.sprite = _musicPassiveSprite;
        }
    }

    private void ExitButtonClicked()
    {
        AudioManager.Instance.Play(SoundType.ButtonClickSound);

        var arrows = _arrowManager.GetArrowList();
        {
            foreach (GameObject e in arrows)
            {
                if(e != null)
                {
                   if(e.gameObject.GetComponent<Rigidbody2D>().linearVelocity == Vector2.zero)
                   {        
                       e.gameObject.GetComponent<Rigidbody2D>().linearVelocity = e.transform.up * _arrowManager.GetArrowSpeed();
                   }
                }
            }
        }
        GameManager.Instance.ChangeState(GameManager.GameState.Play);
        TargetManager.Instance.ChangeState(TargetManager.TargetState.Rigth);
        _settingsUI.DOScale(0f, 0.5f).SetEase(Ease.InBack);
        _settingButton.GetComponent<RectTransform>().DOScale(1f, 0.3f).SetEase(Ease.OutBack);
        _currentLevel.DOScale(1f, 0.3f).SetEase(Ease.OutExpo);
    }

    private void SettingsButtonClicked()
    {
        AudioManager.Instance.Play(SoundType.ButtonClickSound);

        var arrows = _arrowManager.GetArrowList();
        foreach(GameObject e in arrows)
        {
            if(e != null)
            {
                e.gameObject.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
            }
        }
        
        GameManager.Instance.ChangeState(GameManager.GameState.Pause);
        TargetManager.Instance.ChangeState(TargetManager.TargetState.Pause);
        _settingsUI.DOScale(1f, 0.5f).SetEase(Ease.OutBack);
        _settingButton.GetComponent<RectTransform>().DOScale(0f, 0.3f).SetEase(Ease.InBack);
        _currentLevel.DOScale(0f, 0.3f).SetEase(Ease.InBack); 
    }

    private void QuitButtonClicked()
    {
        AudioManager.Instance.Play(SoundType.ButtonClickSound);

        Application.Quit();
    }

    private void MainMenuButtonClicked()
    {
        AudioManager.Instance.Play(SoundType.TransitionSound);

        TransitionManager.Instance.LoadLevel("MainMenuScene");
    }
}

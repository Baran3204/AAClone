using UnityEngine;

public class LevelManager : MonoBehaviour
{
   public static LevelManager Instance;

   [Header("Manager References")]

   [SerializeField] private ArrowManager _arrowManager; // Arrow; speed, amount, list
   [SerializeField] private TargetManager _targetManager; // Target; speed, state
   [SerializeField] private GameManager _gameManager; // Game; state, clearGame
   [SerializeField] private BlockManager _blockManager; // Block; amount, list
   [SerializeField] private EnemyManager _enemyManager; // Enemy; amount, list

   [Header("Default Settings")]
   [SerializeField] private int _defaultArrowAmount;
   [SerializeField] private float _defaultArrowSpeed;
   [SerializeField] private float _defaultTargetSpeed;
   [SerializeField] private TargetManager.TargetState _defaultTargetState;
   [SerializeField] private GameManager.GameState _defaultGameState;
   private int _currentLevel = 1;
   private void Awake() 
   {
      Instance = this;
   }

   #region LEVELS
   public void SetLevel()
   {
     switch(_currentLevel)
     {
       case 1:
       _gameManager.ClearGame(_defaultArrowAmount, _defaultArrowSpeed, _defaultTargetSpeed);
       break;
       case 2:
       _gameManager.ClearGame(10, _defaultArrowSpeed, _defaultTargetSpeed);
       break;
       case 3:
       _gameManager.ClearGame(15, _defaultArrowSpeed, _defaultTargetSpeed);
       break;
       case 4:
       _gameManager.ClearGame(10, _defaultArrowSpeed, 15);
       break;
       case 5:
       _gameManager.ClearGame(5, _defaultArrowSpeed, 25);
       break;
       case 6:
       _gameManager.ClearGame(10, 25, _defaultTargetSpeed);
       break;
       case 7:
       _gameManager.ClearGame(5, 10, _defaultTargetSpeed);
       break;
       case 8:
       _gameManager.ClearGame(10, 25, 15);
       break;
       case 9:
       _gameManager.ClearGame(3, 10, 25);
       break;
       case 10:
       _gameManager.ClearGame(15, 30, 25);
       break;
       case 11:
       _gameManager.ClearGame(5, 30, 15);
       break;
       case 12:
       _gameManager.ClearGame(5, 15, 15);
       break;
       case 13:
       _gameManager.ClearGame(_defaultArrowAmount, _defaultArrowSpeed, _defaultTargetSpeed);
       _blockManager.SetBlocks(true, false, false, false, true, false, false, false);
       break;
       case 14:
       _gameManager.ClearGame(_defaultArrowAmount, _defaultArrowSpeed, _defaultTargetSpeed);
       _blockManager.SetBlocks(false, false, true, false, false, false, true, false);
       break;
       case 15:
       _gameManager.ClearGame(10, _defaultArrowSpeed, _defaultTargetSpeed);
       _blockManager.SetBlocks(true, false, true, false, true, false, true, false);
       break;
       case 16:
       _gameManager.ClearGame(10, 25, _defaultTargetSpeed);
       _blockManager.SetBlocks(true, false, true, false, true, false, true, false);
       break;
       case 17:
       _gameManager.ClearGame(10, _defaultArrowSpeed, _defaultTargetSpeed);
       _blockManager.SetBlocks(false, true, false, true, false, true, false, true);
       break;
       case 18:
        _gameManager.ClearGame(12, _defaultArrowSpeed, _defaultTargetSpeed);
       _blockManager.SetBlocks(true, true, true, true, true, true, true, true);
       break;
       case 19:
       _gameManager.ClearGame(10, 25, 25);
       _blockManager.SetBlocks(true, false, true, false, true, false, true, false);
       break;
       case 20:
       _gameManager.ClearGame(5, _defaultArrowSpeed, 15);
       _blockManager.SetBlocks(true, false, true, false, true, false, true, false);
       break;
       case 21:
       _gameManager.ClearGame(10, 25, 25);
       _blockManager.SetBlocks(true, false, true, false, true, false, true, false);
       break;
       case 22:
       _gameManager.ClearGame(8, 30, 10);
       _blockManager.SetBlocks(true, true, true, true, true, true, true, true);
       break;
       case 23:
       _gameManager.ClearGame(10, _defaultArrowSpeed, _defaultTargetSpeed);
       _blockManager.SetBlocks(true, true, false, true, true, true, false, true);
       break;
       case 24:
        _gameManager.ClearGame(15, 30, 10);
       _blockManager.SetBlocks(false, true, true, false, false, true, true, false);
       break;
       case 25:
       _gameManager.ClearGame(_defaultArrowAmount, _defaultArrowSpeed, _defaultTargetSpeed);
       _enemyManager.SetEnemys(true, false, false, false, true, false, false, false);
       break;
       case 26:
       _gameManager.ClearGame(_defaultArrowAmount, _defaultArrowSpeed, 15);
       _enemyManager.SetEnemys(false, false, true, false, false, false, true, false);
       break;
       case 27:
        _gameManager.ClearGame(10, _defaultArrowSpeed, _defaultTargetSpeed);
        _enemyManager.SetEnemys(true, false, true, false, true, false, true, false);
       break;
       case 28:
        _gameManager.ClearGame(10, 30, 25);
        _enemyManager.SetEnemys(true, false, true, false, true, false, true, false);
       break;
       case 29:
       _gameManager.ClearGame(_defaultArrowAmount, _defaultArrowSpeed, _defaultTargetSpeed);
       _blockManager.SetBlocks(true, false, false, false, true, false, false, false);
       _enemyManager.SetEnemys(false, false, true, false, false, false, true, false);
       break;
       case 30:
       _gameManager.ClearGame(10, _defaultArrowSpeed, _defaultTargetSpeed);
       _blockManager.SetBlocks(true, false, true, false, true, false, true, false);
       _enemyManager.SetEnemys(false, true, false, true, false, true, false, true);
       break;
       case 31:
        _gameManager.ClearGame(4, 25, 15);
       _blockManager.SetBlocks(true, false, true, false, true, false, true, false);
       _enemyManager.SetEnemys(false, true, false, true, false, true, false, true);
       break;
       case 32:
       _gameManager.ClearGame(10, _defaultArrowSpeed, _defaultTargetSpeed);
       _blockManager.SetBlocks(false, true, false, true, false, true, false, true);
       _enemyManager.SetEnemys(true, false, true, false, true, false, true, false);
       break;
       case 33:
       _gameManager.ClearGame(4, _defaultArrowSpeed, _defaultTargetSpeed);
       _blockManager.SetBlocks(false, true, false, true, false, true, false, true);
       _enemyManager.SetEnemys(true, false, true, false, true, false, true, false);
       break;
       case 34:
       _gameManager.ClearGame(10, 25, 15);
       _blockManager.SetBlocks(false, true, true, true, false, true, true, true);
       _enemyManager.SetEnemys(true, false, false, false, true, false, false, false);
       break;
       case 35:
       _gameManager.ClearGame(10, 25, _defaultTargetSpeed);
       _enemyManager.SetEnemys(true, true, true, true, true, true, true, true);
       break;
       case 36: // final
       _gameManager.ClearGame(15, _defaultArrowSpeed, _defaultTargetSpeed);
       _blockManager.SetBlocks(true, false, true, false, true, false, true, false);
       _enemyManager.SetEnemys(false, true, false, true, false, true, false, true); 
       break;
     }
   }

   #endregion

   public void UpdateNextCurrentLevel()
   {
     _currentLevel++;
     if(PlayerPrefs.GetInt(Conts.Prefs.GLOBAL_LEVEL) < _currentLevel)
     { 
        PlayerPrefs.SetInt(Conts.Prefs.GLOBAL_LEVEL, _currentLevel);
     }
   }
   public int GetCurrentLevel()
   {
    return _currentLevel;
   }
   public void SetCurrentLevel(int level)
   {
      _currentLevel = level;
   }
}

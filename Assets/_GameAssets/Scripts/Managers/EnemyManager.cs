using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance;

    [Header("References")]
    [SerializeField] private GameObject[] _enemyList;
    private int _currentEnemy;
    private void Awake() 
    {
        Instance = this;    
    }

    public void SetEnemys(bool enemy1, bool enemy2, bool enemy3, bool enemy4, bool enemy5, bool enemy6, bool enemy7, bool enemy8)
    {

     bool[] boolList = new bool[_enemyList.Length];

     boolList[0] = enemy1;
     boolList[1] = enemy2;
     boolList[2] = enemy3;
     boolList[3] = enemy4;
     boolList[4] = enemy5;
     boolList[5] = enemy6;
     boolList[6] = enemy7;
     boolList[7] = enemy8;
    

    for (int i = 0; i < boolList.Length; i++)
    {
        if(boolList[i]) 
        {
            _enemyList[i].SetActive(true);
            _currentEnemy++;
        }
        else
          _enemyList[i].SetActive(false);
    }

    }
    public GameObject[] GetEnemyList()
    {
        return _enemyList;
    }

    public void ResetCurrentEnemy()
    {
        _currentEnemy = 0;
    }
    public void DecreaseCurrentEnemy()
    {
        _currentEnemy--;
    }
    public int GetCurrentEnemy()
    {
        return _currentEnemy;
    }
}

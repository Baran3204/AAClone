using UnityEngine;

public class BlockManager : MonoBehaviour
{
    public static BlockManager Instance;

    [Header("References")]
    [SerializeField] private GameObject[] _blockList;
    
    private void Awake() 
    {
        Instance = this; 
        foreach (GameObject e in _blockList)
        {
            if(e != null)
            {
                e.SetActive(false);
            }
        }   
    }
    public void SetBlocks(bool block1, bool block2, bool block3, bool block4, bool block5, bool block6, bool block7, bool block8)
    {

     bool[] boolList = new bool[_blockList.Length];

     boolList[0] = block1;
     boolList[1] = block2;
     boolList[2] = block3;
     boolList[3] = block4;
     boolList[4] = block5;
     boolList[5] = block6;
     boolList[6] = block7;
     boolList[7] = block8;

    for (int i = 0; i < boolList.Length; i++)
    {
        if(boolList[i]) { _blockList[i].SetActive(true); } else _blockList[i].SetActive(false);
    }

    }

    public GameObject[] GetBlockList()
    {
        return _blockList;
    }

}

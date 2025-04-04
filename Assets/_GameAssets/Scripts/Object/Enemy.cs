using UnityEngine;

public class Enemy : MonoBehaviour, IResetborder
{
    private int border = 0;
    private void Update() 
    {
        var currentState = TargetManager.Instance.GetTargetState();

        var newValue = currentState switch
        {
            _ when currentState == TargetManager.TargetState.Rigth => true,
            _ when currentState == TargetManager.TargetState.Left => false,
            _ => true
        };

        GetComponent<SpriteRenderer>().flipX = newValue;    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Arrow"))
        {
            gameObject.SetActive(false);
            if(border == 0)
            {
                EnemyManager.Instance.DecreaseCurrentEnemy();
                border++;
            }
            
        }
    }

    public void ResetBorder()
    {
        border = 0;
    }
}

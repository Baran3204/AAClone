using UnityEngine;

public class Arrow : MonoBehaviour
{

    private Rigidbody2D _arrowRigidbody;
    private void Awake() 
    { 
        _arrowRigidbody = GetComponent<Rigidbody2D>();    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Target"))
        {
            _arrowRigidbody.constraints = RigidbodyConstraints2D.FreezePosition;
            _arrowRigidbody.freezeRotation = true;
        }
        else if(collision.gameObject.CompareTag("Arrow") || collision.gameObject.CompareTag("Block"))
        {
            // Game Over
            
            _arrowRigidbody.constraints = RigidbodyConstraints2D.FreezePosition;
            _arrowRigidbody.freezeRotation = true;

            GameManager.Instance.GameLose();                      
        }
    }
}

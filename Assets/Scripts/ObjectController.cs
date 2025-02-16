using UnityEngine;

public class ObjectController : MonoBehaviour
{
    private Vector2 _velocity;
    public Rigidbody2D Rigidbody { get; private set; }

    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.X))){
            Rigidbody.AddForce(new Vector2(0, 50f), ForceMode2D.Impulse);
        }

        _velocity.x = Input.GetAxis("Horizontal") * 25f;
        Rigidbody.linearVelocityX = _velocity.x;
    }
}

using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float speed;

    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    void Start()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

 
    void Update()
    {
        var input = Input.GetAxisRaw("Horizontal");

        transform.Translate(Vector2.right * input * speed * Time.deltaTime);

        if (input > 0)
        {
            _spriteRenderer.flipX = false;
            _animator.SetBool("Run", true);
        }
        else if (input == 0)
        {
            _animator.SetBool("Run", false);
        }
        else if (input < 0)
        {
            _spriteRenderer.flipX = true;
            _animator.SetBool("Run", true);
        }
    }
}

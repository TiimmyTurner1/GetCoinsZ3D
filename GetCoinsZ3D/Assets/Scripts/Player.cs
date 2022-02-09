using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Rigidbody _rig;
    [SerializeField] private UI _ui;

    private bool _isGrounded;

    public int Score;
    
    private void Update()
    {
        float x = Input.GetAxis("Horizontal") * _moveSpeed;
        float z = Input.GetAxis("Vertical") * _moveSpeed;

        _rig.velocity = new Vector3(x, _rig.velocity.y, z);

        Vector3 velocity = _rig.velocity;
        velocity.y = 0;

        if(velocity.x != 0 || velocity.z != 0)
        {
            transform.forward = velocity;
        }

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded == true)
        {
            _isGrounded = false;
            _rig.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }

        if(transform.position.y < -10)
        {
            GameOver();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.contacts[0].normal == Vector3.up)
        {
            _isGrounded = true;
        }

        if (collision.gameObject.tag.Equals("MovingPlatform"))
        {
            transform.parent = collision.transform;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag.Equals("MovingPlatform"))
        {
            transform.parent = null;
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void AddScore(int amount)
    {
        Score += amount;
        _ui.SetScoreText(Score);
    }
}

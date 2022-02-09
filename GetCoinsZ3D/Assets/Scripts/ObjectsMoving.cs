using UnityEngine;

public class ObjectsMoving : MonoBehaviour
{

    [SerializeField] private float _moveSpeed;
    [SerializeField] private Vector3 _moveDirection;
    [SerializeField] private float _moveDistance;

    private Vector3 _startPos;
    private bool _movingToStart;


    private void Start()
    {
        _startPos = transform.position;
    }

    
    private void Update()
    {
        if (_movingToStart)
        {
            transform.position = Vector3.MoveTowards(transform.position, _startPos, _moveSpeed * Time.deltaTime);

            if(transform.position == _startPos)
            {
                _movingToStart = false;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, _startPos + (_moveDirection * _moveDistance), _moveSpeed * Time.deltaTime);

            if(transform.position == _startPos + (_moveDirection * _moveDistance))
            {
                _movingToStart = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().GameOver();
        }
    }
}

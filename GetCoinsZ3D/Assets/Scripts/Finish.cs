using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    [SerializeField] private string _nextSceneName;
    [SerializeField] private bool _lastLevel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(_lastLevel == true)
            {
                Debug.Log("You win");
            }
            else
            {
                Debug.Log("Next Level");
                //SceneManager.LoadScene(_nextSceneName);
            }
        }
    }
}

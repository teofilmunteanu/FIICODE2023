using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartTriggerRoom3 : MonoBehaviour
{
    private Scene scene;

    [SerializeField]
    GameObject Player;

    void Start()
    {
        scene = SceneManager.GetActiveScene();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Player && !Room3ButtonManager.Instance.gameFinished)
        {
            SceneManager.LoadScene(scene.name);
        }
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartTriggerRoom1 : MonoBehaviour
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
        if (collision.gameObject == Player)
        {
            SceneManager.LoadScene(scene.name);
        }
    }
}

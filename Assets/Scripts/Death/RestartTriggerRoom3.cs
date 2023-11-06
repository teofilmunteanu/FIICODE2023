using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartTriggerRoom3 : MonoBehaviour
{
    private Scene scene;
    [SerializeField]
    EnemyFollow enemyScript;

    [SerializeField]
    GameObject Player;

    void Start()
    {
        scene = SceneManager.GetActiveScene();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Player && !enemyScript.gameFinished)
        {
            SceneManager.LoadScene(scene.name);
        }
    }
}

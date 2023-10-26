using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartTrigger : MonoBehaviour
{
    private Scene scene;
    [SerializeField] EnemyFollow enemyScript;

    void Start()
    {
        scene = SceneManager.GetActiveScene();
    }


    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (!enemyScript.gameFinished)
        {
            SceneManager.LoadScene(scene.name);
        }
    }
}

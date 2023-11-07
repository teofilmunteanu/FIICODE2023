using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartTriggerRoom : MonoBehaviour
{
    private Scene scene;

    [SerializeField]
    GameObject Player;

    void Start()
    {
        scene = SceneManager.GetActiveScene();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.gameObject == Player)
        {
            SceneManager.LoadScene(scene.name);
        }
    }
}

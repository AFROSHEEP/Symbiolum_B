using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();

        if (Input.GetKeyDown(KeyCode.Alpha1))
            restart_scene();
    }

    private void OnEnable()
    {
        kill_player.restart += restart_scene;
    }

    private void OnDisable()
    {
        kill_player.restart -= restart_scene;
    }

    void restart_scene()
    {
        SceneManager.LoadScene("Main2");
    }
}

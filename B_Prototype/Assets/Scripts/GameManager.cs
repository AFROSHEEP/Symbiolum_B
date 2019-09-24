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

        if (Input.GetKeyDown(KeyCode.R))
            restart_scene();
    }

    public void restart_scene()
    {
        SceneManager.LoadScene("Main3");
    }

    public void load_scene(string name)
    {
        SceneManager.LoadScene(name);
    }
}

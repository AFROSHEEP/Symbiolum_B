using UnityEngine;
using UnityEngine.SceneManagement;

public class thorn_block : MonoBehaviour
{
    public GameObject mole;

    private void Update()
    {
        if (mole != null)
        {
            if (mole.GetComponentInChildren<mole_script>().skill_active)
                GetComponent<BoxCollider>().enabled = false;
            else
                GetComponent<BoxCollider>().enabled = true;
        }

        // else
        // kill_player
    }
}

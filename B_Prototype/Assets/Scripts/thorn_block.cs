using UnityEngine;
using UnityEngine.SceneManagement;

public class thorn_block : MonoBehaviour
{
    public GameObject mole;

    private void Update()
    {
        if (mole.transform.Find("Mole_model").GetComponentInChildren<mole_script>().skill_active)
            transform.Find("impassible cube").GetComponent<BoxCollider>().enabled = false;
        else
            transform.Find("impassible cube").GetComponent<BoxCollider>().enabled = false;

        // else
        // kill_player
    }
}

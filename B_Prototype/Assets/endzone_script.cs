using UnityEngine;

public class endzone_script : MonoBehaviour
{
    public GameManager GM;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            GM.GetComponent<GameManager>().load_scene("EndScreen");
    }
}

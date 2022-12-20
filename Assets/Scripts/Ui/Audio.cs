using UnityEngine;

public class Audio : MonoBehaviour
{
    private void Awake()
    {
        GameObject audio = GameObject.FindWithTag("Audio");

        if (audio != null)
        {
            Destroy(gameObject);
        }
        else
        {
            gameObject.tag = "Audio";
            DontDestroyOnLoad(this.gameObject);
        }
    }
}

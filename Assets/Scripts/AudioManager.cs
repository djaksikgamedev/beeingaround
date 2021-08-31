using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager AMInstance;

    private void Awake()
    {
        if (AMInstance != null && AMInstance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        AMInstance = this;
        DontDestroyOnLoad(this);
    }
}
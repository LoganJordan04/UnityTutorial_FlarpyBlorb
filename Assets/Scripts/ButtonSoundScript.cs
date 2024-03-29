using UnityEngine;

public class ButtonSoundScript : MonoBehaviour
{
    public AudioSource click;
    
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        click = GetComponent<AudioSource>();
    }

    public void PlayButtonSound()
    {
        click.Play();
    }
}

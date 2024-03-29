using UnityEngine;
using System.Collections;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;
    
    public GameObject wingUp;
    public GameObject wingDown;

    private AudioSource _audioSource;
    public AudioClip flap;
    
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag($"Logic").GetComponent<LogicScript>();
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetMouseButtonDown(0) 
            && birdIsAlive)
        {
            myRigidbody.velocity = Vector2.up * flapStrength;
            _audioSource.PlayOneShot(flap, 0.75F);
            StartCoroutine(WingFlap());
        }

        if (transform.position.y is <= 16 and >= -16) return;
        logic.GameOver();
        birdIsAlive = false;
    }

    private void OnCollisionEnter2D()
    {
        logic.GameOver();
        birdIsAlive = false;
    }

    private IEnumerator WingFlap()
    {
        wingUp.SetActive(false);
        wingDown.SetActive(true);
        yield return new WaitForSeconds(0.35f);
        wingDown.SetActive(false);
        wingUp.SetActive(true);
    }
}
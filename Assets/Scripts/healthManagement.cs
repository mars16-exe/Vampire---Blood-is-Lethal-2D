using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class healthManagement : MonoBehaviour
{
    [SerializeField] private int Health = 3;
    [SerializeField] private GameObject gameOverMenu;

    private movement movementScript;

    public Text Num_health;

    public CircleCollider2D circleCol;

    [Header("Sound Department")]
    public AudioSource soundEmitter;
    public AudioClip hitClip;
    public AudioClip drowningClip;
    public AudioClip jumpClip;
    
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        Num_health.text = "" + Health;
        gameOverMenu.SetActive(false);

        movementScript = GetComponent<movement>();

        circleCol = GetComponent<CircleCollider2D>();

        soundEmitter = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Num_health.text = "" + Health;

        HandleDeath();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            Health--;
            soundEmitter.PlayOneShot(hitClip);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("BloodBath"))
        {
            if(circleCol.IsTouching(collision))
            {
                movementScript.isMovementON = false;
                movementScript.Drowning();
                soundEmitter.PlayOneShot(drowningClip);
                StartCoroutine("StopGame");
            }
        }

        if(collision.gameObject.CompareTag("Health"))
        {
            Health++;
            Destroy(collision.gameObject);
            //pickupclip here
        }
    }

    public void HandleDeath()
    {
        if (Health == 0)
        {
            gameOverMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public IEnumerator StopGame()
    {
        yield return new WaitForSeconds(3f);
        gameOverMenu.SetActive(true);
        Time.timeScale = 0;
    }
}

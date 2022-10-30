using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Animator cameraAnim;
    public GameObject vampireLord;

    private AudioSource speaker;
    public AudioClip victoryClip;

    [Header("For Seeing Purposes Only")]
    [SerializeField] private movement movementScript;
    [SerializeField] private GameObject healthBar;

    [Header("Ending Scene")]
    public GameObject credits;
    public GameObject confetti;

    private void Awake()
    {
        Invoke("DieVampireLord", 11f);
        speaker = GetComponent<AudioSource>();
    }
    public void DieVampireLord()
    {
        Destroy(vampireLord);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            cameraAnim.SetTrigger("Ending");

            speaker.Stop();
            speaker.PlayOneShot(victoryClip);

            movementScript = collision.gameObject.GetComponent<movement>();
            movementScript.isMovementON = false;

            healthBar.SetActive(false);

            confetti.SetActive(true);

            Invoke("ShowCredits", 5f);
        }
    }

    private void ShowCredits()
    {
        credits.gameObject.SetActive(true);
    }
}

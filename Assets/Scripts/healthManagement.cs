using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthManagement : MonoBehaviour
{
    [SerializeField] private int Health = 3;
    [SerializeField] private GameObject gameOverMenu;

    private movement movementScript;

    public Text Num_health;

    public CircleCollider2D circleCol;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        Num_health.text = "" + Health;
        gameOverMenu.SetActive(false);

        movementScript = GetComponent<movement>();

        circleCol = GetComponent<CircleCollider2D>();
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
                StartCoroutine("StopGame");
            }
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

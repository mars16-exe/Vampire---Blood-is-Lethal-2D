using UnityEngine;

public class breakingPlatform : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            animator.SetTrigger("Break");
        }
    }

    public void GetWrecked()
    {
        Destroy(this.gameObject);
    }
}

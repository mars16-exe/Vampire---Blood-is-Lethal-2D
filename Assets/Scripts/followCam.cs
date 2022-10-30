using UnityEngine;

public class followCam : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private bool isEndingScene = false;
    public Vector3 offset;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void LateUpdate()
    {
        if(!isEndingScene)
        {
            transform.position = player.transform.position + offset;
        }
    }

    public void EndFollow()
    {
        isEndingScene = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject vampireLord;

    private void Awake()
    {
        Invoke("DieVampireLord", 11f);
    }
    public void DieVampireLord()
    {
        Destroy(vampireLord);
    }
}

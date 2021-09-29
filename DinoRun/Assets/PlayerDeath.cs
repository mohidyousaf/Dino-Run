using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] int chances=2;
    // Start is called before the first frame update
    void Start()
    {
        chances=2;
    }
    public int getChances()
    {
        return chances;
    }
    public void reduceChance()
    {
        chances--;
    }
}

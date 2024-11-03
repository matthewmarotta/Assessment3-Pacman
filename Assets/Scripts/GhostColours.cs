using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostColours : MonoBehaviour
{
    public Color ghostColor;
    private SpriteRenderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        rend.color = ghostColor;

    }

    // Update is called once per frame
    void Update()
    {
      
    }
}


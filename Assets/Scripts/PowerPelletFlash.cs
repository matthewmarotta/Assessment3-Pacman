using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPelletFlash : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Color flashColor = Color.white;
    public float flashTime = 0.1f;
  

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(Flashing());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Flashing()
    {
        Color originalColor = spriteRenderer.color;
        while (true)
        {
           
            spriteRenderer.color = flashColor;
            yield return new WaitForSeconds(flashTime);

            
            spriteRenderer.color = originalColor;
            yield return new WaitForSeconds(flashTime);
        }
    }
}

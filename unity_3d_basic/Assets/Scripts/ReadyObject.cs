using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyObject : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return new WaitForSeconds(3.3f);
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(1f);
        spriteRenderer.color = Color.yellow;
        yield return new WaitForSeconds(1f);
        spriteRenderer.color = Color.blue;

    }

 
}

using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class squareActorComponent : MonoBehaviour
{
    Vector2 newvector;
    SpriteRenderer spriteRenderer;
    Color[] colourArr;
    // Start is called before the first frame update
    void Start()
    {
        newvector = new Vector2(1, 0);
        spriteRenderer = GetComponent<SpriteRenderer>();
        colourArr = new Color[] {Color.blue, Color.gray, Color.green, Color.magenta };
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = newvector;
        for (int i = 0; i < colourArr.Length; i++)
        {
            
            spriteRenderer.color = colourArr[i];
            StartCoroutine(ChangeDelay());
        }

    }

    private IEnumerator ChangeDelay()
    {
        yield return new WaitForSeconds(3);
    }
}

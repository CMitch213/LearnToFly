using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBG : MonoBehaviour
{

    float startPos;
    float lengthOfSprite;
    public float AmountOfParallax;
    public Camera mainCam;

    // Start is called before the first frame update
    void Start()
    {
        //Getting the starting X position of sprite.
        startPos = transform.position.x;
        //Getting the length of the sprites.
        lengthOfSprite = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Position = mainCam.transform.position;
        float Temp = Position.x * (1 - AmountOfParallax);
        float Distance = Position.x * AmountOfParallax;

        Vector3 NewPosition = new Vector3(startPos + Distance, transform.position.y, transform.position.z);

        transform.position = NewPosition;

        if (Temp > startPos + (lengthOfSprite / 2))
        {
            startPos += lengthOfSprite;
        }
        else if (Temp < startPos - (lengthOfSprite / 2))
        {
            startPos -= lengthOfSprite;
        }
    }
}

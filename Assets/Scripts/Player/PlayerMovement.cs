using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

    DirectionP currentDir;
    Vector2 input;
    bool isMoving = false;
    Vector3 startPos;
    Vector3 endPos;
    float t;

    public Sprite northSprite;
    public Sprite eastSprite;
    public Sprite southSprite;
    public Sprite westSprite;

    public float walkSpeed = 3f;

    public bool isAllowedToMove = true;

    void Start()
    {
        isAllowedToMove = true;
    }

    void Update()
    {

        if (!isMoving && isAllowedToMove)
        {
            input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            if (Mathf.Abs(input.x) > Mathf.Abs(input.y))
                input.y = 0;
            else
                input.x = 0;

            if (input != Vector2.zero)
            {

                RaycastHit2D hit;
                hit = Physics2D.Raycast(transform.position, Vector2.left, 2f);
                Debug.DrawLine(transform.position, hit.point * 2f, Color.white);

                if (input.x < 0)
                {
                    
                    currentDir = DirectionP.West;
                    hit = Physics2D.Raycast(transform.position, Vector2.right, 2f);
                    
                }
                if (input.x > 0)
                {
                    currentDir = DirectionP.East;
                }
                if (input.y < 0)
                {
                    currentDir = DirectionP.South;
                }
                if (input.y > 0)
                {
                    currentDir = DirectionP.North;
                }

                


                switch (currentDir)
                {
                    case DirectionP.North:
                        gameObject.GetComponent<SpriteRenderer>().sprite = northSprite;
                        break;
                    case DirectionP.East:
                        gameObject.GetComponent<SpriteRenderer>().sprite = eastSprite;
                        break;
                    case DirectionP.South:
                        gameObject.GetComponent<SpriteRenderer>().sprite = southSprite;
                        break;
                    case DirectionP.West:
                        gameObject.GetComponent<SpriteRenderer>().sprite = westSprite;
                        break;
                }

                StartCoroutine(Move(transform));
            }

        }

    }

   
    public IEnumerator Move(Transform player)
    {
        isMoving = true;
        startPos = player.position;
        t = 0;

        endPos = new Vector3(startPos.x + System.Math.Sign(input.x), startPos.y + System.Math.Sign(input.y), startPos.z);

        while (t < 1f)
        {
            t += Time.deltaTime * walkSpeed;
            player.position = Vector3.Lerp(startPos, endPos, t);
            yield return null;
        }

        isMoving = false;
        yield return 0;
    }
}


enum DirectionP
{
    North,
    East,
    South,
    West
}
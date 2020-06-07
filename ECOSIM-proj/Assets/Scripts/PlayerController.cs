using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    private Vector2 targetPosition = new Vector2(8,7);
    [SerializeField] float moveSpeed = 3f; //[SerializeField] attribut privé modifiable ds l'inspector 
    Vector2 lastMove = new Vector2(1, -1);

    private Vector2 spriteSize;

    public LayerMask movementMask;  // Filter out everything not walkable
    public bool isBesaceOpen;


    void Start()
    {
        spriteSize = GetComponent<SpriteRenderer>().sprite.bounds.size;
       
    }

    // Update is called once per frame
    void Update()
    {
        // check if the besace is open
        isBesaceOpen = GetComponent<Farmer>().besace.gameObject.activeSelf;



        //Movement
        if (!isBesaceOpen)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                targetPosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
                RaycastHit2D hit = Physics2D.Raycast(targetPosition, Vector3.forward);
                //Debug.Log(hit.collider);
                if (hit.collider.gameObject.GetComponent<Tilemap>() == null)
                {
                    //Clic hors zone -> calcul du point le plus proche sur la map
                    Vector2 heading = (Vector2)transform.position - targetPosition;
                    var distance = heading.magnitude;
                    Vector2 direction = heading / distance;
                    /*
                    RaycastHit2D correctionHit = Physics2D.Raycast(targetPosition, direction, Mathf.Infinity, movementMask);
                    targetPosition = correctionHit.point;
                    
                                        //Correction de la position en fonction de la largeur du sprite
                                        if (targetPosition.x - transform.position.x < 0) targetPosition.x += spriteSize.x;
                                        else targetPosition.x -= spriteSize.x;
                                        if (targetPosition.y - transform.position.y < 0) targetPosition.y += spriteSize.y;
                                        else targetPosition.y -= spriteSize.y;*/
                }
                lastMove = targetPosition - (Vector2)transform.position;
            }
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, Time.deltaTime * moveSpeed);

            //Animation
            if (lastMove.x > 0) GetComponent<SpriteRenderer>().flipX = false;  // car sprite orienté vers la droite de base
            else GetComponent<SpriteRenderer>().flipX = true;

            if (targetPosition != (Vector2)transform.position) GetComponent<Animator>().SetBool("running", true);
            else GetComponent<Animator>().SetBool("running", false);

            if (targetPosition.y > transform.position.y) GetComponent<Animator>().SetBool("back", true);
            else GetComponent<Animator>().SetBool("back", false);
        }


    }




}


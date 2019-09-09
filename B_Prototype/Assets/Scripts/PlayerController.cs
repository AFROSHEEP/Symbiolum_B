using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController characterController;

    private float speed;
    public float wisp_speed;
    public float stone_speed;
    public float jumpSpeed;
    public float gravity;
    public float thrust;
    public float rotation_speed;
    //private int jumps = 0;

    private Vector3 moveDirection = Vector3.zero;
    private Vector3 playerScale;

    private bool range_stone;
    private bool is_hosted;
    private bool can_jump = true;
    private bool can_stone_skill;

    public delegate void possess();
    public static event possess possess_stone;
    public static event possess unpossess_stone;

    void Start()
    {
        speed = wisp_speed;
        playerScale = transform.localScale;
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        Move();

        if (can_stone_skill && Input.GetMouseButtonDown(0))
        {
            Debug.Log("SKILL");
        }

        if (range_stone && Input.GetKeyDown(KeyCode.E))
        {
            if (!is_hosted)
            {
                if (possess_stone != null)
                    possess_stone();

                stone_host();
            }
            else
            {
                if (unpossess_stone != null)
                    unpossess_stone();

                stone_unhost();
            }
        }    
    }

    private void Move()
    {
        if (characterController.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;

            if (can_jump && Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;

            //jumps = 0;
        }

        else
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), moveDirection.y, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection.x *= speed;
            moveDirection.z *= speed;

            //if (can_jump && Input.GetButton("Jump") && jumps < 1)
            //{
            //    moveDirection.y = jumpSpeed;
            //    jumps++;
            //}
        }

        moveDirection.y -= gravity * Time.deltaTime;

        characterController.Move(moveDirection * Time.deltaTime);
    }

    private void OnEnable()
    {
        stone_collider.in_range += in_range_stone;
        stone_collider.out_range += out_range_stone;
    }

    private void OnDisable()
    {
        stone_collider.in_range -= in_range_stone;
        stone_collider.out_range -= out_range_stone;
    }

    void in_range_stone()
    {
        Debug.Log("in_range_stone");
        range_stone = true;
    }

    void out_range_stone()
    {
        Debug.Log("out_range_stone");
        range_stone = false;
    }

    void stone_host()
    {
        is_hosted = true;
        can_stone_skill = true; 

        // make player invisible
        transform.localScale = new Vector3(0, 0, 0);

        // change player movement variables
        speed = stone_speed; 
        can_jump = false;
    }

    void stone_unhost()
    {
        is_hosted = false;
        can_jump = true;
        can_stone_skill = false;

        // eject player out of host
        gameObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.back * thrust);

        // make player visible
        transform.localScale = playerScale;

        // wisp movement variables
        speed  = wisp_speed;
    }

}

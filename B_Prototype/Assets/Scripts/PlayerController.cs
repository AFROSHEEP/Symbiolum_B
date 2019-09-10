using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController characterController;

    private float speed;
    public float wisp_speed;
    public float bear_speed;
    public float mole_speed;
    public float jumpSpeed;
    public float gravity;
    public float thrust;
    public float rotation_speed;
    //private int jumps = 0;

    private Vector3 moveDirection = Vector3.zero;
    private Vector3 playerScale;

    private bool range_bear;
    private bool range_mole;
    private bool is_hosted;
    private bool can_jump = true;
    private bool can_possess = true;
    private bool can_bear_skill;
    private bool can_mole_skill;

    public delegate void possess();
    public static event possess possess_bear;
    public static event possess unpossess_bear;

    public static event possess possess_mole;
    public static event possess unpossess_mole;

    void Start()
    {
        speed = wisp_speed;
        playerScale = transform.localScale;
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        Move();
        check_host_bear();
        check_host_mole();
        bear_skill();

    }

    private void bear_skill()
    {
        if (can_bear_skill && Input.GetMouseButtonDown(0))
            Debug.Log("Bear Skill");
    }

    private void mole_skill()
    {
        if (can_mole_skill && Input.GetMouseButtonDown(0))
            Debug.Log("Mole Skill");
    }

    private void check_host_bear()
    {
        if (range_bear && Input.GetKeyDown(KeyCode.E))
        {
            if (can_possess && !is_hosted )
            {
                if (possess_bear != null)
                    possess_bear();

                bear_host();
            }
            else
            {
                if (unpossess_bear != null)
                    unpossess_bear();

                bear_unhost();
            }
        }
    }

    private void check_host_mole()
    {
        if (range_mole && Input.GetKeyDown(KeyCode.E))
        {
            if (can_possess && !is_hosted)
            {
                if (possess_mole != null)
                    possess_mole();

                mole_host();
            }
            else
            {
                if (unpossess_mole != null)
                    unpossess_mole();

                mole_unhost();
            }
        }
    }

    private void Move()
    {
        if (characterController.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(-moveDirection);
            moveDirection *= speed;

            if (can_jump && Input.GetButton("Jump"))
                moveDirection.y += jumpSpeed;

            //jumps = 0;
        }

        else
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), moveDirection.y, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(-moveDirection);
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
        bear_collider.bear_in_range += in_range_bear;
        bear_collider.bear_out_range += out_range_bear;
        mole_collider.mole_in_range += in_range_mole;
        mole_collider.mole_out_range += out_range_mole;
    }

    private void OnDisable()
    {
        bear_collider.bear_in_range -= in_range_bear;
        bear_collider.bear_out_range -= out_range_bear;
        mole_collider.mole_in_range -= in_range_mole;
        mole_collider.mole_out_range -= out_range_mole;
    }

    void in_range_bear()
    {
        Debug.Log("in_range_bear");
        range_bear = true;
    }

    void out_range_bear()
    {
        Debug.Log("out_range_bear");
        range_bear = false;
    }

    void in_range_mole()
    {
        Debug.Log("in_range_mole");
        range_mole = true;
    }

    void out_range_mole()
    {
        Debug.Log("out_range_mole");
        range_mole = false;
    }

    void bear_host()
    {
        can_possess = false;
        is_hosted = true;
        can_bear_skill = true; 

        // make player invisible
        //transform.localScale = new Vector3(0, 0, 0);
        GetComponentInChildren<MeshRenderer>().enabled = false;

        // change player movement variables
        speed = bear_speed; 
        can_jump = false;
    }

    void bear_unhost()
    {
        can_possess = true;
        is_hosted = false;
        can_jump = true;
        can_bear_skill = false;

        // eject player out of host
        //GetComponentInParent<Rigidbody>().AddForce(Vector3.up * thrust);

        // make player visible
        //transform.localScale = playerScale;
        GetComponentInChildren<MeshRenderer>().enabled = true;


        // wisp movement variables
        speed = wisp_speed;
    }

    void mole_host()
    {
        can_possess = false;
        is_hosted = true;
        can_mole_skill = true;

        //transform.localScale = new Vector3(0, 0, 0);
        GetComponentInChildren<MeshRenderer>().enabled = false;

        // move underground

        // move mesh down a little

        // change player movement variables
        speed = mole_speed;
        can_jump = false;
    }

    void mole_unhost()
    {
        can_possess = true;
        is_hosted = false;
        can_jump = true;
        can_mole_skill = false;

        // eject player out of host
        //GetComponentInParent<Rigidbody>().AddForce(Vector3.up * thrust);

        // make player visible
        //transform.localScale = playerScale;
        GetComponentInChildren<MeshRenderer>().enabled = true;

        // wisp movement variables
        speed = wisp_speed;
    }

}

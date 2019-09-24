using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    CharacterController characterController;

    public float speed = 30.0f;
    public float jumpSpeed = 20.0f;
    public float gravity = 60.0f;
    public Host host;
    public float horizontalSpeed = 2.0F;
    public float verticalSpeed = 2.0F;

    public ParticleSystem PartSys;

    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        Move();
        hosting();
    }

    private void hosting()
    {
        if (host != null)
        {
            host.transform.SetPositionAndRotation(new Vector3(transform.position.x,
                transform.position.y + host.yOffset, transform.position.z), host.transform.rotation);

            if (Input.GetKey(KeyCode.E))
            {
                unhost();
                eject();
            }
        }
    }

    private void Move()
    {
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");


        if (characterController.isGrounded)
        {
            moveDirection = new Vector3(hInput, 0.0f, vInput);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= -speed;

            //if (Input.GetKeyDown(KeyCode.Space))
            //    moveDirection.y = jumpSpeed;
        }

        else
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), moveDirection.y, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection.x *= -speed;
            moveDirection.z *= -speed;
        }

        //if (hInput != 0 || vInput != 0)
        //{
        //    Quaternion newRotation = Quaternion.LookRotation(moveDirection);
        //    transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, 0.5f);

        //}

        moveDirection.y -= gravity * Time.deltaTime;
            characterController.Move(moveDirection * Time.deltaTime);
    }

    private void unhost()
    {
        switch (host.type)
        {
            case Animal.Bear:
                host.GetComponent<bear_script>().end_hosting_bear();
                break;
            case Animal.Mole:
                host.GetComponent<mole_script>().end_hosting_mole();
                break;
            case Animal.Fish:
                host.GetComponent<fish_script>().end_hosting_fish();
                break;
        }

        GetComponentInChildren<MeshRenderer>().enabled = true;
        host = null;
        GetComponentInChildren<ParticleSystem>().Play();
        //eject();
    }

    private void OnTriggerEnter(Collider animal)
    {
        if (host != null && animal.transform.GetComponent<Host>() != null)
        {
            unhost();
        }
        start_hosting(animal);
    }

    private void start_hosting(Collider animal)
    {
        //Debug.Log("start_hosting");

        if (animal.transform.GetComponent<Host>() != null)
        {
            //Debug.Log("in if");
            this.GetComponentInChildren<ParticleSystem>().Stop();
            host = animal.transform.GetComponent<Host>();
            this.GetComponentInChildren<MeshRenderer>().enabled = false;
            transform.position = host.transform.position;
            speed = host.speed;
            jumpSpeed = host.jumpSpeed;
            host.start_host();
        }
    }

    private void eject()
    {
        Debug.Log("eject");

        moveDirection.y = jumpSpeed;
        moveDirection.y -= gravity * Time.deltaTime;
        characterController.Move(moveDirection * Time.deltaTime);
    }
}

//public class PlayerController : MonoBehaviour
//{
//    CharacterController characterController;

//    public Host host;
//    private float speed;
//    public float wisp_speed;
//    public float bear_speed;
//    public float mole_speed;
//    public float jumpSpeed;
//    public float gravity;
//    public float thrust;
//    public float rotation_speed;
//    //private int jumps = 0;

//    private Vector3 moveDirection = Vector3.zero;
//    //private Vector3 playerScale;

//    private bool range_bear;
//    private bool range_mole;

//    private bool bear_hosting;
//    private bool mole_hosting;

//    private bool is_hosted;
//    private bool can_possess = true;

//    private bool can_jump = true;

//    public delegate void possess();
//    public static event possess possess_bear;
//    public static event possess unpossess_bear;

//    public static event possess possess_mole;
//    public static event possess unpossess_mole;

//    void Start()
//    {
//        speed = wisp_speed;
//        //playerScale = transform.localScale;
//        characterController = GetComponent<CharacterController>();
//    }

//    private void OnTriggerEnter(Collider other)
//    {
//        if (other.transform.GetComponent<Host>() != null)
//        {
//            host = other.transform.GetComponent<Host>();
//            //transform.GetComponent<MeshRenderer>().enabled = false;
//            transform.position = host.transform.position;
//            speed = host.speed;
//            jumpSpeed = host.jumpSpeed;
//        }
//    }

//    void Update()
//    {
//        Move();

//        if (Input.GetKeyDown(KeyCode.E))
//            unhost_current();

//        if (host != null)
//        {
//            //host.transform.position = transform.position;
//            host.transform.SetPositionAndRotation(new Vector3(transform.position.x,
//                transform.position.y + host.yOffset, transform.position.z), host.transform.rotation);

//            if (Input.GetKey(KeyCode.E))
//            {
//                host = null;
//                //transform.GetComponent<MeshRenderer>().enabled = true;
//                speed = 30.0f;
//                jumpSpeed = 20.0f;
//            }
//        }
//    }

//    void unhost_current()
//    {
//        if (bear_hosting)
//        {
//            if (unpossess_bear != null)
//                unpossess_bear();

//            bear_unhost();
//        }

//        if (mole_hosting)
//        {
//            if (unpossess_mole != null)
//                unpossess_mole();

//            mole_unhost();
//        }
//    }

//    void jump_animal(Collider other)
//    {
//        if (is_hosted)
//            unhost_current();

//        if (other.transform.GetComponentInChildren<bear_script>() != null)
//        {
//            if (possess_bear != null)
//                possess_bear();

//            bear_host();
//        }

//        if (other.transform.GetComponentInChildren<mole_script>() != null)
//        {
//            if (possess_mole != null)
//                possess_mole();

//            mole_host();
//        }
//    }

//    private void Move()
//    {
//        if (characterController.isGrounded)
//        {
//            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
//            moveDirection = transform.TransformDirection(-moveDirection);
//            moveDirection *= speed;

//            if (can_jump && Input.GetButton("Jump"))
//                moveDirection.y += jumpSpeed;

//            //jumps = 0;
//        }

//        else
//        {
//            moveDirection = new Vector3(Input.GetAxis("Horizontal"), moveDirection.y, Input.GetAxis("Vertical"));
//            moveDirection = transform.TransformDirection(-moveDirection);
//            moveDirection.x *= speed;
//            moveDirection.z *= speed;

//            //if (can_jump && Input.GetButton("Jump") && jumps < 1)
//            //{
//            //    moveDirection.y = jumpSpeed;
//            //    jumps++;
//            //}
//        }

//        moveDirection.y -= gravity * Time.deltaTime;

//        characterController.Move(moveDirection * Time.deltaTime);
//    }

//    void bear_host()
//    {
//        can_possess = false;
//        is_hosted = true;
//        bear_hosting = true;

//        // make player invisible
//        //transform.localScale = new Vector3(0, 0, 0);
//        GetComponentInChildren<MeshRenderer>().enabled = false;

//        // change player movement variables
//        speed = bear_speed;
//        can_jump = false;
//    }

//    void bear_unhost()
//    {
//        can_possess = true;
//        is_hosted = false;
//        bear_hosting = false;

//        // eject player out of host
//        //GetComponentInParent<Rigidbody>().AddForce(Vector3.up * thrust);

//        // make player visible
//        //transform.localScale = playerScale;
//        GetComponentInChildren<MeshRenderer>().enabled = true;


//        // wisp movement variables
//        speed = wisp_speed;
//        can_jump = true;
//    }

//    void mole_host()
//    {
//        can_possess = false;
//        is_hosted = true;
//        mole_hosting = true;

//        //transform.localScale = new Vector3(0, 0, 0);
//        GetComponentInChildren<MeshRenderer>().enabled = false;

//        // change player movement variables
//        speed = mole_speed;
//        can_jump = false;
//    }

//    void mole_unhost()
//    {
//        can_possess = true;
//        is_hosted = false;
//        mole_hosting = false;

//        // eject player out of host
//        //GetComponentInParent<Rigidbody>().AddForce(Vector3.up * thrust);

//        // make player visible
//        //transform.localScale = playerScale;
//        GetComponentInChildren<MeshRenderer>().enabled = true;

//        speed = wisp_speed;
//        can_jump = true;
//    }
//}







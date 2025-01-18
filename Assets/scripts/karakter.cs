using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class karakter : MonoBehaviour
{
    public float jumpforce = 7f;
    private Rigidbody rb;
    public bool isgrounded;
    Animator anim;

    public float attackrange = 15f;
    public Transform attackposition;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            anim.SetBool("runf", true);
            transform.Translate(0, 0, 6 * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))

        {
            anim.SetBool("runf", true);
            transform.Translate(0, 0, -6 * Time.deltaTime);
        }
        else
        {
            anim.SetBool("runf", false);
            anim.SetBool("runb", false);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 150 * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -150 * Time.deltaTime, 0);
        }
        if (Input.GetKeyDown(KeyCode.Space) && isgrounded)
        {
            anim.SetBool("jump", true);
            rb.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
            isgrounded = false;
        }
        else
        {
            anim.SetBool("jump", false);
        }
        if (Input.GetMouseButton(0))
        {
            anim.SetBool("ates", true);
            RaycastHit hit;
            if (Physics.Raycast(attackposition.position, attackposition.forward, out hit, attackrange))
            {
                if (hit.transform.CompareTag("enemy"))
                {
                    hit.transform.GetComponent<dusman>().Die();
                }

            }
        }
        else
        {
            anim.SetBool("ates", false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isgrounded = true;
        }
    }
}

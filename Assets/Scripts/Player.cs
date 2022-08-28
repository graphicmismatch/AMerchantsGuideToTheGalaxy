using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    Rigidbody2D body;
    Animator anim;
    float horizontal;
    float vertical;
    Inventory inv;
    bool lost;

    public float runSpeed = 20.0f;

    void Start()
    {
        inv = FindObjectOfType<Inventory>();
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");

        if (SceneManager.GetActiveScene().name == "SpaceScene")
        {
            if (inv.fuel > 0)
            {
                anim.SetBool("rocket mode", true);
            }
            else if (inv.fuel <= 0)
            {
                SceneManager.LoadScene("LoseScene");
            }
        }
        else
        {
            anim.SetBool("rocket mode", false);
        }
    }

    private void FixedUpdate()
    {
        body.velocity = new Vector2(horizontal * runSpeed * Time.deltaTime, vertical * runSpeed * Time.deltaTime);
        anim.SetFloat("xv", horizontal);
        anim.SetFloat("yv", vertical);
        anim.SetFloat("v", Mathf.Abs(horizontal * 10) + Mathf.Abs(vertical * 10));

        if (SceneManager.GetActiveScene().name == "SpaceScene")
        {
            if (inv.fuel > 0)
            {
                if (body.velocity.magnitude > 0.1)
                {
                    inv.changeFuel(Time.deltaTime * -1);
                }
            }
        }
    }
}

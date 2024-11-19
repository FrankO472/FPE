using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float movespeed;
    public float cameraSpeed;
    public float gravity;
    public float jumpForce;
    public float gravityLimit;
    public float gravityMultiplier;
    public int jumpCount;
    public int jumpmax;
    Vector2 inputs;

    public CharacterController controller;
    public GameObject cam;
    public GameObject playerHead;
    public string spawnPoint;

    public Animator bbox;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -20)
        {
            StartCoroutine(ResetOnDeath());
        }
        Move();
        Jump();
        Rotation();
        if (controller.isGrounded)
        {
            jumpCount = jumpmax;
        }
    }

    void Move()
    {
        inputs = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector3 movement = new Vector3(inputs.x, gravity, inputs.y);
        movement = Quaternion.Euler(0, cam.transform.eulerAngles.y, 0) * movement;
        controller.Move(movement * movespeed * Time.deltaTime); 
    }

    void Rotation()
    {
        playerHead.transform.rotation = Quaternion.Slerp(playerHead.transform.rotation, cam.transform.rotation, cameraSpeed * Time.deltaTime); 
    }
    

    void Jump()
    {
        if (gravity < gravityLimit)
        {
            gravity = gravityLimit;
        }
        else 
        {
            gravity -= Time.deltaTime * gravityMultiplier;
        }

        if (controller.isGrounded && Input.GetButtonDown("Jump"))
        {
            gravity = Mathf.Sqrt(jumpForce);
        }

        else if (controller.isGrounded == false && jumpCount >= 1 && Input.GetButtonDown("Jump"))
        {
            gravity = Mathf.Sqrt(jumpForce);
            jumpCount --;
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Spikes"))
        {
            StartCoroutine(ResetOnDeath());
        }
    }

    public IEnumerator ResetOnDeath()
    {
        bbox.SetBool("out", false);
        controller.enabled = false;
        yield return new WaitForSeconds(1f);
        transform.position = GameObject.Find(spawnPoint). transform.position;
        yield return new WaitForSeconds(.1f);
        bbox.SetBool("out", true);
        controller.enabled = true;
    }

    public IEnumerator ResetPos()
    {
        Debug.Log("Reset Pos");
        bbox.SetBool("out", true);
        controller.enabled = false;
        transform.position = GameObject.Find(spawnPoint). transform.position;
        yield return new WaitForSeconds(.1f);
        controller.enabled = true;
    }

    public IEnumerator LoadNewScene(string levelName)
    {
        Debug.Log("Loaded New Scene");
        bbox.SetBool("out", false);
        controller.enabled = false;
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(levelName);
        controller.enabled = true;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform position;
    [SerializeField] private float magnitude = 1;
    private bool accelerating;
    private Vector3 dir;

    // Start is called before the first frame update
    void Start()
    {
        dir = new Vector3(0,0,0);
        accelerating = false;
    }

    void FixedUpdate()
    {
        if (accelerating) {
            rb.AddForce(dir * magnitude,ForceMode.Impulse);
            accelerating = false;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        //gather user input
        if (Input.GetKeyDown(KeyCode.Space)){
            accelerating = true;
        }
        float ud = Input.GetAxisRaw("Vertical");
        float lr = Input.GetAxisRaw("Horizontal");
        dir = new Vector3 (lr, 0, ud);
        dir.Normalize();
    }
}

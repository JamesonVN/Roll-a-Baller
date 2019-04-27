using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text winText;
    private Rigidbody rb;
    private int count;

    void Start()
    {
        count = 0;
        SetCountText();
        rb = GetComponent<Rigidbody>();
        winText.text = "";
    }

    void FixedUpdate()
    {
        float movehorizontal = Input.GetAxis("Horizontal");
        float movevertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(movehorizontal, 0.0f, movevertical);
        rb.AddForce(movement*speed);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count += 1;
            SetCountText();
        }
            
    }

    void SetCountText()
    {
        countText.text = "Count " + count.ToString();

        if(count == 20)
        {
            winText.text = "Congradulation, You're Winner";
        }
    }

    //Destroy(other.gameObject);

}

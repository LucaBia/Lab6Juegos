using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Pelora : MonoBehaviour
{
    public float fuerza = 0;
    private Rigidbody rBody;
    public int contMonedas = 0;
    //public PauseMenu contador;
    public Text countText;

    public Camera cam;
    public NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody>();
        SetCountText();
    }

    // Update is called once per frame
    void Update()
    {
        if (rBody && Input.GetButtonDown("Jump"))
            //rb.AddForce(0, force, 0, ForceMode.Impulse);
            Jump();

        RaycastHit hitInfo;
        if(Physics.Raycast(transform.position, Vector3.down, out hitInfo, 1))
        {
            if(hitInfo.collider.gameObject.CompareTag("Plano"))
                hitInfo.collider.GetComponent<MeshRenderer>().material.color = Color.red;
        }

        Debug.DrawRay(transform.position, Vector3.down * 2, Color.blue);

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }


        }
    }

    private void FixedUpdate()
    {
        if (rBody)
        {
            rBody.AddForce(Input.GetAxis("Horizontal") * fuerza, 0, Input.GetAxis("Vertical") * fuerza);
        }
    }

    //Esto salta
    private void Jump()
    {
        if (rBody)
        {
            if (Mathf.Abs(rBody.velocity.y) < 0.005f)
                rBody.AddForce(0, fuerza, 0, ForceMode.Impulse);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(contMonedas != 3)
            Destroy(gameObject);

    }

    void OnCollisionEnter(Collision otherObj)
    {
        if (otherObj.gameObject.tag == "moneda")
        {
            Destroy(otherObj.gameObject);
            this.contMonedas++;
            countText.text = "Coins: " + contMonedas.ToString();
            //contador.ShowCoins();
        }
    }

    void SetCountText()
    {
        countText.text = "Coins: " + contMonedas.ToString();
    }

    //private void OnMouseEnter()
    //{
    //    Destroy(gameObject);
    //}

    private void OnMouseDown()
    {
        Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if (Physics.Raycast(myRay, out hitInfo))
            rBody.AddForce(-hitInfo.normal * fuerza, ForceMode.Impulse);
    }


}

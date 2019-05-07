using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Pelora : MonoBehaviour
{
    public float fuerza = 0;
    private Rigidbody rBody;

    public Camera cam;
    public NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
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




}

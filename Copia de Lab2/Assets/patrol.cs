using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class patrol : MonoBehaviour
{
    public NavMeshAgent miAgente;
    public Transform objetivo;

    // Start is called before the first frame update
    void Start()
    {
       if(miAgente == null)
        {
            miAgente = this.gameObject.GetComponent<NavMeshAgent>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        miAgente.SetDestination(objetivo.position);
    }
}

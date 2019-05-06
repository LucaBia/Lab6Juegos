using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Revivir : MonoBehaviour
{
    public GameObject player;
    public GameObject currPlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RevivirPelota()
    {
        if (player && !currPlayer)
            currPlayer = Instantiate(player, new Vector3(-4, 1, -4), Quaternion.identity);

           
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class scriptGhost : MonoBehaviour
{
    public GameObject Pacman;
    private NavMeshAgent agente;
    // Start is called before the first frame update
    void Start()
    {
        agente = GetComponent<NavMeshAgent>();        
    }

    // Update is called once per frame
    void Update()
    {
       agente.destination = Pacman.transform.position;
        
    }
}

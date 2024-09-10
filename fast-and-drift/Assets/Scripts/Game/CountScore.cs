using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountScore : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private bool podeCruzarALap;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        podeCruzarALap = true;
    }

    private void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if(podeCruzarALap)
            {
                ContarLap();
                podeCruzarALap = false;
                StartCoroutine(StartColdown());
            }
        }
    }
    
    private IEnumerator StartColdown()
    {   
        yield return new WaitForSeconds(20);
        podeCruzarALap = true;
    }

    private void ContarLap()
    {
        gameManager.countLaps ++;
    }
}

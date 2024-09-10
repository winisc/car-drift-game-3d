using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Collider_Explode : MonoBehaviour
{
    [SerializeField] private ParticleSystem batida;
    [SerializeField] private AudioSource soundCarBatidaForte;
    [SerializeField] private AudioSource soundCarBatidaFraca;
    public bool colidiu = false;

    Carro_Controller car;

    private void Start()
    {
        car = FindObjectOfType<Carro_Controller>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<Animator>().enabled = false;
            other.GetComponent<Carro_Controller>().enabled = false;
            colidiu = true;
            batida.Play();
            car.soundCar[1].Stop();
            car.soundCar[2].Stop();
            car.soundCar[3].Stop();

            //Controle de efeito sonoro em batida!
            if((car.speedFrontLive >= 140 && car.inputAndar.y > 0) || (car.speedBackLive >= 80 && car.inputAndar.y < 0))
            {
                soundCarBatidaForte.Play();
            }
            else if((car.speedFrontLive == 70 && car.inputAndar.y > 0) || (car.speedBackLive >= 50 && car.inputAndar.y < 0))
            {
                soundCarBatidaFraca.Play();
            }
        }

    }
}

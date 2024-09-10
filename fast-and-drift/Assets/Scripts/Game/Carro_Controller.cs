using System;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Carro_Controller : MonoBehaviour
{
    [Header ("Componentes")]
    [SerializeField] private Rigidbody rig;
    private GameManager gManager;

    [Space (10)]

    [Header ("Trails")]
    [SerializeField] private TrailRenderer trailMove1;
    [SerializeField] private TrailRenderer trailMove2;
    [SerializeField] private TrailRenderer trailFreio1;
    [SerializeField] private TrailRenderer trailFreio2;
    [SerializeField] private TrailRenderer trailNitro1;
    [SerializeField] private TrailRenderer trailNitro2;

    [Space(10)]

    [SerializeField] private GameObject lanternaTraseira;
    [SerializeField] private Image nitroMobile;

    [Header("Variaveis de controle para a Movimentação")]
    [SerializeField] private float speedFront;
    [SerializeField] private float speedBrakeFront;
    public float speedFrontLive;
    [SerializeField] private float velocidadeComNitro;

    [Space(10)]

    [SerializeField] private float speedBack;
    [SerializeField] private float speedBrakeBack;
    public float speedBackLive;

    [Space(10)]
    
    [SerializeField] private float speedRotate;
    [SerializeField] private float angleMaxRotRodas;
    [SerializeField] private Transform rodaFrontalEsquerda;
    [SerializeField] private Transform rodaFrontalDireita;

    [Space(10)]

    [SerializeField] private bool nitroOn = false;
    [SerializeField] private bool usandoNitro = false;
    public float quantidadeDeNitro = 0f;

    [Header("Controle de Drag")]
    [SerializeField] private float dragNormal;
    [SerializeField] private float dragFreiando;

    [Header("Inputs")]
    public Vector2 inputAndar;
    [SerializeField] private Vector2 inputRotacionar;
    [SerializeField] private float inputFreio;
    [SerializeField] private float inputNitro;

    [Space(10)]

    [Header("Inclinação do Carro em Rampas")]
    [SerializeField] private float speedInclinationRampa;
    [SerializeField] private float tamanhoDosRaiosDeVerificacaoDoChao;
    [SerializeField] private Transform verificador01;
    [SerializeField] private Transform verificador02;
    [SerializeField] private LayerMask layerGround;
    [SerializeField] private RaycastHit localDoRaio;
    [SerializeField] private bool isGrounded;

    [Space(10)]

    [Header("Gravidade")]
    [SerializeField] private float forceGravity;

    [Space(10)]

    public AudioSource[] soundCar;

    void Awake()
    {
        gManager = FindObjectOfType<GameManager>();
        rig = GetComponent<Rigidbody>();

        speedFrontLive = speedFront;
        speedBackLive = speedBack;

        rig.drag = dragNormal;
        
        trailFreio1.emitting = false;
        trailFreio2.emitting = false;

        lanternaTraseira.gameObject.SetActive(false);
    }

    private void Update()
    {
        RotRodas();
        InclinarNaRampa();
        ControleDeNitro();
        SoundsCar();
        IconNitroMobile();
    }

    void FixedUpdate()
    {
        Rotacionar();
        Andar();
        Efeitos();
        Gravidade();
        ControleNoAr();
        // SetAndarMobile();
    }
    
    private void ControleNoAr()
    {
        if(isGrounded)
        {
            rig.mass = 1f;
        }
        else
        {
            rig.mass = 0.7f;
        }
    }



    private void Efeitos()
    {

        if(!isGrounded)
        {
            trailMove1.emitting = false;
            trailMove2.emitting = false;

            trailFreio1.emitting = false;
            trailFreio2.emitting = false;
        }
        else if((inputAndar.y > 0f || inputAndar.y < 0f) && rig.drag == 5.6f && isGrounded)
        {
            trailMove1.emitting = true;
            trailMove2.emitting = true;
        }
        else if(inputAndar.y == 0f)
        {            
            trailMove1.emitting = false;
            trailMove2.emitting = false;
        }
    }

    public void SetAndar(InputAction.CallbackContext value)
    {
        inputAndar = value.ReadValue<Vector2>().normalized;
    }

    // public void SetAndarMobile()
    // {
    //     inputAndar.y = 1;
    // }

    public void SetFreiar(InputAction.CallbackContext value)
    {
        inputFreio = value.ReadValue<float>();
        if(inputFreio > 0.1f)
        {
            Freair();
        }
        else
        {
            VelocidadePadrao();
        }
    }

    public void SetNitro(InputAction.CallbackContext value)
    {        
        inputNitro = value.ReadValue<float>();
            if(inputNitro > 0.1f)
            {
                UsarNitro();
            }
            else
            {
                PararNitro();
            }

    }

    public void SetRotacionar(InputAction.CallbackContext value)
    {
        inputRotacionar = value.ReadValue<Vector2>().normalized;
    }

    private void RotRodas()
    {
        rodaFrontalEsquerda.localRotation = Quaternion.Euler(rodaFrontalEsquerda.localRotation.eulerAngles.x, 
        inputRotacionar.x * angleMaxRotRodas,rodaFrontalEsquerda.localRotation.eulerAngles.z);

        rodaFrontalDireita.localRotation = Quaternion.Euler(rodaFrontalDireita.localRotation.eulerAngles.x, 
        inputRotacionar.x * angleMaxRotRodas, rodaFrontalDireita.localRotation.eulerAngles.z);

    }
    private void Andar()
    {

        if(inputAndar.y > 0f)
        {
            rig.AddForce(transform.forward * speedFrontLive * inputAndar.y, ForceMode.Acceleration);
        }
        else if(inputAndar.y < 0f)
        {
            rig.AddForce(transform.forward * speedBackLive * inputAndar.y, ForceMode.Acceleration);
        }

    }
    private void Freair()
    {
        if(isGrounded)
        {
            speedFrontLive = speedBrakeFront;
            speedBackLive = speedBrakeBack;

            rig.drag = dragFreiando;

            trailFreio1.emitting = true;
            trailFreio2.emitting = true;

            trailMove1.emitting = false;
            trailMove2.emitting = false;
            speedRotate = 140;
            lanternaTraseira.gameObject.SetActive(true);
        }
    }

    private void VelocidadePadrao()
    {
        speedFrontLive = speedFront;
        speedBackLive = speedBack;

        rig.drag = dragNormal;
        trailFreio1.emitting = false;
        trailFreio2.emitting = false;
        speedRotate = 90;
        lanternaTraseira.gameObject.SetActive(false);
    }

    private void Rotacionar()
    {
        if(inputAndar.y > 0f)
        {
            float newRotation = inputRotacionar.x * speedRotate * Time.deltaTime;
            transform.Rotate(0f, newRotation, 0f, Space.World);
        }
        else if(inputAndar.y < 0f)
        {
            float newRotation = (-inputRotacionar.x) * speedRotate * Time.deltaTime;
            transform.Rotate(0f, newRotation, 0f, Space.World);
        }
    }

    private void InclinarNaRampa()
    {
        Vector3 normalDoPiso = Vector3.zero;

        if(Physics.Raycast(verificador01.position, -transform.up, out localDoRaio, tamanhoDosRaiosDeVerificacaoDoChao, layerGround))
        {
            isGrounded = true;
            normalDoPiso = localDoRaio.normal;
        }
        else
        {
            isGrounded = false;
            normalDoPiso = Vector3.zero;
        }

        if(Physics.Raycast(verificador02.position, -transform.up, out localDoRaio, tamanhoDosRaiosDeVerificacaoDoChao, layerGround))
        {
            isGrounded = true;
            normalDoPiso = ((normalDoPiso + localDoRaio.normal) /2f);
        }
        
        // if(isGrounded)
        // {
        //     transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.FromToRotation(transform.up, normalDoPiso) * transform.rotation, 
        //     speedInclinationRampa * Time.deltaTime);
        // }
        // else
        // {
        //     transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.FromToRotation(transform.up, normalDoPiso), 
        //     speedInclinationRampa * Time.deltaTime);
        // }

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.FromToRotation(transform.up, normalDoPiso) * transform.rotation, 
        speedInclinationRampa * Time.deltaTime);
    }

    private void Gravidade()
    {
        if(!isGrounded)
        {
            rig.AddForce(-Vector3.up * forceGravity);
        }
    }

    private void ControleDeNitro()
    {
        if(quantidadeDeNitro <= 10)
        {
            if(!usandoNitro && inputAndar.y > 0 && inputFreio > 0.1f && isGrounded && (inputRotacionar.x > 0 || inputRotacionar.x < 0))
            {
                quantidadeDeNitro += 1 * Time.deltaTime;
            }

            
            if(!usandoNitro)
            {
                PararNitro();
            }


        }

        if(quantidadeDeNitro > 0)
        {
            nitroOn = true;
        }
        else
        {
            nitroOn = false;
        }

        if(usandoNitro)
        {
            quantidadeDeNitro -= 1.8f * Time.deltaTime;
            if(quantidadeDeNitro < 0)
            {
                quantidadeDeNitro = 0;
                usandoNitro = false;
            }
        }

        if(!nitroOn)
        {
            usandoNitro = false;
            trailNitro1.emitting = false;
            trailNitro2.emitting = false;
        }

        if(!isGrounded)
        {
            PararNitro();
        }
    }

    private void UsarNitro()
    {
        if(nitroOn && isGrounded)
        {
            speedFrontLive = velocidadeComNitro;
            usandoNitro = true;
            trailNitro1.emitting = true;
            trailNitro2.emitting = true;
        }  
    }

    private void PararNitro()
    {
        if(inputFreio > 0.1f)
        {
            speedFrontLive = speedBrakeFront;
        }
        else
        {
            speedFrontLive = speedFront;
        }
        usandoNitro = false;
        trailNitro1.emitting = false;
        trailNitro2.emitting = false;
    }

    private void SoundsCar()
    {
        if(speedFrontLive == 150 && inputAndar.y > 0) //Acelerando
        {
            soundCar[1].volume = 0.01f;
            soundCar[0].volume = 0;
            soundCar[1].pitch = 1;
            soundCar[2].volume = 0f;
            soundCar[3].volume = 0f;
        }
        else if(speedFrontLive == 200 && inputAndar.y > 0) //Nitro
        {
            soundCar[1].volume = 0.01f;
            soundCar[0].volume = 0;
            soundCar[2].volume = 0f;
            soundCar[1].pitch = 1.05f;
            soundCar[3].volume = 0f;
        }
        else if(inputAndar.y == 0) //Parado
        {
            soundCar[0].volume = 0.01f;
            soundCar[2].volume = 0f;
            soundCar[1].volume = 0f;
            soundCar[1].pitch = 1f;
            soundCar[3].volume = 0f;
        }
        else if(inputAndar.y > 0 && inputFreio > 0.1f) //Freiando em movimento
        {
            soundCar[2].volume = 0.01f;
            soundCar[0].volume = 0f;
            soundCar[1].volume = 0.008f;
            soundCar[1].pitch = .7f;
            soundCar[3].volume = 0f;
        }
    }

    private void IconNitroMobile()
    {
        if(quantidadeDeNitro > 0)
        {
            nitroMobile.color = new Color(1, 1, 1, 0.7294118f);
        }
        else if(quantidadeDeNitro <=0)
        {
            nitroMobile.color = new Color(0.8773585f, 0.8773585f, 0.8773585f, 0.3686275f);
        }
    }
}

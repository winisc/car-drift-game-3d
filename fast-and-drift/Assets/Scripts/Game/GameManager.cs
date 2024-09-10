using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.Video;

public class GameManager : MonoBehaviour
{
    [Header("Controle de UI")]

    [SerializeField] private Slider quantidadeDeNitro;
    [SerializeField] private Text timerLaps;
    [SerializeField] private Text lap;
    [SerializeField] private Text start;
    [SerializeField] private Text contagemRegr;

    [SerializeField] private Text scoreLap;
    [SerializeField] private Text score;

    [Space(10)]

    [SerializeField] private GameObject dicas;
    [SerializeField] private GameObject jogoRolando;
    [SerializeField] private GameObject informacoesInicias;
    [SerializeField] private GameObject valorNitro;
    [SerializeField] private GameObject comandos;
    [SerializeField] private GameObject crashed;
    [SerializeField] private GameObject paused;

    [Space(10)]

    [SerializeField] private GameObject uiGame;
    [SerializeField] private GameObject pista;
    [SerializeField] private GameObject carJogavel;
    [SerializeField] private GameObject customizar;

    [Space(10)]

    [SerializeField] private GameObject uiMobile;
    [SerializeField] private GameObject pauseMobile;


    [Space(10)]

    [Header("Componentes")]

    [SerializeField] private Carro_Controller carro;
    [SerializeField] private Collider_Explode collisionCar;

    [Space(10)]

    [Header("Variaveis")]

    public bool gameComecou = false;

    [SerializeField] private bool startGame = false;
    [SerializeField] private bool startContagemRegr = false;
    [SerializeField] private float countR;
    public int countLaps;
    [SerializeField] private float countTimerLaps;
    [SerializeField] private bool startCountTime = false;
    [SerializeField] private bool isPaused = false;

    [Space(10)]

    [SerializeField] private GameObject luzVerde;
    [SerializeField] private GameObject luzAmarela;
    [SerializeField] private GameObject luzVermelha;

    [Space(10)]

    [SerializeField] private int scoreLapNow;
    [SerializeField] private int scoreLapBestNew;
    [SerializeField] private int scoreLapBestOld;
    [SerializeField] private Text highScore;
    public int hgScore;

    [SerializeField] private AudioSource soundContRegrCar;
    

    void Start()
    {   
        startGame = true;
        informacoesInicias.gameObject.SetActive(false);
        jogoRolando.gameObject.SetActive(false);
        start.gameObject.SetActive(false);
        dicas.gameObject.SetActive(false);
        paused.gameObject.SetActive(false);
        crashed.gameObject.SetActive(false);

        countR = 3.5f;
        countLaps = 0;
        countTimerLaps = 0;

        luzVermelha.gameObject.SetActive(false);
        luzAmarela.gameObject.SetActive(false);
        luzVerde.gameObject.SetActive(false);

        uiMobile.SetActive(false);

        hgScore = PlayerPrefs.GetInt("BestScore");
    }

    // Update is called once per frame
    void Update()
    {
        StartCena();
        StartContagemRegressiva();
        QuantidaDeNitroNaTela();
        Score();
        VerificadorDeColisao();
        StartTimerLap();
        SinalDeStart();
        TelaDeCrash();
        Pausar();
    }

    public void SetPause(InputAction.CallbackContext value)
    {
        if(value.performed)
        {
            PauseCena();
        }
    }
    private void StartCena()
    {
        if(startGame)
        {
            comandos.gameObject.SetActive(false);
            uiGame.SetActive(false);
            pista.SetActive(false);
            carJogavel.SetActive(false);
            customizar.SetActive(true);

            startGame = false;
        }
    }

    public void IniciarComandos()
    {
        gameComecou = true;
        uiGame.SetActive(true);
        comandos.gameObject.SetActive(true);
        pista.SetActive(true);
        carJogavel.SetActive(true);
        customizar.SetActive(false);
        collisionCar = FindObjectOfType<Collider_Explode>();
        carro = FindObjectOfType<Carro_Controller>();
        carro.quantidadeDeNitro = 0;
        carro.enabled = false;
        soundContRegrCar.Play();
    }

    private void PauseCena()
    {
        if(!crashed.gameObject.activeSelf && !dicas.gameObject.activeSelf && !comandos.gameObject.activeSelf)
        {
            if (paused.gameObject.activeSelf) 
            {
                paused.gameObject.SetActive(false);
                pauseMobile.SetActive(true);
                isPaused = false;
            }
            else
            {
                paused.gameObject.SetActive(true);
                pauseMobile.SetActive(false);
                isPaused = true;
            }
        }
    }

    private void Pausar()
    {
        if(!isPaused)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }
    }

    public void ButtonVoltarPaused()
    {
        paused.gameObject.SetActive(false);
        pauseMobile.SetActive(true);
        isPaused = false;   
    }

    private void TelaDeCrash()
    {
        if(gameComecou)
        {
            if(collisionCar.colidiu)
            {
                crashed.SetActive(true);
            }
            else
            {
                crashed.SetActive(false);
            }
        }
    }

    public void ResetCena()
    {
        countR = 3.5f;
        carro.transform.position = new Vector3(-5.995f, 1.77f, -0.6f);
        carro.transform.rotation = Quaternion.Euler(0f, -90f, 0f);
        startContagemRegr = true;
        startCountTime = false;
        jogoRolando.SetActive(false);
        jogoRolando.SetActive(true);
        paused.SetActive(false);

        collisionCar.colidiu = false;
        isPaused = false;
        countLaps = 0;

        carro.quantidadeDeNitro = 0;
        soundContRegrCar.Play();
    }

    private void FecharDicas()
    {
        Destroy(dicas.gameObject);

    }
    private void FecharComandos()
    {
        Destroy(comandos.gameObject);

    }

    public void DicasButtonStart()
    {
        informacoesInicias.gameObject.SetActive(true);
        jogoRolando.gameObject.SetActive(true);
        startContagemRegr = true;
        dicas.gameObject.SetActive(false);
    }

    private void AbrirDicas()
    {

        dicas.gameObject.SetActive(true);

    }

    public void ComandosbuttonStart()
    {
        AbrirDicas();
        comandos.gameObject.SetActive(false);
   }

    private void StartContagemRegressiva()
    {
        if(startContagemRegr)
        {
            // uiMobile.SetActive(true);
            carro.transform.position = new Vector3(-5.995f, 0.6031048f, -0.6000004f);
            carro.transform.rotation = Quaternion.Euler(0f, -90f, 0f);
            contagemRegr.gameObject.SetActive(true);
            carro.enabled = false;
            countR -= Time.deltaTime;
            contagemRegr.text = countR.ToString("0");
            if(countR <= 0.5f)
            {
                contagemRegr.gameObject.SetActive(false);
                start.gameObject.SetActive(true);
                carro.enabled = true;
                countR = 0;
                carro.GetComponent<Animator>().enabled = true;
                collisionCar.colidiu = false;
                startCountTime = true;
                StartCoroutine(PlayStart());

                soundContRegrCar.Stop();

                carro.soundCar[1].Play();
                carro.soundCar[2].Play();
                carro.soundCar[3].Play();
                carro.soundCar[1].volume = 0;
                carro.soundCar[2].volume = 0;

                startContagemRegr = false;
            }
        }
    }

    private void SinalDeStart()
    {
        if(startContagemRegr)
        {
            if(countR <= 3.5 && countR >= 2.5)
            {
                luzVermelha.gameObject.SetActive(true);                
                luzAmarela.gameObject.SetActive(false);
                luzVerde.gameObject.SetActive(false);
            }
            else if(countR <= 2.5 && countR >= 0.5)
            {
                luzVermelha.gameObject.SetActive(false);               
                luzAmarela.gameObject.SetActive(true);
                luzVerde.gameObject.SetActive(false);

            }
        }
        
        if(countR == 0)
        {
            luzVermelha.gameObject.SetActive(false);
            luzAmarela.gameObject.SetActive(false);
            luzVerde.gameObject.SetActive(true);
        }
    }

    private IEnumerator PlayStart(){
        yield return new WaitForSeconds(1f);
        start.gameObject.SetActive(false);
    }

    private void QuantidaDeNitroNaTela()
    {
        if(gameComecou)
        {
            if(carro.quantidadeDeNitro <= 0)
            {
                valorNitro.gameObject.SetActive(false);
            }
            else if(carro.quantidadeDeNitro > 0)
            {
                valorNitro.gameObject.SetActive(true);
            }

            quantidadeDeNitro.value = carro.quantidadeDeNitro;
        }
    }

    private void Score()
    {
        scoreLapNow = countLaps;

        if(scoreLapNow > PlayerPrefs.GetInt("BestScore"))
        {
            PlayerPrefs.SetInt("BestScore", scoreLapNow);
        }

        lap.text = "LAPS: " + scoreLapNow.ToString("0");
        scoreLap.text = ("Laps: " + scoreLapNow.ToString("0"));
        highScore.text = "BEST SCORE: " + PlayerPrefs.GetInt("BestScore") + " LAPS";
        
        if(countLaps == 0)
        {
            score.color = Color.red;
            score.text = ("CRASHED!");
        }
        else if(countLaps == 1)
        {
            score.color = Color.white;
            score.text = ("Ok!");
        }
        else if(countLaps == 2)
        {
            score.color = Color.white;
            score.text = ("Nada mal!");
        }
        else if(countLaps == 3)
        {
            score.color = Color.white;
            score.text = ("UAU!");
        }
        else if(countLaps == 4)
        {
            score.color = Color.white;
            score.text = ("Mandou muito bem!");
        }
        else
        {
            score.color = Color.white;
            score.text = ("ANIMAL!");
        }
    }

    private void StartTimerLap()
    {
        if(startCountTime)
        {
            countTimerLaps += Time.deltaTime;
            int minutes = Mathf.FloorToInt(countTimerLaps/60);
            int seconds = Mathf.FloorToInt(countTimerLaps % 60);

            timerLaps.text = string.Format("Tempo: {00:00}:{1:00}", minutes, seconds);
        }
        else
        {
            countTimerLaps = 0;
        }
    }

    private void VerificadorDeColisao()
    {
        if(gameComecou)
        {
            if(collisionCar.colidiu)
            {
                startCountTime = false;
            }
        }
    }

    public void SetMenuPrincipal()
    {
        SceneManager.LoadScene("TelaInicial");   
    }
}

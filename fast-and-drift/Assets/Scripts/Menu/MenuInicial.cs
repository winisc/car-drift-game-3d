using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
    [SerializeField] private Animator jogar;
    [SerializeField] private Animator options;
    [SerializeField] private Animator sair;
    [SerializeField] private GameObject soundOpts;
    [SerializeField] private GameObject inicio;
    [SerializeField] private Animator voltar;
    [SerializeField] private Animator sliderSom;
    public float volumeMaster;

    public void VolumeMaster(float volume)
    {
        volumeMaster = volume;
        AudioListener.volume = volumeMaster;
    }
    private void Start()
    {
        jogar.Play("buttonJogar");
        options.Play("buttonOptions");
        sair.Play("buttonSair");
        Time.timeScale = 1;
        
        soundOpts.SetActive(false);
    }

    public void SetJogar()
    {
        SceneManager.LoadScene("StartGame");
    }

    public void SetOptions()
    {
        jogar.Play("acaoOptionsJogar");
        sair.Play("acaoOptionsSair");
        options.Play("acaoOptionsOpt");
        inicio.SetActive(false);
        soundOpts.SetActive(true);
        voltar.Play("buttonSair");
        sliderSom.Play("buttonOptions");
    }

    public void SetSair()
    {
        Debug.Log("Saiu");
        Application.Quit();
    }

    public void SetVoltar()
    {
        voltar.Play("acaoOptionsSair");
        sliderSom.Play("acaoOptionsOpt");
        soundOpts.SetActive(false);
        inicio.SetActive(true);
        jogar.Play("buttonJogar");
        options.Play("buttonOptions");
        sair.Play("buttonSair");

    }
}

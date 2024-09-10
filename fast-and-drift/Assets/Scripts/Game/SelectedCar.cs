using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectedCar : MonoBehaviour
{
    [SerializeField] private GameObject buttonCustomizar;
    [SerializeField] private GameObject abaCustomizar;
    [SerializeField] private Renderer car;
    [SerializeField] private Renderer carJogavel;
    private GameManager gameManager;

    private void Start()
    {
        buttonCustomizar.SetActive(true);
        abaCustomizar.SetActive(false);
        gameManager = FindObjectOfType<GameManager>();

        car.material.color = new Color(0.8000785f, 0.02230093f, 0.04332529f);
    }

    public void SetVoltar()
    {
        SceneManager.LoadScene("TelaInicial");
    }

    public void SetConfirmar()
    {
        gameManager.IniciarComandos() ;  
    }

    public void SetCustomizar()
    {
        buttonCustomizar.SetActive(false);
        abaCustomizar.SetActive(true);
    }

    public void SetColorRed()
    {
        car.material.color = new Color(0.8000785f, 0.02230093f, 0.04332529f);
        carJogavel.material.color = new Color(0.8000785f, 0.02230093f, 0.04332529f);
    }

    public void SetColorVerde()
    {
        car.material.color = new Color(0.1742965f, 0.8f, 0.02352939f);
        carJogavel.material.color = new Color(0.1742965f, 0.8f, 0.02352939f);
    }

    public void SetColorRosa()
    {
        car.material.color = new Color(0.8f, 0.02352939f,0.6751072f);
        carJogavel.material.color = new Color(0.8f, 0.02352939f,0.6751072f); 
    }

    public void SetColorSK34()
    {
        
    }
}

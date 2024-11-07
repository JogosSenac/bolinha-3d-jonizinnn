using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallMoviment : MonoBehaviour
{
    private float moveH;
    private float moveV;
    private Rigidbody rb;
    [SerializeField] private float velocidade;
    [SerializeField] private float forcaPulo;
    [SerializeField] private int pontos;
    [SerializeField] private bool estaVivo = true;

    [Header("Sons da Bolinha")]
    [SerializeField] private AudioClip pulo;
    [SerializeField] private AudioClip pegaCubo;
    private AudioSource audioPlayer;
    private TextMeshProUGUI textoPontos;
    private TextMeshProUGUI textoTotal;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioPlayer = GetComponent<AudioSource>();
        textoPontos = GameObject.FindGameObjectWithTag("Pontos").GetComponent<TextMeshProUGUI>();
        textoTotal = GameObject.Find("TotalCubos").GetComponent<TextMeshProUGUI>();
        textoTotal.text = GameObject.FindGameObjectsWithTag("CuboBrilhante").Length.ToString();
    }

    void Update()
    {
        if(estaVivo)
        {
            moveH = Input.GetAxis("Horizontal");
            moveV = Input.GetAxis("Vertical");

            transform.position += new Vector3(-1 * moveV * velocidade * Time.deltaTime, 0, moveH * velocidade * Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(transform.up * forcaPulo, ForceMode.Impulse);
                audioPlayer.PlayOneShot(pulo);
            }
            VerificaObjetivos();

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("CuboBrilhante"))
        {
            Destroy(other.gameObject);
            audioPlayer.PlayOneShot(pegaCubo);
            pontos++;
            textoPontos.text = pontos.ToString();
        }
        if (other.gameObject.CompareTag("PassaFase1")&&pontos>=11)
        {
            SceneManager.LoadScene("nivel2");
        }
        if (other.gameObject.CompareTag("fim de jogo") && pontos >= 10)
        {
            SceneManager.LoadScene("win");
        }
        if (other.gameObject.CompareTag("Acelerador"))
        {
            velocidade += velocidade ;
        }
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Agua"))
        {
            estaVivo = false;
        }
    }

    public bool Vida()
    {
        return estaVivo;
    }
    private void VerificaObjetivos()
    {
        int totalCubos = Int32.Parse(textoTotal.text);
        TextMeshProUGUI objetivo = GameObject.Find("Objetivo").GetComponent<TextMeshProUGUI>();

        if (pontos < totalCubos)
        {
            objetivo.text = "COLETE OS CUBOS";
        }

        if (pontos >= totalCubos / 2)
        {
            objetivo.text = "METADE JÁ COLETADA";
        }

        if (pontos >= totalCubos - 1)
        {
            objetivo.text = "RESTA APENAS 1";
        }

        if (pontos == totalCubos)
        {
            objetivo.text = "PASSAGEM LIBERADA";
        }
    }
}

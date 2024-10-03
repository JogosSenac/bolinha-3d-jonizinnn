using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioPlayer = GetComponent<AudioSource>();
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
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("CuboBrilhante"))
        {
            Destroy(other.gameObject);
            audioPlayer.PlayOneShot(pegaCubo);
            pontos++;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Agua"))
        {
            estaVivo = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuboBrilhante : MonoBehaviour
{
    [SerializeField] private float rX;
    [SerializeField] private float rY;
    [SerializeField] private float rZ;
    [SerializeField] private float velocidade;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(rX * velocidade * Time.deltaTime, rY * velocidade * Time.deltaTime, rZ * velocidade * Time.deltaTime);
    }
}

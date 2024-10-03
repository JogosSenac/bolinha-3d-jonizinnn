using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementoTextura : MonoBehaviour
{
    [SerializeField] private float speedY;
    [SerializeField] private float speedX;
    private MeshRenderer rend;

    void Start()
    {
        rend = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        rend.material.mainTextureOffset = new Vector2(speedX * Time.timeSinceLevelLoad, speedY * Time.timeSinceLevelLoad);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScript : MonoBehaviour {

    public float backGroundSize;
    public bool parallax, scroolling;
    public float parallaxSpeed;
    public Transform goPlayer;

    private Transform cameraTransform;
    private Transform[] layers;
    private float viewZone = 4.4f;
    private int leftIndex;
    private int rightIndex;
    private float lastCameraX;

    private void Start()
    {
        cameraTransform = Camera.main.transform; //pega a posição da câmera principal
        lastCameraX = cameraTransform.position.x; //posição X inicial da câmera
        layers = new Transform[transform.childCount]; //a quantidade de filhos desse objeto ganha cada um uma posição no vetor

        for(int i = 0; i < transform.childCount; i++)
        {
            layers[i] = transform.GetChild(i); //escreve a possião dos filhos no vetor
        }
        leftIndex = 0; //define o primeiro BG da esquerda como sendo a posição 0
        rightIndex = layers.Length - 1; //define o BG final, pois o vetor começa em zero, e o childCount não
    }

    private void Update()
    {
        if (parallax)
        {
            float deltaX = cameraTransform.position.x - lastCameraX;
            transform.position += Vector3.right * (deltaX * parallaxSpeed);
        }
        lastCameraX = cameraTransform.position.x;
        transform.position =
                    new Vector3(transform.position.x , Mathf.Clamp(goPlayer.position.y, 3, 500), transform.position.z);
        if (scroolling)
        {
            if (cameraTransform.position.x < (layers[leftIndex].transform.position.x + viewZone))
            {
                ScrollLeft();
            }
            if (cameraTransform.position.x > (layers[rightIndex].transform.position.x - viewZone))
            {
                ScrollRight();
            }
        }
    }

    private void ScrollLeft()
    {
        int lastRight = rightIndex;
        layers[rightIndex].position = new Vector3((layers[leftIndex].position.x - backGroundSize), transform.position.y, transform.position.z);
        leftIndex = rightIndex;
        rightIndex--;
        if (rightIndex < 0)
        {
            rightIndex = layers.Length - 1;
        }
    }

    private void ScrollRight()
    {
        int lastLeft = leftIndex;
        layers[leftIndex].position = new Vector3((layers[rightIndex].position.x + backGroundSize), transform.position.y , transform.position.z);
        rightIndex = leftIndex;
        leftIndex++;
        if(leftIndex == layers.Length)
        {
            leftIndex = 0;
        }
    }
}

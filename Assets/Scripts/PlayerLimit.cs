﻿using UnityEngine;
using System.Collections;


public class PlayerLimit : MonoBehaviour
{
    
    public Material normal;
    public Material attack;

    private Vector3 startPos;
    private GameObject mainCamera;

    private Animator animator;
    private Renderer bodyRenderer;
   

    // Use this for initialization
    void Start()
    {
        mainCamera = GameObject.Find("Main Camera");
        startPos = transform.position;
        animator = GetComponent<Animator>();
        bodyRenderer = GameObject.Find("EthanBody").GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -30) // temp edit for Eart level
        {
            ResetLevel();
        }

        if (Input.GetKey(KeyCode.K)) {
            Debug.Log("ATTACK!!!");
            //animator.Play("Crouching");
            bodyRenderer.sharedMaterial = attack;
        } else {
            bodyRenderer.sharedMaterial = normal;
        }
    }

    public void ResetLevel()
    {
        transform.position = startPos;
        mainCamera.GetComponent<CameraFollow>().ResetCamera();
    }

    public void SetStartPos(Vector3 position)
    {
        startPos = position;
    }
}

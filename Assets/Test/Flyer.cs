using System;
using System.Collections;
using UnityEngine;
using Ammunition;
public class Flyer : MonoBehaviour
{
    [SerializeField] private float offsetMultiplier = 5f;
    [SerializeField] private int moveSpeed = 5;
    [SerializeField] private float timeDivisor = 2f;
    [SerializeField] private bool isRightPosition = true;
    [SerializeField] private Bomb bombToSpawn;
    [SerializeField] private Transform placeToSpawn;
    
    private Camera myCamera;

    private Bounds bounds;
    private Collider2D mesh;
    private float offset;
    private SpriteRenderer spriteRend;

    private Vector2 screenSize;
    
    private float timer;
    private float bombSpawnTime;

    public bool IsRightPosition
    {
        get => isRightPosition;
        set => isRightPosition = value;
    }

    private void Start()
    {
        myCamera = Camera.main;
        spriteRend = GetComponent<SpriteRenderer>();
        mesh = GetComponent<BoxCollider2D>();
        bounds = mesh.bounds;
        offset = bounds.size.x/offsetMultiplier;
        screenSize = GetScreenSize();
        bombSpawnTime = TravelTime(screenSize.x)/timeDivisor;
        if (isRightPosition) spriteRend.flipX = true;
    }
    
    private void Update()
    {
        //transform.position += Vector3.left * Time.deltaTime;
        if (isRightPosition)
        {
            transform.Translate(Vector3.left * (Time.deltaTime * moveSpeed));
        }
        else
        {
            transform.Translate(Vector3.right * (Time.deltaTime * moveSpeed));
        }

        BombSpawnTest();
    }

    private void BombSpawnTest()
    {
        timer += Time.deltaTime;
        if (!(Mathf.Abs(transform.position.x) + offset < screenSize.x)) return;
        SpawnBombs();
    }


    private void SpawnBombs()
    {
        if (!(timer >= bombSpawnTime)) return;
        Instantiate(bombToSpawn, placeToSpawn.transform.position, Quaternion.identity);
        timer = 0;
    }
    
    private float TravelTime(float currentScreenSize)
    {
        return (currentScreenSize * 2) / moveSpeed;
    }

    private Vector2 GetScreenSize()
    {
        return myCamera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }

    public void TestInput()
    {
        print("bam bam bam");
    }
}

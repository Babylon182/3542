﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsGenerator : MonoBehaviour
{
    public float starsHeight;
    public float asteroidsHeight;
    public float planetsHeight;
    public int offset;


    public int maxStars;
    public int maxAsteroids;
    public int maxQuads;

    int _starsRandomCode;
    int _asteroidsRandomCode;
    int _quadRandomCode;

    public List<GameObject> stars = new List<GameObject>();
    public List<GameObject> asteroids = new List<GameObject>();
    public List<GameObject> quads = new List<GameObject>();

    void Start()
    {
        GalaxyGenerator();
    }

    void GalaxyGenerator()
    {
        /////////////////////////////////STARS
        Vector3 starPos = new Vector3();

        for(int i = 0; i < maxStars; i++)
        {
            _starsRandomCode = (int)Random.Range(0,stars.Count);

            starPos = new Vector3(Random.Range(-Screen.width/2, Screen.width/2), 
                Random.Range(starsHeight + offset, starsHeight - offset), 
                Random.Range(gameObject.transform.position.z -Screen.height - 50, 
                gameObject.transform.position.z + Screen.height + 50));


            var currentStar = Instantiate(stars[_starsRandomCode], starPos, Quaternion.Euler(90,0, Random.Range(0, 350)));
            currentStar.transform.parent = gameObject.transform;
        }
        /////////////////////////////////ASTEROIDS
        Vector3 asteroidPos = new Vector3();

        for (int i = 0; i < maxAsteroids; i++)
        {
            _asteroidsRandomCode = (int)Random.Range(0, asteroids.Count);

            asteroidPos = new Vector3(Random.Range(-Screen.width / 2, Screen.width / 2),
                Random.Range(asteroidsHeight + offset, asteroidsHeight - offset),
                Random.Range(gameObject.transform.position.z - Screen.height - 50,
                gameObject.transform.position.z + Screen.height + 50));


            var currentStar = Instantiate(asteroids[_asteroidsRandomCode], asteroidPos, Quaternion.Euler(0,Random.Range(0,350),0));
            currentStar.transform.parent = gameObject.transform;
        }
        /////////////////////////////////QUADS
        Vector3 quadPos = new Vector3();

        for (int j = 0; j < maxQuads; j++)
        {
            _quadRandomCode = (int)Random.Range(0, quads.Count);

            quadPos = new Vector3(Random.Range(-Screen.width / 2, Screen.width/2),
                Random.Range (planetsHeight + offset, planetsHeight - offset), 
                Random.Range(gameObject.transform.position.z - Screen.height, 
                gameObject.transform.position.z + Screen.height));

            var currentStar = Instantiate(quads[_quadRandomCode], quadPos, Quaternion.Euler(Random.Range(0, 350), Random.Range(0, 350), Random.Range(0, 350)));
            currentStar.transform.parent = gameObject.transform;
        }
    }
}

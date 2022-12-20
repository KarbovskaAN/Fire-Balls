using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Player : MonoBehaviour
{
    private GameTapInput _ifTapInput;
    private GameObject _bullet;
    public Transform SpawnPoint;
    private Tower _tower;

    [SerializeField] private float _recoilDistance;
    [SerializeField] private float _delayBetweemShoots;
    
    private float BulletVelocity = 20f;


    public void SetGameTapInput(GameTapInput gameTapInput)
    {
        _ifTapInput = gameTapInput;
    }
    
    public void SetBullet(GameObject bullet)
    {
        _bullet = bullet;
    }
    
    public void SetTower(Tower tower)
    {
        _tower = tower;
    }

    private void Start()
    {
        startPosition = transform.position;
    }

    private TweenerCore<Vector3, Vector3, VectorOptions> a;
    private Vector3 startPosition;
    private void Update()
    {
        if (_ifTapInput.IfTap())
        {
            Shoot();
            
            if (a != null)
            {
                a.Kill();
            }
            
            a = transform.DOMoveX(transform.position.x - _recoilDistance, _delayBetweemShoots / 2)
                .OnComplete(() =>
                {
                    transform.DOMoveX(startPosition.x, _delayBetweemShoots / 2);
                });
        }
    }

    private void Shoot()
    {
        GameObject newbullet = Instantiate(_bullet , SpawnPoint.position , SpawnPoint.rotation);
        newbullet.GetComponent<Rigidbody>().velocity = transform.right * BulletVelocity;
        newbullet.GetComponent<Bullet>().SetTower(_tower);
    }















  

    























}

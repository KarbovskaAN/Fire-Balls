using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class Bootstrap : MonoBehaviour
{
    private int _amountFigure = 5;

    public GameObject _bulletPrefab;
    public GameObject _playerPrefab;
    public GameTapInput _gameTapInput; 
    public ObstacleRotate obstacleRotatePrefab;
    public Tower tower;
    public TowerBuild towerBuild; 
    [SerializeField] private TMP_Text _level;
    [SerializeField] private TMP_Text _amountFigur;
    
    [SerializeField] private Menu _settings;
    

    private void Start()
    {
       GameObject Player = Instantiate(_playerPrefab);
       Player PlayerScript = Player.GetComponent<Player>();
       PlayerScript.SetGameTapInput(_gameTapInput);
       PlayerScript.SetBullet(_bulletPrefab);
       PlayerScript.SetTower(tower);
       
       
       towerBuild.BuildTower(tower, _amountFigure + PlayerPrefs.GetInt("FigureAmount"));
       towerBuild.BuildObstacle(obstacleRotatePrefab);
       
       tower.CreatTower(_amountFigur);
       tower.UpDateText();

       
       _level.text = (PlayerPrefs.GetInt("Level") + 1).ToString();

       _settings.InitializeMenu();
       _settings.UpdateSound();
    }
    
}

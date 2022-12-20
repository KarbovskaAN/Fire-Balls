using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class TowerBuild : MonoBehaviour
{
    [SerializeField] private Transform _pointBuildFigure;
    [SerializeField] private Transform _pointBuildObstacle;
    [SerializeField] private Figure _figure;
    [SerializeField] private ObstacleRotate _obstacleRotate;
    [SerializeField] private Material _white;


    private Tower _Tower;
    private int _amountFigure;
    
    

    public void BuildTower(Tower figure, int amountFigure)
    {
        _Tower = figure;
        _amountFigure = amountFigure;
        Build();

    }
    private void Build()
    { 
        _Tower._figures = new List<Figure>();
        
        Transform currentPoint = _pointBuildFigure;

        for (int i = 0; i < _amountFigure ; i++)
        {
            Figure newFigure = BuildFigure(currentPoint);
            _Tower._figures.Add(newFigure);
            currentPoint = newFigure.transform;

            if (i % 2 == 0)
            {
                newFigure.GetComponentInChildren<Renderer>().material = _white;
            }
        }
        
        BuildObstacle(_obstacleRotate);
    }

    private Figure BuildFigure(Transform currentBuildPoint)
    {
        return Instantiate(_figure,GetBuildPoint(currentBuildPoint) , Quaternion.identity, _pointBuildFigure);
    }

    private Vector3 GetBuildPoint(Transform currentSegment)
    {
        return new (_pointBuildFigure.position.x , (currentSegment.position.y + _figure.transform.localScale.y)  , _pointBuildFigure.position.z );
    }

    public void BuildObstacle(ObstacleRotate obstacleRotate)
    {
       obstacleRotate =  Instantiate(_obstacleRotate, _pointBuildObstacle);
       _obstacleRotate.Rotate(obstacleRotate);
    }
 
    public void DeletPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

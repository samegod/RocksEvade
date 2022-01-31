using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    #region Fields

    [SerializeField] private SpawnerBorder leftBorder;
    [SerializeField] private SpawnerBorder rightBorder;
    [SerializeField] private float delay = 2f;

    private ObjectsPool<Asteroid> objectsPool;
    [SerializeField] private Asteroid asteroidPrefab;

    #endregion

    #region Unity Methods

    private void Awake()
    {
        objectsPool = new ObjectsPool<Asteroid>(asteroidPrefab, 10);
    }

    private void Start()
    {
        StartSpawning();
    }

    #endregion

    #region Public Methods

    public void StartSpawning()
    {
        StartCoroutine(SpawnLoop());
    }

    public void SpawnAsteroid()
    {
        float lerpT = Random.Range(0f, 1f);

        Vector2 newPosition = Vector2.Lerp(leftBorder.transform.position, rightBorder.transform.position, lerpT);
        float newAngle = Mathf.Lerp(leftBorder.MaxAngle, rightBorder.MaxAngle, lerpT);

        Asteroid asteroid = objectsPool.GetFreeElement(newPosition);
        asteroid.transform.position = newPosition;

        asteroid.SetSpeedByAngle(newAngle);
    }

    #endregion

    #region Private Methods

    private IEnumerator SpawnLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            SpawnAsteroid();
        }
    }

    #endregion
}

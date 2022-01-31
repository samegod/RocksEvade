using System.Collections.Generic;
using UnityEngine;

public class ObjectsPool<T> where T : MonoBehaviour
{
    #region Fields

    [SerializeField] private T _objectPrefab;
    [SerializeField] private bool _autoExpand = true;
    [SerializeField] private Transform _container = null;

    private int _count;

    private List<T> _pool;

    #endregion

    #region Public Methods

    public ObjectsPool(T objectPrefab, int count)
    {
        _objectPrefab = objectPrefab;
        _count = count;

        CreatePool();
    }

    public T GetFreeElement()
    {
        if (CheckFreeElements(out T element))
            return element;

        if (_autoExpand)
            return CreateObject(true);

        return null;
    }

    public T GetFreeElement(Transform targetPosition)
    {
        T element = GetFreeElement();

        if (element != null)
        {
            element.transform.position = targetPosition.position;
            element.transform.rotation = targetPosition.rotation;
            return element;
        }

        return null;
    }

    public T GetFreeElement(Vector2 targetPosition)
    {
        T element = GetFreeElement();

        if (element != null)
        {
            element.transform.position = targetPosition;
            return element;
        }

        return null;
    }

    public T[] GetAllElements()
    {
        return _pool.ToArray();
    }

    public int GetFreeElementsCount()
    {
        int count = 0;

        for (int i = 0; i < _count; i++)
        {
            if (!_pool[i].isActiveAndEnabled)
                count++;
        }
        return count;
    }

    #endregion

    #region Private Methods

    private void CreatePool()
    {
        _pool = new List<T>();

        for (int i = 0; i < _count; i++)
            _pool[i] = CreateObject();
    }

    private T CreateObject(bool isActiveByDefault = false)
    {
        var createdObject = Object.Instantiate(_objectPrefab);
        createdObject.gameObject.SetActive(isActiveByDefault);

        if (_container != null)
            createdObject.transform.parent = _container;

        _pool.Add(createdObject);
        return createdObject;
    }

    private bool CheckFreeElements(out T element)
    {
        foreach (T obj in _pool)
        {
            if (!obj.gameObject.activeInHierarchy)
            {
                element = obj;
                element.gameObject.SetActive(true);
                return true;
            }
        }

        element = null;
        return false;
    }

    #endregion
}

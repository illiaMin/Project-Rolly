using System.Collections.Generic;
using UnityEngine;

public class ProjectilesPool : MonoBehaviour
{
    [SerializeField] private Projectile _prefab;
    [SerializeField] private int _initialAmount = 50;
    [SerializeField] private bool _expandIfEmpty = true;

    private readonly Queue<Projectile> _pool = new Queue<Projectile>();

    private void Awake()
    {
        Prewarm();
    }

    private void Prewarm()
    {
        for (int i = 0; i < _initialAmount; i++)
        {
            Projectile projectile = CreateNew();
            Return(projectile);
        }
    }

    private Projectile CreateNew()
    {
        Projectile projectile = Instantiate(_prefab, transform);
        projectile.gameObject.SetActive(false);
        return projectile;
    }

    public bool TryGet(out Projectile projectile)
    {
        if (_pool.Count > 0)
        {
            projectile = _pool.Dequeue();
            projectile.gameObject.SetActive(true);
            return true;
        }

        if (_expandIfEmpty)
        {
            projectile = CreateNew();
            projectile.gameObject.SetActive(true);
            return true;
        }

        projectile = null;
        return false;
    }

    public void Return(Projectile projectile)
    {
        projectile.ResetState(); 
        projectile.gameObject.SetActive(false);
        _pool.Enqueue(projectile);
    }
}
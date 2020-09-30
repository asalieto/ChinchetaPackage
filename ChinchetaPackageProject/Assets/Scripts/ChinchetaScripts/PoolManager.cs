using UnityEngine;
using System;
using System.Collections.Generic;

namespace ChinchetaGames
{
    [Serializable]
    public class PoolManager : Singleton<PoolManager>
    {
        public override void Awake()
        {
            base.Awake();

            for (int i = 0; i < m_pools.Count; i++)
            {
                Pool pool = m_pools[i];
                pool.PreloadInstances(transform);
                if (pool.Prefab)
                {
                    m_prefabPools.Add(pool.Prefab, pool);
                }
            }
        }

        public void ReloadPrefabs()
        {
            m_prefabPools.Clear();

            for (int i = 0; i < m_pools.Count; i++)
            {
                Pool pool = m_pools[i];
                pool.PreloadInstances(transform);
                if (pool.Prefab)
                {
                    m_prefabPools.Add(pool.Prefab, pool);
                }
            }

        }

        public GameObject Spawn(string objectName)
        {
            for (int i = 0; i < m_pools.Count; i++)
            {
                Pool pool = m_pools[i];
                if (pool.Prefab.name == objectName)
                {
                    return pool.Spawn();
                }
            }

            return null;
        }

        public GameObject Spawn(GameObject prefab)
        {
            if (m_prefabPools.ContainsKey(prefab))
            {
                return m_prefabPools[prefab].Spawn();
            }

            return null;
        }

        public void Despawn(GameObject spawnedObject)
        {
            for (int i = 0; i < m_pools.Count; i++)
            {
                Pool pool = m_pools[i];
                if (pool.Contains(spawnedObject))
                {
                    pool.Despawn(spawnedObject);
                    return;
                }
            }
        }

        [SerializeField]
        private List<Pool> m_pools = new List<Pool>();

        private Dictionary<GameObject, Pool> m_prefabPools = new Dictionary<GameObject, Pool>();
    }
}
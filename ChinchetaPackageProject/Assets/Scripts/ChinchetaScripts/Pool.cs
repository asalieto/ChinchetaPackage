using UnityEngine;
using System;
using System.Collections.Generic;

namespace ChinchetaGames
{
    [Serializable]
    public class Pool
    {
        public GameObject Prefab => m_prefab;

        private class Instance
        {
            public GameObject go;
            public bool spawned;

            public Instance(GameObject i)
            {
                spawned = false;
                go = i;
            }
        }

        private void CreateRoot()
        {
            if (!m_root)
            {
                m_root = new GameObject(ToString());

                if (m_parent)
                {
                    m_root.transform.parent = m_parent;
                }
            }
        }

        private Instance CreateInstance()
        {
            GameObject go = GameObject.Instantiate(Prefab) as GameObject;
            go.name = Prefab.name + "_" + m_instances.Count;
            Instance instance = new Instance(go);
            m_instances.Add(instance);
            m_gameObjectToInstance.Add(go, instance);

            Despawn(go);

            return instance;
        }

        public void PreloadInstances(Transform parent)
        {
            m_parent = parent;
            CreateRoot();

            m_instances.Clear();
            m_gameObjectToInstance.Clear();

            if (Prefab && m_amount > 0)
            {
                for (int i = 0; i < m_amount; ++i)
                {
                    CreateInstance();
                }
            }
        }

        public GameObject Spawn()
        {
            Instance instance = null;

            for (int i = 0; i < m_instances.Count; i++)
            {
                Instance inst = m_instances[i];
                if (!inst.spawned)
                {
                    instance = inst;
                    break;
                }
            }

            if (instance == null)
            {
                instance = CreateInstance();
            }

            GameObject spawnedObject = instance.go;
            instance.spawned = true;

            spawnedObject.SetActive(true);
            spawnedObject.transform.SetParent(null);
            spawnedObject.transform.localPosition = Vector3.zero;
            spawnedObject.transform.localRotation = Quaternion.identity;
            spawnedObject.transform.localScale = Vector3.one;

            spawnedObject.SendMessage("OnSpawn", SendMessageOptions.DontRequireReceiver);

            return spawnedObject;
        }

        public void Despawn(GameObject spawnedObject)
        {
            if (m_gameObjectToInstance.ContainsKey(spawnedObject))
            {
                if (m_gameObjectToInstance[spawnedObject].spawned)
                {
                    spawnedObject.SendMessage("OnDespawn", SendMessageOptions.DontRequireReceiver);
                }

                m_gameObjectToInstance[spawnedObject].spawned = false;
                spawnedObject.SetActive(false);
                spawnedObject.transform.SetParent(m_root.transform);
                spawnedObject.transform.rotation = Quaternion.identity;
                spawnedObject.transform.position = Vector3.zero;
                spawnedObject.transform.localScale = Vector3.one;
            }
        }

        public bool IsSpawned(GameObject go)
        {
            if (Contains(go))
            {
                return m_gameObjectToInstance[go].spawned;
            }

            return false;
        }

        public bool Contains(GameObject spawnedObject)
        {
            return m_gameObjectToInstance.ContainsKey(spawnedObject);
        }

        override public string ToString()
        {
            if (Prefab)
            {
                return Prefab.name;
            }

            return "pool";
        }

        [SerializeField]
        private GameObject m_prefab;
        [SerializeField]
        private int m_amount;

        private GameObject m_root;
        private Transform m_parent;

        private List<Instance> m_instances = new List<Instance>();
        private Dictionary<GameObject, Instance> m_gameObjectToInstance = new Dictionary<GameObject, Instance>();
    }
}
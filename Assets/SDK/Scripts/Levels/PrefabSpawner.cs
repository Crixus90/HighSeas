﻿using UnityEngine;
using UnityEngine.AddressableAssets;
using System;

#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#else
using EasyButtons;
#endif

namespace ThunderRoad
{
    [AddComponentMenu("ThunderRoad/Levels/Spawners/Prefab Spawner")]
    public class PrefabSpawner : MonoBehaviour
    {
        public string address;
        public bool spawnOnStart = true;
        public Plateform plateform = Plateform.Android | Plateform.Windows;

        [Flags]
        public enum Plateform
        {
            Windows = 1,
            Android = 2,
        }

        protected void Start()
        {
            if (spawnOnStart)
            {
                Spawn();
            }
        }

        [Button]
        public void Spawn()
        {
            if ((Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer) && plateform.HasFlag(Plateform.Windows))
            {
                Addressables.InstantiateAsync(address, this.transform.position, this.transform.rotation, this.transform);
            }
            else if (Application.platform == RuntimePlatform.Android && plateform.HasFlag(Plateform.Android))
            {
                Addressables.InstantiateAsync(address, this.transform.position, this.transform.rotation, this.transform);
            }
        }
    }
}

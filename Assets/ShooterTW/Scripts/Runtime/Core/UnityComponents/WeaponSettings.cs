using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Client
{
    public class WeaponSettings : MonoBehaviour
    {
        public GameObject projectilePrefab;
        public Transform projectileSocket;
        public int weaponDamage;
        public float projectileSpeed;
        public float projectileRadius;
        public float projectileLifetime;
    };
}

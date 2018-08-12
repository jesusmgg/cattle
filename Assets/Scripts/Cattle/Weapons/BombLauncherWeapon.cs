﻿using UnityEngine;

namespace Cattle.Weapons
{
    public class BombLauncherWeapon : BaseWeapon
    {
        [Header("Bomb Launcher")]
        public GameObject fakeBomb;

        SpriteRenderer fakeBombSpriteRenderer;

        protected override void Awake()
        {
            base.Awake();

            fakeBombSpriteRenderer = fakeBomb.GetComponent<SpriteRenderer>();
        }

        protected override void Update()
        {
            base.Update();

            fakeBombSpriteRenderer.color = canShoot ? Color.white : Color.clear;
        }

        protected override void InstantiateProjectile()
        {
            base.InstantiateProjectile();
            
            GameObject projectile = Instantiate(projectilePrefab.gameObject, fakeBomb.transform.position, fakeBomb.transform.rotation);
            projectile.GetComponent<SpriteRenderer>().flipX = fakeBombSpriteRenderer.flipX;
            
            projectile.transform.parent = null;
            projectile.GetComponent<BaseProjectile>().initialSpeedMultiplier = shootSpeed;
        }
    }
}
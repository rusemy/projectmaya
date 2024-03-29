using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRocketLauncher : WeaponBase
{
    protected override void Update()
    {
        base.Update();

        if (magazineRemaning <= 0 && !recharging)
        {
            Reload();
        }
    }

    public override void Shoot()
    {
        if (timerToShoot < 0 && magazineRemaning > 0)
        {
            shootingParticle.Play();
            var projectile = pool.Get();
            projectile.direction = aimDirection;
            magazineRemaning--;
            timerToShoot = shootingSpeed;
        }
    }
}

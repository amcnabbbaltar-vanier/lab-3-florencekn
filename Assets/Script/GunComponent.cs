using UnityEngine;

public class GunComponent : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float bulletMaxImpulse = 10.0f;
    public float maxChargeTime = 3.0f;
    private float chargeTime = 0.0f;
    private bool isCharging = false;

   
   void Update()
   { 
        if(Input.GetButtonDown("Fire1"))
        {
            //When a player first press down the button the chargetime should reset to 0.
            chargeTime = 0.0f;
            isCharging = true;
        }

        if(Input.GetButton("Fire1"))
        {
            chargeTime += Time.deltaTime;
            chargeTime = Mathf.Clamp(chargeTime, 0, maxChargeTime);
        }

        // TODO: add the logic to track player keeping the input down
        if(Input.GetButtonUp("Fire1"))
        {
            ShootBullet();
            isCharging = false;
        }
         
   }

   void ShootBullet()
   {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        // TODO change that equation so that it adds an impulse that follows charge time
        // float bulletImpulse = bulletMaxImpulse;
        float bulletImpulse = (chargeTime / maxChargeTime) * bulletMaxImpulse;
        
        // An impulse is force you apply on a obj in a single instant
        rb.AddForce(bulletSpawnPoint.forward * bulletImpulse, ForceMode.Impulse);
   }
}

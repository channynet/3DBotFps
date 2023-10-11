using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public float camShake;
    public float damage;
    public Transform bulletSpawn;
    public GameObject Owner;
    public TrailRenderer BulletTrail;
    public ParticleSystem ShootParticle;
    public ParticleSystem ImpactParticle;
    private float LastShootTime;
    public bool AddBulletSpread;
    public Vector3 BulletSpreadVariance;
    public Transform WeaponPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Fire();
        }
    }
    private void FixedUpdate()
    {
        transform.position = WeaponPosition.position;
        transform.rotation = WeaponPosition.rotation;

    }

    void Fire()
    {
        Vector3 direction = GetDirection();
        if(Physics.Raycast(bulletSpawn.position, direction, out RaycastHit hit, float.MaxValue))
        {
            TrailRenderer trail = Instantiate(BulletTrail, bulletSpawn.position, Quaternion.identity);

            StartCoroutine(spawnTrail(trail,hit));
            LastShootTime = Time.time;
        }
    }
    private Vector3 GetDirection()
    {
        Vector3 direction = transform.forward;
        if (AddBulletSpread)
        {
            direction += new Vector3(Random.Range(-BulletSpreadVariance.x, BulletSpreadVariance.x), Random.Range(-BulletSpreadVariance.y, BulletSpreadVariance.y), Random.Range(-BulletSpreadVariance.z, BulletSpreadVariance.z));
            direction.Normalize();
        }
        return direction;
    }

    private IEnumerator spawnTrail(TrailRenderer Trail, RaycastHit hit)
    {
        float time = 0;
        Vector3 startPosition = Trail.transform.position;
        while(time < 1)
        {
            Trail.transform.position = Vector3.Lerp(startPosition, hit.point, time);
            time += Time.deltaTime / Trail.time;
            yield return null;
        }
        Trail.transform.position = hit.point;
        Instantiate(ImpactParticle, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(Trail.gameObject, Trail.time);
    }
}

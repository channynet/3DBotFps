using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponManager : WeaponManager
{
    public GameObject player;
    private PlayerController playerController;
    public bool autoFire;
    public Vector3 CamsShake;
    private Transform WeaponPosition;
    public Vector3 WeaponShakeness;
    // Start is called before the first frame update
    void Start()
    {
        playerController = player.GetComponent<PlayerController>();
        Owner = player;
        WeaponPosition = playerController.WeaponPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (autoFire)
        {
            if (Input.GetMouseButton(0))
            {
                Fire();
                playerController.camShake(CamsShake);
                WeaponShake();
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                Fire();
                playerController.camShake(CamsShake);
                WeaponShake();
            }
        }
        
    }
    private void FixedUpdate()
    {
        transform.position = WeaponPosition.position;
        transform.rotation = WeaponPosition.rotation;
    }
    private void WeaponShake()
    {
        transform.position += new Vector3(Random.Range(-WeaponShakeness.x, WeaponShakeness.x), Random.Range(-WeaponShakeness.y, WeaponShakeness.y), Random.Range(-WeaponShakeness.z, WeaponShakeness.z));
    }
}

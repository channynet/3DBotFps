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
                //playerController.camShake(CamsShake);
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                Fire();
                //playerController.camShake(CamsShake);
            }
        }
        
    }
    private void FixedUpdate()
    {
        transform.position = WeaponPosition.position;
        transform.rotation = WeaponPosition.rotation;
    }

}

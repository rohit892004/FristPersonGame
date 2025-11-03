using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerShoting : MonoBehaviour
{
    [Header("BulletData")]
    public Transform FirePoint;
    public GameObject Bullet;
    public float timebetweenshot;
    private bool canShoot = true;

    [Header("BulletData")]
    public int TotalBullet = 10;
    public int RemainigBullet;
    // Start is called before the first frame update
    public GameObject muzzle;
    void Start()
    {
        RemainigBullet = TotalBullet;
        UIController.instance.ammmoText.text = "Ammo :" + RemainigBullet;
        muzzle.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        FireBullet();
        
    }

    void FireBullet()
    {
      
        
        if (Input.GetMouseButtonDown(0)&& canShoot && RemainigBullet >0 )
        {

            Instantiate(Bullet, FirePoint.position, FirePoint.rotation);
            AudioManager.instance.PlaySFX(5);
           
            StartCoroutine(ShootDealy()) ;
            StartCoroutine(muzzleflase());
            RemainigBullet--;
            UIController.instance.ammmoText.text = "Ammo :" + RemainigBullet;
        }
    }

    IEnumerator ShootDealy()
    {
        canShoot = false;
        yield return new WaitForSeconds(timebetweenshot);
        canShoot  = true;

    }
    IEnumerator muzzleflase()
    {
        muzzle.SetActive(true);
        yield return new WaitForSeconds(timebetweenshot);
        muzzle.SetActive(false);
    }
    public void Addbullet(int bulletamount)
    {
        RemainigBullet += bulletamount;
        UIController.instance.ammmoText.text = "Ammo :" + RemainigBullet;

    }

}

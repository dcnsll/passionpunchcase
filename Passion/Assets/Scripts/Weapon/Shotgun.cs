using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    private int bulletCount;
    public float spreadAngle;
    public float bulletSpeed;
    public GameObject bulletPrefab;
    public Transform exit;
    List<Quaternion> bullets;
    public int shotsMade;
    private Animator anim;

    #region Singleton
    public static Shotgun instance = null;
    private void Awake()
    {
        anim = GetComponent<Animator>();


        if (instance == null)
        {
            instance = this;
        }
    }
    #endregion



    void Update()
    {
        bulletCount = Random.Range(6, 10);

        bullets = new List<Quaternion>(new Quaternion[bulletCount]);

        if (UIController.instance.isOpen==false)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Fire();
            }

        }
    }

    void Fire()
    {
        anim.SetTrigger("Shot");
        int i = 0;
        GameObject p = new GameObject();
        foreach (Quaternion item in bullets.ToArray())
        {
            bullets[i] = Random.rotation;
            p = (GameObject)Instantiate(bulletPrefab, exit.position, exit.rotation) as GameObject;
            shotsMade++;
            Destroy(p, 1f);
            p.transform.rotation = Quaternion.RotateTowards(p.transform.rotation, bullets[i], spreadAngle);
            p.GetComponent<Rigidbody>().AddForce(p.transform.right * -1 * bulletSpeed);
            i++;
        }
    }



}

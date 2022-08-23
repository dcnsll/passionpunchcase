using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class Bullet : MonoBehaviour
{
    [SerializeField] private Material myMaterial;

    public float explodeAfter = 1;
    private bool hasStartedExplode;
    private bool hasCollided;
    public Transform explosionPrefab;
    public float force = 5000f;
    public float radius = 50.0F;
    public float power = 250.0F;
    public float destroyDelay;

    public int DamageAmount = 100;


   IEnumerator KillItSelf()
    {
        yield return new WaitForSeconds(5f);
        Destroy(this.gameObject);
            
    }
  

    private IEnumerator ExplodeSelf()
    {
        
        yield return new WaitForSeconds(explodeAfter);
       
        
            Instantiate(explosionPrefab, transform.position, transform.rotation);
        


        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        gameObject.GetComponent<BoxCollider>().isTrigger = true;



        
        yield return new WaitForSeconds(destroyDelay);
        
        Destroy(gameObject);
    }

    void Start()
    {
        StartCoroutine(KillItSelf());


        if (GameManager.instance.isRed == true)
        {
            myMaterial.color = Color.red;
        }
        else
        {
            myMaterial.color = Color.white;
        }

        if (GameManager.instance.isBig == true)
        {
            this.gameObject.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
        }
        else
        {
            this.gameObject.transform.localScale += new Vector3(0.060219f, 0.060219f, 0.060219f);
        }

        if (GameManager.instance.isBang==true)
        {
            StartCoroutine(ExplodeSelf());
        }
        else
        {
            StopCoroutine(ExplodeSelf());
        }
    }


}

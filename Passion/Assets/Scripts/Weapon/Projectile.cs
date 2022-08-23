

using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;


	public class Projectile : MonoBehaviour
	{
		public int DamageAmount = 10;
		[Range(5, 100)]
		
		public float destroyAfter;

	
		public bool destroyOnImpact = false;

		
		public float minDestroyTime;

		
		public float maxDestroyTime;

		
		public Transform[] bloodImpactPrefabs;

		public Transform[] floorImpactPrefabs;
	

		private void Start()
		{
			

			
			StartCoroutine(DestroyAfter());
		}

		
		private void OnCollisionEnter(Collision collision)
		{
			
			if (collision.gameObject.GetComponent<Projectile>() != null)
				return;

		
			if (!destroyOnImpact)
			{
				StartCoroutine(DestroyTimer());
			}
			//Otherwise, destroy bullet on impact
			else
			{
				Destroy(gameObject);
			}


			if (collision.gameObject.CompareTag("Respawn"))
			{

				if (collision.gameObject.GetComponent<EmeraldAI.EmeraldAISystem>() != null)
				{
					Instantiate(bloodImpactPrefabs[Random.Range
						(0, bloodImpactPrefabs.Length)], transform.position,
					Quaternion.LookRotation(collision.contacts[0].normal));
					collision.gameObject.GetComponent<EmeraldAI.EmeraldAISystem>().Damage(DamageAmount, EmeraldAI.EmeraldAISystem.TargetType.Player, transform, 200);
					Destroy(this.gameObject);
				}

			}


			
			if (collision.transform.tag == "Blood")
			{
				
				Instantiate(bloodImpactPrefabs[Random.Range
						(0, bloodImpactPrefabs.Length)], transform.position,
					Quaternion.LookRotation(collision.contacts[0].normal));
				
				Destroy(gameObject);
			}

			
			if (collision.transform.tag == "Floor")
			{
				
				Instantiate(floorImpactPrefabs[Random.Range
						(0, bloodImpactPrefabs.Length)], transform.position,
					Quaternion.LookRotation(collision.contacts[0].normal));
				
				Destroy(gameObject);
			}

		
		}

		private IEnumerator DestroyTimer()
		{
			
			yield return new WaitForSeconds
				(Random.Range(minDestroyTime, maxDestroyTime));
			Destroy(gameObject);
		}

		private IEnumerator DestroyAfter()
		{
			
			yield return new WaitForSeconds(destroyAfter);
			Destroy(gameObject);
		}
	}

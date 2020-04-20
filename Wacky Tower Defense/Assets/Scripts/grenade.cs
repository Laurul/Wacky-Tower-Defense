using UnityEngine;

public class grenade : MonoBehaviour
{
    [SerializeField] float timer = 3.0f;
   // [SerializeField] GameObject explosionParticleEffect;
    [SerializeField] float blastRadius = 5.0f;
    [SerializeField] float blastForce = 500.0f;
    GameObject s;
    float coutndown;
    bool exploded = false;
   

    // Start is called before the first frame update
    void Start()
    {
        coutndown = timer;
    }

    // Update is called once per frame
    void Update()
    {
        coutndown -= Time.deltaTime;
        if (coutndown <= 0 && exploded == false)
        {
            BitesDeDust();
            exploded = true;
            
        }
       
    }

    void BitesDeDust()
    {

        Debug.Log("KIller Queen first bomb!");

      //  s = Instantiate(explosionParticleEffect, transform.position, transform.rotation);


       // s.SetActive(true);
        
        Collider[] colliders = Physics.OverlapSphere(transform.position, blastRadius);
        foreach (Collider obj in colliders)
        {
            Rigidbody rb = obj.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(blastForce, transform.position, blastRadius); ;
            }

        }

        Destroy(gameObject);
      

    }
}

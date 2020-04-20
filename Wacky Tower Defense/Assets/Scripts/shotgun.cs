using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;


public class shotgun : MonoBehaviour
{
    [SerializeField] LineRenderer hookRenderer;
    [SerializeField] GameObject pellet;
    [SerializeField] int pelletCount = 24;
    [SerializeField] float pelletVelocity=1.0f;
    [SerializeField] float spreadAngle=15.0f;
    [SerializeField] Transform barrelEnd;
    [SerializeField] float shootTimer = 1.0f;
    [SerializeField] float hookDistance=20.0f;
    [SerializeField] float hookPullSpeed = 5.0f;
    [SerializeField] GameObject player;
    [SerializeField] CheckShells magazine;
    private OVRGrabbable ovrGrabbable;
    private int currentAmmo;
    private bool canIncrease;
    [SerializeField] int maxAmmo;
    [SerializeField] OVRInput.Button shootButton;
    [SerializeField] OVRInput.Button hookButton;
    float step;
    float hookMomentum;
    RaycastHit hit;
    bool isAttached = false;
    List<Quaternion> pellets;
    bool canFire = true;
   
    float countdown;
    // Start is called before the first frame update
    void Awake()
    {
        ovrGrabbable = GetComponent<OVRGrabbable>();
        pellets = new List<Quaternion>(pelletCount);
        countdown = shootTimer;
        for (int i = 0; i < pelletCount; i++)
        {
            pellets.Add(Quaternion.Euler(Vector3.zero));
        }
        currentAmmo = 6;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(currentAmmo);
        canIncrease = magazine.returnRightAmmo();
        if (currentAmmo > maxAmmo)
        {
            currentAmmo = maxAmmo;
        }
        if (currentAmmo == maxAmmo)
        {
            canIncrease = false;
        }
        if (canIncrease == true&& currentAmmo < maxAmmo)
        {
            currentAmmo++;
            magazine.setRight(false);

        }


        if (ovrGrabbable.isGrabbed&&OVRInput.GetDown(shootButton,ovrGrabbable.grabbedBy.GetController()))
        {
            if (canFire == true&&currentAmmo>0)
            {
                countdown = shootTimer;
                FireShotgun();
                canFire = false;

            }
          
        }

        
        if (ovrGrabbable.isGrabbed && OVRInput.GetDown(hookButton, ovrGrabbable.grabbedBy.GetController()))
        {
            if(Physics.Raycast(gameObject.transform.position, player.transform.forward, out hit,hookDistance))
            {
               // if (hit.transform.tag == "hit")
                {
                    isAttached = true;
                    hookRenderer.enabled = true;
                    hookRenderer.SetPosition(0, gameObject.transform.position);
                    hookRenderer.SetPosition(1, hit.point);
                }
               
               
            }
        }
        if (ovrGrabbable.isGrabbed && OVRInput.GetUp(hookButton, ovrGrabbable.grabbedBy.GetController()))
        {
            isAttached = false;
            hookRenderer.enabled = false;
        }
        if (canFire == false)
        {
            AllowedToFire();
           
        }
        if (isAttached == true)
        {
            hookMomentum += hookPullSpeed * Time.deltaTime;
            step = hookMomentum * Time.deltaTime;
            hit.transform.position = Vector3.MoveTowards(hit.transform.position, transform.position, step);
        }
    }

    void FireShotgun()
    {
        isAttached = false;
        currentAmmo--;

        for (int i = 0; i < pelletCount; i++)
        {
            pellets[i] = Random.rotation;
            GameObject p = Instantiate(pellet, barrelEnd.position, barrelEnd.rotation);
            p.transform.rotation = Quaternion.RotateTowards(p.transform.rotation, pellets[i], spreadAngle);
            p.GetComponent<Rigidbody>().AddForce(p.transform.right * pelletVelocity);
            
        }
    }
    void AllowedToFire()
    {
        
        countdown -= Time.deltaTime;
        if (countdown <= 0)
        {
            canFire = true;
        }
       
    }
     public void SetCurrentAmmo(int ammo)
    {
        currentAmmo = ammo;
    }

    public int ReturnCurrentAmmo()
    {
        return currentAmmo;
    }

    public int ReturnMaxAmmo()
    {
        return maxAmmo;
    }
    
}

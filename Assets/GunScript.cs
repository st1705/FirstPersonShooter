using UnityEngine;
using UnityEngine.Audio;

public class GunScript : MonoBehaviour
{
    [Header("Gun Stats")]

    public float damage = 10f;
    public float range = 100f;

    [Space]

    [Header("Unity Setup")]

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject hitEffect;
    public AudioSource gun;

    [Space]

    [Header("Audio")]

    public AudioClip[] shots;
    public AudioClip reload;

    private void Update()
    {
        //Shooting button
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        //Visuals
        muzzleFlash.Play();

        //Get random shot clip and set to audiosource
        gun.clip = shots[Random.Range(0, shots.Length)];
        gun.Play();

        //Shooting raycast
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            //Check if shooted object is a target
            TargetScript target = hit.transform.GetComponent<TargetScript>();
            if (target != null)
            {
                //Give damage to target
                target.TakeDamage(damage);
            }

            //Rigidbody rb = hit.transform.GetComponent<Rigidbody>();
            //if(rb != null)
            //{
            //    //give force to object
            //    rb.AddForce();
            //}


            //make impact
            Destroy(Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal)), 5f);
        }
    }
}

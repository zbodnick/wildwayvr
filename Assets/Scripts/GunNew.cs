using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunNew : MonoBehaviour
{
    public int maxammo = 3;
    private int currentammo;

    public GameObject bulletPrefab;
    public GameObject casingPrefab;
    public GameObject muzzleFlashPrefab;
    public Transform barrelLocation;
    public Transform casingExitLocation;

    public AudioSource source;
    public AudioClip fire;
    public AudioClip reload;
    public AudioClip noammo;

    public float shotPower = 100f;

    void Start() {
        if (barrelLocation == null)
            barrelLocation = transform;

        Reload();
    }

    void Reload() {
        currentammo = maxammo;
        source.PlayOneShot(reload);
    }

    void Update()
    {

        if (Vector3.Angle(transform.up, Vector3.up) > 100 && currentammo < maxammo) {
            Reload();
        }

    }

    public void Shoot() {

        if (currentammo == 0) {
            // source.PlayOneShot(noammo);
        } else {
            currentammo--;
            GetComponent<Animator>().SetTrigger("Fire");
    
            source.PlayOneShot(fire);

            GameObject tempFlash;
            
            Instantiate(bulletPrefab, barrelLocation.position, barrelLocation.rotation).GetComponent<Rigidbody>().AddForce(barrelLocation.forward * shotPower, ForceMode.VelocityChange);
            tempFlash = Instantiate(muzzleFlashPrefab, barrelLocation.position, barrelLocation.rotation);

            RaycastHit hitInfo;
            bool hasHit = Physics.Raycast(barrelLocation.position, barrelLocation.forward, out hitInfo, 100);

            if (hasHit) {
                hitInfo.collider.SendMessageUpwards("Dead", hitInfo.point, SendMessageOptions.DontRequireReceiver);
            }

            Destroy(tempFlash, 0.5f);
            // Instantiate(casingPrefab, casingExitLocation.position, casingExitLocation.rotation).GetComponent<Rigidbody>().AddForce(casingExitLocation.right * 100f);
            CasingRelease();
            // Destroy(bulletPrefab, 10f);
        }
    }

    void CasingRelease() {
        GameObject casing;
        casing = Instantiate(casingPrefab, casingExitLocation.position, casingExitLocation.rotation) as GameObject;
        casing.GetComponent<Rigidbody>().AddExplosionForce(550f, (casingExitLocation.position - casingExitLocation.right * 0.3f - casingExitLocation.up * 0.6f), 1f);
        casing.GetComponent<Rigidbody>().AddTorque(new Vector3(0, Random.Range(100f, 500f), Random.Range(10f, 1000f)), ForceMode.Impulse);
        Destroy(casing, 0.5f);
    }


}
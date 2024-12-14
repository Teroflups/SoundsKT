using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float offset;
    [SerializeField] private float coolDown;
    private bool inCD = true;

    [SerializeField] private AudioSource shootSourñe;
    
    private Vector3 mouse1;
   

    
    void Update()
    {
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(mouse.y, mouse.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

        mouse1 = mouse;
        mouse1.Normalize();
        shootSourñe.panStereo = mouse1.x;
        
        if (Input.GetMouseButton(0) && inCD )
        {
            Instantiate(bullet, transform.position, transform.rotation);
            StartCoroutine(CDBetweenFire());
            shootSourñe.Play();
        }
    }
    private IEnumerator CDBetweenFire()
    {
        inCD = false;
        yield return new WaitForSeconds(coolDown);
        inCD = true;
    }
}

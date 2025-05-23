using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    public GameObject projectile;
    public float cooldown;
    private bool canThrow;
    public int cost;

    public GameObject range;
    public GameObject visibleRange;

    public PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        canThrow = true;
        visibleRange.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Throw(GameObject snake)
    {
        if (canThrow)
        {
            canThrow = false;
            Vector3 direction = snake.transform.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(Vector3.forward, direction);
            GameObject Createdprojectile = Instantiate(projectile, transform.position, rotation, transform);
            Createdprojectile.GetComponent<Projectile>().direction = direction.normalized;
            yield return new WaitForSeconds(cooldown);
            canThrow = true ;
        }
        yield return null;
    }




    
    public void ShowRange(bool flag)
    {
        visibleRange.SetActive(flag);
    }
    
}

using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;

public class TowerController : MonoBehaviour
{
    //tower id
    public readonly int id = 0;

    public GameObject projectile;
    public float cooldown;
    private bool canThrow;
    public int cost;

    public GameObject range;
    public GameObject visibleRange;

    public GameObject playerController;
    public int damageCount;

    public GameObject Canvas;
    public int[] upgrades = {0, 0, 0};
    public int upgradeLimit = 2;
    // Start is called before the first frame update
    void Start()
    {
        canThrow = true;
        visibleRange.SetActive(false);
        damageCount = 0;
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
    public void Upgrade(int upgradePath)
    {
        if (upgrades[upgradePath - 1] + 1 <= upgradeLimit)
        {
            upgrades[upgradePath - 1]++;

            //trying to get the "Upgrade Panel" Script from the upgrade panel child
            Canvas.GetComponentInChildren<UpgradePanel>().UpdateButtons();
            updateTower();
        }
    }
    


    
    public void ShowRange(bool flag)
    {
        visibleRange.SetActive(flag);
    }


    public void updateTower()
    {
        //Range
        if (upgrades[0] == 0)
        {
            range.gameObject.GetComponent<CircleCollider2D>().radius = 3;
            visibleRange.transform.localScale = new Vector3(6, 6, 1);
        }
        if (upgrades[0] == 1)
        {
            range.gameObject.GetComponent<CircleCollider2D>().radius = 4;
            visibleRange.transform.localScale = new Vector3(8, 8, 1);

        }
        if (upgrades[0] == 2)
        {
            range.gameObject.GetComponent<CircleCollider2D>().radius = 5;
            visibleRange.transform.localScale = new Vector3(10, 10, 1);

        }

        //Cooldown
        if (upgrades[1] == 0)
        {
            cooldown = 2;
        }
        if (upgrades[1] == 1)
        {
            cooldown = 1.5f;

        }
        if (upgrades[1] == 2)
        {
            cooldown = 1;

        }

        //Damage
        if (upgrades[2] == 0)
        {
            projectile.GetComponent<Projectile>().damage = 1;
        }
        if (upgrades[2] == 1)
        {
            projectile.GetComponent<Projectile>().damage = 2;

        }
        if (upgrades[2] == 2)
        {
            projectile.GetComponent<Projectile>().damage = 3;

        }
    }
}

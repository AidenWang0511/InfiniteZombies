using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : SpawnEnemies
{
    public float HP;
    private float curHP;

    // Start is called before the first frame update
    void Start()
    {
        //curEnemy = enemyCount;
        //Debug.Log(curEnemy);
        curHP = HP;
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            curHP = curHP - 1f;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (curHP <= 0)
        {
            curEnemy = curEnemy-1;
            //Debug.Log(curEnemy);
            Destroy(this.gameObject);
            
        }
    }
}

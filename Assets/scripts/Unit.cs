using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
public string unitName;
public int damage;
public int maxHP;
public int currentHp;

public bool Takedamage(int dmg)
{
    currentHp -= dmg;

    if (currentHp <= 0)
       return true;
    else 
       return false;
}

public void Heal(int amount)
{
   currentHp += amount;
   if(currentHp > maxHP);
   currentHp = maxHP;  
}

}

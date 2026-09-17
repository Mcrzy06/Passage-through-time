using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public enum BattleState { START, PLAYERTURN, CHASERTURN, WIN, LOSE }

public class BattleSystem : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject chaserPrefab;

    public Transform PlayerBattleArea;
    public Transform ChaserBattleArea;
    public BattleState state;
    Unit playerUnit;
    Unit chaserUnit;

    public BattleHud playerHud;
    public BattleHud chaserHud;

    public Text dialogueText;

    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SetupBattle()
    {
        GameObject PlayerOB = Instantiate(playerPrefab, PlayerBattleArea);
        playerUnit = PlayerOB.GetComponent<Unit>();

        GameObject ChaserOB = Instantiate(chaserPrefab, ChaserBattleArea);
        chaserUnit = ChaserOB.GetComponent<Unit>();

        dialogueText.text = "The " + chaserUnit.unitName + " caught you";

        playerHud.SetHud(playerUnit);
        chaserHud.SetHud(chaserUnit);

        yield return new WaitForSeconds(5f); 

        state = BattleState.PLAYERTURN;
        Playerturn(); // had to call method//fix
    }

    IEnumerator PlayerAttack()
    {
        bool isDead = chaserUnit.Takedamage(playerUnit.damage);
        chaserHud.SetHud(chaserUnit); // didnt exist 
        yield return new WaitForSeconds(1f);
        Debug.Log("monk"); 

        if (isDead)
        {
        state = BattleState.WIN;
        Endbattle();
        }else
        {
        state = BattleState.CHASERTURN;
        StartCoroutine(ChaserTurn());
        }
    }
    IEnumerator PlayerHeal()
    {
      playerUnit.Heal(3);
      playerHud.SetHud(playerUnit);
      dialogueText.text = "You've healed";
      yield return new WaitForSeconds(1f);

      state = BattleState.CHASERTURN;
      StartCoroutine(ChaserTurn());
    }
    
   void Endbattle()
   {
    if (state == BattleState.WIN)
    {
        dialogueText.text = "You win!";
        SceneManager.LoadScene(PlayerPrefs.GetInt("LastScene"));
    }
    else if (state == BattleState.LOSE)
    {
        dialogueText.text = "Oh no, you lost!";
        SceneManager.LoadScene("level 1");
    }
   }

    IEnumerator ChaserTurn()
    {
     dialogueText.text = chaserUnit.unitName + " Attacks";
     yield return new WaitForSeconds(1f);

     bool isDead = playerUnit.Takedamage(chaserUnit.damage);
     playerHud.SetHud(playerUnit);
     Debug.Log("bin");
     yield return new WaitForSeconds(1f);
    
    if (isDead)
    {
      state = BattleState.LOSE;
      Endbattle();
    } else
    {
      state = BattleState.PLAYERTURN;
      Playerturn();
    }

    }
    
    void Playerturn()
    {
        Debug.Log("player turn");
        dialogueText.text = "Make a Choice ";
    }

    public void OnHealbutton()
    {
        if (state != BattleState.PLAYERTURN) 
            return;
        StartCoroutine(PlayerHeal());

    }    
    public void Onattackbutton()
    {
        if (state != BattleState.PLAYERTURN) 
            return;
        StartCoroutine(PlayerAttack());
    }
}

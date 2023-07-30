using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] GameObject sceneManager;
    public void OnImageClicked()
    {
        sceneManager.GetComponent<BattleSceneManager>().p_canHeroWalk = !sceneManager.GetComponent<BattleSceneManager>().p_canHeroWalk;
        Debug.Log("changed");
    }

    public void ChangeTheAttack()
    {
        GameManager.Instance.attackNearestEnemy = !GameManager.Instance.attackNearestEnemy;
    }

}

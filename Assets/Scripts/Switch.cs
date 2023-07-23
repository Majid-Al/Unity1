using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] GameObject sceneManager;
    public void OnImageClicked()
    {
        sceneManager.GetComponent<BattleSceneManager>().canHeroWalk = !sceneManager.GetComponent<BattleSceneManager>().canHeroWalk;
        Debug.Log("changed");
    }

    public void ChangeTheAttack()
    {
        GameManager.Instance.attackNearestEnemy = !GameManager.Instance.attackNearestEnemy;
    }

}

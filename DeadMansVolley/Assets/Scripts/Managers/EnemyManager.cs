using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class controls how many enemys are in the 
/// scene at any one time.
/// </summary>
public class EnemyManager : MonoBehaviour
{
    //Public variables
    public Rigidbody enemyType1Object;
    public int maxNumberOfEnemys = 25;

    //Private variables
    List<Rigidbody> enemyInstances;

    // Start is called before the first frame update
    void Awake() {
        enemyInstances = new List<Rigidbody>();
    }

    // Get the current number of enemys in the scene
    public int GetCurrentNumberOfEnemys() {
        return enemyInstances.Count;
    }

    // Create a new enemy of type 1 with the given position and rotation
    public Rigidbody CreateNewEnemyType1(Vector3 position, Quaternion rotation) {
        Rigidbody newEnemyType1Instance = Instantiate(enemyType1Object, position, rotation) as Rigidbody;
        enemyInstances.Add(newEnemyType1Instance);
        return newEnemyType1Instance;
    }

    // Remove the given enemy from the list
    public void RemoveEnemy(Rigidbody enemy) {
        if (enemyInstances.Contains(enemy))
        {
            enemyInstances.Remove(enemy);
        }
    }

    /*
    The functions CreateNewEnemyType1(Vector3 position, Quaternion rotation) is loosly based on the functions Spawn() from source #1 and Fire() from source #2.

    #1
    Title : Survival Shooter tutorial: Spawning Enemies
    Author : Unity
    Date Accessed : 07/04/2019
    Code Version : 1.0
    Availability : https://unity3d.com/learn/tutorials/projects/survival-shooter/more-enemies?playlist=17144
 
    #2
    Title : Tutorials: Tanks tutorial: Firing Shells
    Author : Unity
    Date Accessed : 07/04/2019
    Code Version : 1.0
    Availability : https://unity3d.com/learn/tutorials/projects/tanks-tutorial/firing-shells?playlist=20081
     */
}

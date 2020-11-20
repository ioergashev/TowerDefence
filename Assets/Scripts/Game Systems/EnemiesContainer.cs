using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Game
{
    public EnemiesContainer EnemiesContainer;
}

public class EnemiesContainer : MonoBehaviour
{
    public List<GameObject> Enemies = new List<GameObject>();
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridController;

public class LevelController : MonoBehaviour
{

    
    private void Start()
    {
        GridController.Grid grid = new GridController.Grid();
        grid.SwitchLvl(1);
    }
}

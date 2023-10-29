using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IComand
{
    //Ejecucion de la orden

    void Do();

    //Patron Memento
    void UnDo();
}

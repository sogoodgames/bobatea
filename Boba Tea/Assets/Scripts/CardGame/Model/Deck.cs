using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using UnityEngine.Assertions;

public class Deck<T> : Stack<T>
{
    public void Shuffle () {
        var elements = base.ToArray();
        elements.OrderBy(c => UnityEngine.Random.value);

        base.Clear();
        foreach(var element in elements) {
            base.Push(element);
        }
    }
}
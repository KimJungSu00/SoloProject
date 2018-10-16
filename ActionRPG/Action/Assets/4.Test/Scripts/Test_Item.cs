using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test
{
    public class Test_Item
    {
        public int Code;
        public Sprite Sprite;

        public Test_Item()
        {
            Code = 0;
            Sprite = Resources.Load<Sprite>("Default");
        }
     
    }
}
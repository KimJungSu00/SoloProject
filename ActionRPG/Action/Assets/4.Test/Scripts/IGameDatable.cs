using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Test
{
    public interface IGameDatable
    {
        void SendItem();
        void ReceiveItem(ItemStruct item); 
    }
}

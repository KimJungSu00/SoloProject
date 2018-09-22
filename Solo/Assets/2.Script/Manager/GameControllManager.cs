using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SideScroll.Manager.Stage;



namespace SideScroll.Manager
{
    public enum StageStateType
    {
        Main,
        Login,
        Town,
        Dungeon,
    }

    public class GameControllManager : Singleton<GameControllManager>
    {

        public StageState StageState { get; private set; }
        

        private void Start()
        {
            gameObject.tag = "GameController";
        }

        public void ChangeStageState(StageStateType nextStage)
        {
            switch (nextStage)
            {
                case StageStateType.Login:
                    StageState = new LoginState();
                    break;
                case StageStateType.Town:
                    StageState = new TownState();
                    break;
                case StageStateType.Dungeon:
                    StageState = new DungeonState();
                    break;
                default:
                    break;
            }
            StageState.Enter();
        }



    }
}

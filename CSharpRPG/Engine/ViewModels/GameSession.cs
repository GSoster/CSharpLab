using System;
using System.Collections.Generic;
using System.Text;
using Engine.Models;
namespace Engine.ViewModels
{
    class GameSession
    {
        public Player CurrentPlayer{ get; set; }

        public GameSession()
        {
            CurrentPlayer = new Player(){Name = "Teste Player", Gold = 1000};
            
        }
    }
}

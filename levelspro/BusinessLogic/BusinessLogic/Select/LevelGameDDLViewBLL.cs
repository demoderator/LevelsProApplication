﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess.Select;

namespace BusinessLogic.Select
{
    public class LevelGameDDLViewBLL : Transaction
    {
      private Common.LevelGame _game;
      private DataSet _resultSet;
      public LevelGameDDLViewBLL()
        {
        }
        public void Invoke()
        {
            LevelGameDDLViewDAL selectData = new LevelGameDDLViewDAL();
            selectData.Game = Game;
            ResultSet = selectData.View();
        }

        public DataSet ResultSet
        {
            get
            {
                return _resultSet;
            }
            set
            {
                _resultSet = value;
            }
        }

        public Common.LevelGame Game
        {
            get
            {
                return _game;
            }
            set
            {
                _game = value;
            }
        }
    }
}

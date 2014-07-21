﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess.Select;

namespace BusinessLogic.Select
{
    public class RewardViewBLL : Transaction
    {
        private DataSet _resultSet;
        public RewardViewBLL()
        {
        }
        public void Invoke()
        {
            RewardViewDAL selectData = new RewardViewDAL();
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
    }

}

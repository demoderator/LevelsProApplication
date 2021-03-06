﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Update;

namespace BusinessLogic.Update
{   

    public class UserManualAwardPopupUpdateBLL : Transaction
    {
        private Common.User _user;

        public UserManualAwardPopupUpdateBLL()
        {
        }
        public void Invoke()
        {
            UserManualAwardPopupUpdateDAL updateData = new UserManualAwardPopupUpdateDAL();
            updateData.User = this.User;
            updateData.Update();
        }

        public Common.User User
        {
            get
            {
                return _user;
            }
            set
            {
                _user = value;
            }
        }
    }
}

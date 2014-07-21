﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace DataAccess.Insert
{
   public class QuizInsertDAL : DataAccessBase
    {
       private Common.Quiz _quiz;
        private GameInsertDataParameters _insertParameters;

        public QuizInsertDAL()
        {
            StoredProcedureName = StoredProcedure.Insert.sp_InsertQuiz.ToString();
        }
        public void Add()
        {

            _insertParameters = new GameInsertDataParameters(Quiz);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            dbHelper.Run(base.ConnectionString, _insertParameters.Parameters);
        }

        public Common.Quiz Quiz
        {
            get
            {
                return _quiz;
            }
            set
            {
                _quiz = value;
            }
        }
    }
    public class GameInsertDataParameters
    {
        private Common.Quiz _quiz;
        private MySqlParameter[] _parameters;

        public GameInsertDataParameters(Common.Quiz quiz)
        {
            Quiz = quiz;
            Build();
        }
        public void Build()
        {
            MySqlParameter[] parameters = {new MySqlParameter("?p_QuizName",Quiz.QuizName),
                                              new MySqlParameter("?p_NoOfQuestions",Quiz.NoOfQuestions),
                                              new MySqlParameter("?p_TimePerQuestion",Quiz.TimePerQuestion),
                                              new MySqlParameter("?p_TimesPlayablePerDay",Quiz.TimesPlayablePerDay),
                                              new MySqlParameter("?p_TimeBeforePointsDeduction",Quiz.TimeBeforePointsDeduction),
                                              new MySqlParameter("?p_PointsPerQuestion",Quiz.PointsPerQuestion),
                                              new MySqlParameter("?p_QuizImage",Quiz.QuizImage),
                                              new MySqlParameter("?p_QuizImageThumbnail",Quiz.QuizImageThumbnail),
                                              new MySqlParameter("?p_KPIID",Quiz.KPIID)
                                          };
            Parameters = parameters;
        }
        public MySqlParameter[] Parameters
        {
            get
            {
                return _parameters;
            }
            set
            {
                _parameters = value;
            }
        }
        public Common.Quiz Quiz
        {
            get
            {
                return _quiz;
            }
            set
            {
                _quiz = value;
            }
        }
    }
}

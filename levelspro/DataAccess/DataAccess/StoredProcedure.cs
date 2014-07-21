﻿using System;
using System.Collections.Generic;
using System.Text;
namespace DataAccess
{
    public class StoredProcedure
    {
        public enum Select
        {
            sp_GetRoles,
            sp_GetLifeLines,
            sp_GetPoints,
            sp_GetLevels,
            sp_GetLevelsByRole,
            sp_GetKPI,
            sp_GetReward,
            sp_GetAward,
            sp_GetContest,
            sp_GetTarget,            
            sp_GetUser,
            sp_GetAwardDetails,
            sp_GetImage,
            sp_GetUsersInfoTemp,
            sp_Player_GetAward,
            sp_Player_GetContest,
            sp_GetContestDetails,
            sp_GetDropDown,
            sp_GetRedeemPoints,
            sp_Contest_PlayersScore,
            sp_CheckUserName,
            sp_CheckSecurityAnswer,
            sp_GetUserInfoByEmail,
            sp_CheckPassword,
            sp_GetSites_ddl,           
            sp_CheckPasswordNull,
            sp_GetUsers_Manager,
            sp_GetTotalPlayerScore,
            sp_GetUserScoreAdmin,
            sp_GetQuizPlayLog,
            sp_UserQuizScore,
            sp_GetLevelperformance_PopupShowed,

            sp_GelMilestonesDetail,
            sp_GetUserProgressDetail,
            sp_TeamPerformance,
            sp_GetMapDetail,
            sp_GetLevelPerformance,
            sp_GetTargetDescription,

        



            sp_GetPlayerLevelPercent,

            sp_GetAllSites,
            sp_GetSecurityQuestions,

            sp_GetManualAssignedAwards,

            sp_GetPostTypes,
            sp_GetPosts,
            sp_GetPostDetails,
            sp_GetPostByID,
            sp_QuizData,
            sp_GetUsersByRole,

            sp_GetRepliedLikeStatus,
            sp_GetGame,
            sp_GetMessages,
            sp_GetRewardImages,
            sp_GetAwardImages,
            sp_GetUserTargetScoreAdmin,

            sp_GetUserAwardScore,

            sp_GetAutomaticAwards,
            sp_GetLevelGame,
            sp_GetLevelGameDDL,

            sp_GetQuiz,
            sp_GetQuizQuestions,

            sp_GetQuestionLevels,
            sp_GetQuiz_Player,
            sp_GetQuizQuestion_Player,
            sp_RolesLevels,
            sp_GetCategory,
            sp_GetRewardUser
        }
        public enum Insert
        {
            sp_InsertRole,
            sp_InsertLevel,
            sp_InsertLifeLine,
            sp_InsertKPI,
            sp_InsertReward,
            sp_InsertAwards,
            sp_InsertContest,
            sp_InsertTarget,
            sp_InsertImage,
            sp_InsertUser,
            sp_InsertRedeemPoints,
            sp_InsertSecurityAnswersTemp,
            sp_InsertUserAwards,
            sp_InsertQuizPlayLog,
            sp_InsertSite,

            sp_InsertPost,
            sp_insertPostReply,
            sp_instertRepliedLike,
            sp_InsertQuiz,
            sp_InsertQuestions,
            sp_InsertMessage,
            sp_InsertMessageReply,
            sp_InsertRewardImage,
            sp_InsertAwardImage,
            sp_InsertLevelGame,
            sp_InsertLevelGameDLL,

            sp_InsertScore,

            sp_InsertQuestionLevels,
            sp_InsertQuizScore,
            sp_InsertCategory,
            sp_InsertScoreAuto
        }
        public enum Delete
        {
            sp_deleterole,
            sp_deletelevel,
            sp_DeleteUserImage,
            sp_DeleteRewardImage,
            sp_DeleteAwardImage,

            sp_DeleteMessage,
            


            sp_DeleteTarget,

            sp_DeleteQuiz,
            sp_DeleteQuestion,
            sp_DeleteUserScore
            , sp_DeleteQuestionLevel,
            sp_DeleteAssignAward,
            sp_DeleteSecurityAnswers
        }
        public enum Update
        {
            sp_UpdateRole,
            sp_UpdateLevel,
            sp_UpdateKPI,
            sp_UpdateReward,
            sp_UpdateAward,
            sp_UpdateContest,
            sp_UpdateTarget,
            sp_UpdateUser,
            sp_UpdateImage,
            sp_UpdateUser_Admin,
            sp_UpdatePassword,
            sp_UpdateScoreManual,
            sp_UpdateUserMass,
            sp_UpdateLevelPosition,
            sp_UpdateSite,
            sp_UpdateQuiz,
            sp_UpdateQuestions,
            sp_UpdateMessageStatus,
            sp_levels_UpdateTargets,
            sp_level_UpdateLevelInfo,
            sp_PopupShowed,
            sp_Update_UserTargetAchieved,
            sp_Update_UserAwardAchieved,
            sp_Update_UserAwardAchievedpopup,
            sp_UpdateUserManualAward_Popup,
            sp_UpdateLevelperformance_PopupShowed,
            sp_UpdateLevelperformance,
            sp_UpdatePoints,
            sp_UpdateLevelGame,
            sp_UpdateLevelGameDDL,
            sp_UpdateLoginTime,
            sp_UpdateCategory,
            sp_PasswordRequest
        }
        public enum Report
        {
            sp_ReportSumPoints
        }

    }
}

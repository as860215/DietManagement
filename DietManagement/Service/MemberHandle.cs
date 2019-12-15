using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DietManagement
{
    public class MemberHandle : DBConnect
    {
        /// <summary>
        /// 取得成員
        /// </summary>
        /// <param name="memberId">成員編號</param>
        /// <returns>成員</returns>
        public Member GetMember(string memberId)
        {
            using (conn)
            {
                var sql = $@"select * from Member where MemberId = '{memberId}'";
                return conn.Query<Member>(sql).FirstOrDefault();
            }
        }

        /// <summary>
        /// 登入
        /// </summary>
        /// <returns></returns>
        public Member Login(string Account , string Password)
        {
            using (conn)
            {
                var sql = $@"SELECT * FROM MEMBER WHERE Account = '{Account}' AND Password = '{Password}'";
                return conn.Query<Member>(sql).FirstOrDefault();
            }
        }

        /// <summary>
        /// 加入成員
        /// </summary>
        /// <param name="member"></param>
        public void InsertMember(Member member)
        {
            conn.connOpen(sqlCommand);
            using (conn)
            {
                var sql = $@"INSERT INTO [dbo].[Member]
                               ([MemberId]
                               ,[Name]
                               ,[Gender]
                               ,[Nickname]
                               ,[Account]
                               ,[Password]
                               ,[Height]
                               ,[Weight]
                               ,[Phone]
                               ,[Mail]
                               ,[Birthday])
                         VALUES
                               (@MemberId
                               ,@Name
                               ,@Gender
                               ,@NickName
                               ,@Account
                               ,@Password
                               ,@Height
                               ,@Weight
                               ,@Phone
                               ,@Mail
                               ,@Birthday)";
                conn.Execute(sql,member);
            }
        }
        
        /// <summary>
        /// 流水號助手
        /// </summary>
        /// <returns>MemberId流水號</returns>
        private int GetIdHelper()
        {
            using (conn)
            {
                var sql = $@"select top 1 MemberId from Member order by MemberId desc";
                return conn.Query<int>(sql).FirstOrDefault() + 1;
            }
        }

        /// <summary>
        /// 檢查帳號是否已存在
        /// </summary>
        /// <returns></returns>
        public bool CheckAccount(string Account)
        {
            using (conn)
            {
                var sql = $@"select Account from Member where Account = '{Account}'";
                var result = conn.Query<string>(sql).ToList();
                if (result.Count > 0)
                    return true;
                else
                    return false;
            }
        }
    }
}

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
    }
}

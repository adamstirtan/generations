using System.Text;

using Dapper;

using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

using Generations.Core.Extensions;

namespace Generations.Data.Services
{
    public abstract class BaseService
    {
        private readonly string _connectionId;

        protected IConfiguration Configuration;

        protected BaseService(IConfiguration configuration)
        {
            Configuration = configuration;

            _connectionId = Configuration["Generations:ConnectionId"];
        }

        public abstract string TableName { get; }

        public virtual async Task<int> CountAsync()
        {
            string sql = $@"
SELECT COUNT(Id) FROM {TableName}";

            using var connection = new SqlConnection(
                Configuration.GetConnectionString(_connectionId));

            connection.Open();

            return await connection.ExecuteScalarAsync<int>(sql);
        }

        public virtual async Task<bool> DeleteAsync(int id)
        {
            string sql = $@"
DELETE FROM {TableName}
WHERE Id = @Id";

            using var connection = new SqlConnection(
                Configuration.GetConnectionString(_connectionId));

            connection.Open();

            return await connection.ExecuteAsync(sql, new { id }) > 0;
        }

        protected static string LikeCondition(string column, string value)
        {
            return $" AND {column} LIKE '%{value.SqlEscape()}%' ";
        }

        protected static string FullLikeCondition(string column, string value)
        {
            return $" AND {column} LIKE '%{value.SqlEscape()}%' AND {column} IS NOT NULL ";
        }

        protected static string ComboLikeCondition(string column, string value)
        {
            if (value == "All")
            {
                return "";
            }

            return $" AND {column} LIKE '%{value.SqlEscape()}%' AND {column} IS NOT NULL ";
        }

        protected static string MultiLikeCondition(string column, string value)
        {
            if (!value.Contains(','))
            {
                return $" AND {column} LIKE '%{value.SqlEscape()}%' AND {column} IS NOT NULL ";
            }

            string[] likes = value.Split(',');

            StringBuilder result = new(" AND (");

            for (int i = 0; i < likes.Length; i++)
            {
                if (i == 0)
                {
                    result.Append($"{column} LIKE '%{likes[i].SqlEscape().Trim()}%'");
                }
                else
                {
                    result.Append($" OR {column} LIKE '%{likes[i].SqlEscape().Trim()}%'");
                }
            }

            result.Append($") AND {column} IS NOT NULL ");

            return result.ToString();
        }

        protected static string GridActiveCondition(string column, string nullActiveColumn, bool? active, bool hasOtherConditions = false)
        {
            return active == null && !hasOtherConditions ? "" : active == null ? $" WHERE {nullActiveColumn} > 0 " : $" WHERE {column} = '{(active.GetValueOrDefault(false) ? "true" : "false")}' ";
        }

        protected static string ActiveCondition(string column, bool activeOnly)
        {
            return !activeOnly ? " WHERE " : $" WHERE {column} = 'true' AND ";
        }

        protected static string BoolCondition(string column, bool? value)
        {
            return value == null ? "" : $" AND {column} = '{value.GetValueOrDefault()}' ";
        }

        protected static string EqualsCondition(string column, int value)
        {
            return $" AND {column} = '{value}' ";
        }

        protected static string EqualsMoreCondition(string column, string value)
        {
            return $" AND {column} >= '{value}' ";
        }

        protected static string EqualsLessCondition(string column, string value)
        {
            return $" AND {column} <= '{value}' ";
        }
    }
}
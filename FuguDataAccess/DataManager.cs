using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;


namespace FuguDataAccess
{
	/// <summary>
	/// Class responsible to communicate with the database server.
	/// </summary>
	public class DataManager : IDataManager
	{
		#region variables

		/// <summary>
		/// The database server connection object.
		/// </summary>
		private readonly string connectionStr = string.Empty;

		#endregion

		#region constructors

		/// <summary>
		/// The constructor for the data extract manager.
		/// </summary>
		/// <param name="connectionStr">The connection string.</param>
		public DataManager(string connectionStr)
		{
			this.connectionStr = connectionStr;
		}

		#endregion

		#region public methods 
		
		/// <summary>
		/// Get Learning Center By Id.
		/// </summary>
		/// <returns>A single learning center.</returns>
		public List<LearningCenter> GetLearningCenters()
		{
			IEnumerable<LearningCenter> learningCenters;

			if (string.IsNullOrEmpty(this.connectionStr))
			{
				throw new ApplicationException("Connection string is empty or missing.");
			}

			try
			{
				using (var connection = new SqlConnection(this.connectionStr))
				{
					connection.Open();
					var query = "dbo.spAdmin_GetLearningCenters";
					learningCenters = connection.Query<LearningCenter>(query, commandType: CommandType.StoredProcedure);
					
				}
			}
			catch (Exception exp)
			{
				throw exp;
			}

			return learningCenters.ToList();
		}

		/// <summary>
		/// Get Learning Center By Id.
		/// </summary>
		/// <param name="lcNum">Learning center id.</param>
		/// <returns>A single learning center.</returns>
		public LearningCenter GetLearningCenterByLcNum(int lcNum)
		{
			LearningCenter learningCenter = new LearningCenter();

			if (string.IsNullOrEmpty(this.connectionStr))
			{
				throw new ApplicationException("Connection string is empty or missing.");
			}

			try
			{
				var paramList = new Dictionary<string, object>();

				using (var connection = new SqlConnection(this.connectionStr))
				{
					connection.Open();
					paramList.Add("LCNum", lcNum);
					var query = "dbo.spAdmin_GetLearningCenterData";
					learningCenter = connection.QueryFirstOrDefault<LearningCenter>(query, paramList, commandType: CommandType.StoredProcedure);
				}
			}
			catch (Exception exp)
			{
				throw exp;
			}

			return learningCenter;
		}

		 /// <summary>
		 /// Get the user object by using ID
		 /// </summary>
		 /// <param name="id"> The user id</param>
		 /// <returns> user object with values for the particular id</returns>
		public User GetUserByID(int id)
		{
			User user = new User();
				
			if (string.IsNullOrEmpty(this.connectionStr))
			{
				throw new ApplicationException("Connection string is empty or missing.");
			}

			try
			{
				var paramList = new Dictionary<string, object>();

                using (var connection = new SqlConnection(this.connectionStr))
                {
                    connection.Open();
                    paramList.Add("userid", id);
                    var query = "dbo.spFV_getUserInfo";
                    user = connection.QueryFirstOrDefault<User>(query, paramList, commandType: CommandType.StoredProcedure);
                }
			}
			catch (Exception exp)
			{
				throw exp;
			}

			return user;	
		}
		#endregion
	}
}

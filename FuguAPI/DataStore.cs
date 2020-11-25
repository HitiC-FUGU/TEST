using FuguDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FuguAPI
{
	public class DataStore
	{
		private readonly string connection = string.Empty;

		public DataStore(string connection)
		{
			this.connection = connection;
		}

		public List<LearningCenter> GetLearningCenters()
		{
			try
			{
				var dataAccess = new DataManager(this.connection);
				return dataAccess.GetLearningCenters();
			}
			catch (Exception exp)
			{
				Console.WriteLine(exp.Message);
				throw exp;
			}
		}

		public LearningCenter GetLearningCenterByLcNum(int lcNum)
		{
			try
			{
				var dataAccess = new DataManager(this.connection);
				return dataAccess.GetLearningCenterByLcNum(lcNum);
			}
			catch (Exception exp)
			{
				Console.WriteLine(exp.Message);
				throw exp;
			}
		}
		public User GetUserById(int id)
		{
			try
			{
				var dataAccess = new DataManager(this.connection);
				return dataAccess.GetUserByID(id);
			}
			catch (Exception exp)
			{
				Console.WriteLine(exp.Message);
				throw exp;
			}
		}
	}
}

using System.Collections.Generic;
using System.Threading.Tasks;

namespace FuguDataAccess
{
	/// <summary>
	/// Interface responsible to retrieve, update, and insert data to database server.
	/// </summary>
	public interface IDataManager
	{
		/// <summary>
		/// Get Learning Center by Id.
		/// </summary>
		/// <returns>Returns a learning center object.</returns>
		List<LearningCenter> GetLearningCenters();

		/// <summary>
		/// Get learning center by learning center number.
		/// </summary>
		/// <param name="lcNum">The learning center number.</param>
		/// <returns>An object representing the learning center.</returns>
		LearningCenter GetLearningCenterByLcNum(int lcNum);
		User GetUserByID(int id);
	}
}

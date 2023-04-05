using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Data1C.Model
{
	[DataContract]
	public class DataPoint

	{
		[DataMember(Name = "x")]
		public Nullable<double> X;
		[DataMember(Name = "y")]
		public Nullable<double> Y;

		//[DataMember(Name = "y")]
		//public string dt;

		public DataPoint(double x, double y)
		{
			this.X = x;
			this.Y = y;
		}

		//public DataPoint(double x, DateTime dateTime)
		//{
		//	this.X = x;
		//	this.dt = $"new Date({dateTime.Year}, {dateTime.Month}, {dateTime.Day})"; /*+ "dd MMMM yyyy");*/
		//}

	}
}

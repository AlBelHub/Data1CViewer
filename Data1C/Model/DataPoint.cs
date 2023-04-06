using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Data1C.Model
{
	[DataContract]
	public class DataPoint
	{
        [DataMember(Name = "x")]
        public Nullable<long> TimeStamp;
        [DataMember(Name = "y")]
		public Nullable<double> Y;

        //[DataMember(Name = "y")]
        //public Nullable<double> Y;


        //public DataPoint(double x, double y)
        //{
        //	this.X = x;
        //	this.Y = y;
        //}

        public DataPoint(double y, DateTime dateTime)
		{
			this.Y = y;
			var baseDate = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
			this.TimeStamp = (long)(dateTime.ToUniversalTime() - baseDate).TotalMilliseconds;
		}

	}
}

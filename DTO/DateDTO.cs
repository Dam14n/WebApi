using System.Collections.Generic;
using System.Runtime.Serialization;
using Model;

namespace DTO
{
	[DataContract]
	public class DateDTO : IIdentificable
	{
		[DataMember]
		public int CategoryId { get; set; }

		[DataMember]
		public List<int> MatchesIds { get; set; }

		[DataMember]
		public int Id { get; set; }

		[DataMember]
		public int DateNumber { get; set; }
	}
}

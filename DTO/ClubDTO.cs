using System.Collections.Generic;
using System.Runtime.Serialization;
using Model;

namespace DTO
{
	[DataContract]
	public class ClubDTO : IIdentificable
	{
		[DataMember]
		public int Id { get; set; }

		[DataMember]
		public string Name { get; set; }

		[DataMember]
		public int? Latitude { get; set; }

		[DataMember]
		public int? Longitude { get; set; }

		[DataMember]
		public List<int> TeamsIds { get; set; }

		[DataMember]
		public int? LogoId { get; set; }
	}
}

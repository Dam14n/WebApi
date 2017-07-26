using System.Collections.Generic;
using System.Runtime.Serialization;
using Model;

namespace DTO
{
	[DataContract]
	public class TeamDTO : IIdentificable
	{
		[DataMember]
		public int Id { get; set; }

		[DataMember]
		public string Name { get; set; }

		[DataMember]
		public int LogoId { get; set; }

		[DataMember]
		public List<int> PlayersIds { get; set; }

		[DataMember]
		public List<int> LocalMatchesIds { get; set; }

		[DataMember]
		public List<int> AwayMatchesIds { get; set; }

		[DataMember]
		public List<int> GoalsIds { get; set; }
	}
}

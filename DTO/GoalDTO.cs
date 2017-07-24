using System.Runtime.Serialization;
using Model;

namespace DTO
{
	[DataContract]
	public class GoalDTO : IIdentificable
	{
		[DataMember]
		public int MatchId { get; set; }

		[DataMember]
		public int PlayerId { get; set; }

		[DataMember]
		public int TeamId { get; set; }

		[DataMember]
		public int Id { get; set; }
	}
}

using System.Runtime.Serialization;
using Model;

namespace DTO
{
	[DataContract]
	public class PositionDTO : IIdentificable
	{
		[DataMember]
		public int Id { get; set; }

		[DataMember]
		public int Rank { get; set; }

		[DataMember]
		public int TeamId { get; set; }

		[DataMember]
		public int BoardId { get; set; }

		[DataMember]
		public int Points { get; set; }

		[DataMember]
		public int PlayedMatches { get; set; }

		[DataMember]
		public int WinMatches { get; set; }

		[DataMember]
		public int TieMatches { get; set; }

		[DataMember]
		public int LoseMatches { get; set; }

		[DataMember]
		public int FavorGoals { get; set; }

		[DataMember]
		public int AgainstGoals { get; set; }

		[DataMember]
		public int DifferenceGoals { get; set; }
	}
}

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Model;

namespace DTO
{
	[DataContract]
	public class MatchDTO : IIdentificable
	{
		[DataMember]
		public int DateId { get; set; }

		[DataMember]
		public int LocalTeamId { get; set; }

		[DataMember]
		public int EnemyTeamId { get; set; }

		[DataMember]
		public List<int> LocalGoalsIds { get; set; }

		[DataMember]
		public List<int> EnemyGoalsIds { get; set; }

		[DataMember]
		public int Id { get; set; }

		[DataMember]
		public bool Played { get; set; }

		[DataMember]
		public DateTime DateMatch { get; set; }
	}
}

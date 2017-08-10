﻿using System.Collections.Generic;
using System.Runtime.Serialization;
using Model;

namespace DTO
{
	[DataContract]
	public class BoardDTO : IIdentificable
	{
		[DataMember]
		public int Id { get; set; }

		[DataMember]
		public string Name { get; set; }

		[DataMember]
		public List<int> PositionsIds { get; set; }

		[DataMember]
		public int CategoryId { get; set; }
	}
}

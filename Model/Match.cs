using System;
using System.Linq;

namespace Model
{
	public class Match : IIdentificable
	{
		public Match()
		{
		}

		public virtual int Id { get; private set; }

		public virtual DateTime DateMatch { get; set; }

		public virtual int DateId { get; set; }
		public virtual Date Date { get; set; }

		public virtual int? LocalTeamId { get; set; }
		public virtual Team LocalTeam { get; set; }

		public virtual int? EnemyTeamId { get; set; }
		public virtual Team EnemyTeam { get; set; }

		public MatchResult GetResult(int teamId)
		{
			var result = MatchResult.LOSE;
			int goalsLocalTeam = LocalTeam.Goals
				.Where(m => m.MatchId == this.Id)
				.ToList()
				.Count;
			int goalsEnemyTeam = EnemyTeam.Goals
				.Where(m => m.MatchId == this.Id)
				.ToList()
				.Count;
			if (goalsEnemyTeam == goalsLocalTeam)
			{
				return MatchResult.TIE;
			}
			else if (goalsLocalTeam > goalsEnemyTeam && LocalTeamId == teamId)
			{
				return MatchResult.WIN;
			}
			else if (goalsEnemyTeam > goalsLocalTeam && EnemyTeamId == teamId)
			{
				return MatchResult.WIN;
			}
			return result;
		}

		public int GetGoalsAgainst(int teamId)
		{
			if (LocalTeamId == teamId)
			{
				return EnemyTeam.Goals
				.Where(m => m.MatchId == this.Id)
				.ToList()
				.Count;
			}
			else
			{
				return LocalTeam.Goals
				.Where(m => m.MatchId == this.Id)
				.ToList()
				.Count;
			}
		}
	}
}

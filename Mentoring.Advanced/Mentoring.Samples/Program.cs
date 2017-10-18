using System;
using System.Collections.Generic;

namespace Mentoring.Samples
{
	class AgentSmith
	{
		public int AgentID { get; set; }

		public int MatrixID { get; set; }

		public AgentSmith(int agentId, int matrixID)
		{
			AgentID = agentId;
			MatrixID = matrixID;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="obj"></param>
		/// <remarks>
		/// We suppose if agents have the same AgentID and MatrixID they are equal 
		/// </remarks>
		/// <returns></returns>
		public override bool Equals(object obj)
		{
			if (obj == null) return false;
			AgentSmith agent = (AgentSmith)obj as AgentSmith;

			if (agent == null) return false;

			return AgentID == agent.AgentID && MatrixID == agent.MatrixID;
		}

#if STRONGMATRIX

		public override int GetHashCode()
		{
			return AgentID ^ MatrixID;
		}
#endif

	}

	class Program
	{
		static Dictionary<AgentSmith, string> Matrix { get; set; } = new Dictionary<AgentSmith, string>();

		static void Main(string[] args)
		{
			AgentSmith agent = new AgentSmith(0, 0); //add an agent
			AgentSmith anotherAgent = new AgentSmith(0, 0);//add the same agent

			Console.WriteLine(agent.Equals(anotherAgent) ? "The agent is the same" : "Hmm there is another agent");

			try
			{
				Matrix.Add(agent, "Mr Anderson");
				Matrix.Add(anotherAgent, "Neo");
			}
			catch(ArgumentException)
			{
				Console.WriteLine("The agent is already assigned");
			}

			AgentSmith superAgent = new AgentSmith(0, 0);
			try
			{
				Console.WriteLine($"{nameof(agent)} is assigned to {Matrix[agent]}");
				Console.WriteLine($"{nameof(anotherAgent)} is assigned to {Matrix[anotherAgent]}");
				Console.WriteLine($"{nameof(superAgent)} is assigned to {Matrix[superAgent]}");
			}
			catch(KeyNotFoundException)
			{
				Console.WriteLine("No agent is found");
			}

			Console.Read();
		}

	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System.Threading.Tasks;

namespace Mentoring.Exceptions.Memory
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.Read();
			try
			{
				Controller contr = new Controller();
				Parallel.For(0, 1000000, p => contr.HandleRequest());
			}
			catch
			{
				Console.WriteLine("Something went wrong");
			}
			Console.Read();
		}
	}

	static class Mappers
	{
		public static MapperConfiguration GetMappingConfiguration()
		{
			MapperConfiguration config = new MapperConfiguration(cfg =>
			{
				cfg.CreateMap<BusinessObject, ContractObject>()
					.ForMember(dst => dst.FirstName, opt => opt.MapFrom(src => src.FirstName))
					.ForMember(dst => dst.LastName, opt => opt.MapFrom(src => src.LastName))
					.ForMember(dst => dst.Age, opt => opt.MapFrom(src => src.Age))
					.ForMember(dst => dst.BirthDate, opt => opt.MapFrom(src => src.BirthDate))
					.ForMember(dst => dst.Children, opt => opt.MapFrom(src => src.Children))
					.ForMember(dst => dst.Contact, opt => opt.MapFrom(src => src))
					.ForMember(dst => dst.Property, opt => opt.MapFrom(src => GetDictionaryKeys(src.Property)))
					.ForMember(dst => dst.Sex, opt => opt.MapFrom(src => src.IsMan ? "Man" : src.IsWoman ? "Woman" : null))
					.ForMember(dst => dst.Work, opt => opt.MapFrom(src => src));


				cfg.CreateMap<BusinessObject, ContractObject.ContactInfo>()
					.ForMember(dst => dst.Address, opt => opt.MapFrom(src => src.Address))
					.ForMember(dst => dst.Phone, opt => opt.MapFrom(src => src.Phone));

				cfg.CreateMap<BusinessObject, ContractObject.WorkInfo>()
					.ForMember(dst => dst.Adress, opt => opt.MapFrom(src => src.Work))
					.ForMember(dst => dst.Phone, opt => opt.MapFrom(src => src.WorkPhone));

			});
			return config;
		}

		static string[] GetDictionaryKeys(IDictionary<string, int> dictionary)
		{
			return dictionary?.Keys.ToArray();
		}
	}

	class Controller
	{
		public ContractObject HandleRequest()
		{
			var config = Mappers.GetMappingConfiguration();
			var mapper = config.CreateMapper();
			return mapper.Map<ContractObject>(new BusinessObject());
		}
	}

	class BusinessObject
	{
		public string FirstName { get; set; } = "Test";

		public string LastName { get; set; } = "Temp";

		public DateTime BirthDate { get; set; } = DateTime.Now;

		public bool IsSleeping { get; set; } = false;

		public int Age { get; set; } = 0;

		public string Phone { get; set; } = "+3752632454642";

		public string Address { get; set; } = "Hell";

		public string Work { get; set; } = null;

		public BusinessObject[] Children { get; set; } = new BusinessObject[] { };

		public bool IsMan { get; set; } = false;

		public bool IsWoman { get; set; } = true;

		public string WorkPhone { get; set; } = null;

		public TimeSpan SessionTime { get; set; } = new TimeSpan(300);

		public Dictionary<string, int> Property { get; set; } = new Dictionary<string, int>()
		{
			{"Table",1000 }
		};
	}

	class ContractObject
	{
		public class ContactInfo
		{
			public string Phone { get; set; }

			public string Address { get; set; }
		}

		public class WorkInfo
		{
			public string Adress { get; set; }

			public string Phone { get; set; }
		}

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public DateTime BirthDate { get; set; } 

		public int Age { get; set; } 

		public ContactInfo Contact { get; set; }

		public ContractObject[] Children { get; set; } = new ContractObject[] { };

		public string Sex { get; set; }

		public string[] Property { get; set; }

		public WorkInfo Work { get; set; }
	}

}

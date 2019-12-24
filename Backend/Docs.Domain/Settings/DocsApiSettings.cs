using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Docs.Domain.Settings
{
	public class DocsApiSettings
	{
		public MetadataDbContextSettings MetadataDbContextSettings { get; set; }
	}

	public class MetadataDbContextSettings
	{
		public string ConnectionString { get; set; }
	}
}

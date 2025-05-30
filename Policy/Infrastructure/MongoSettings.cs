using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Policy.Infrastructure
{
    public class MongoSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string PoliciesCollectionName { get; set; } = null!;
        public string ClaimsCollectionName { get; set; } = null!;
    }
}


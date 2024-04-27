using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Store.Domain.Entities
{
    public class SystemRequirement
    {
        public Guid Id { get; set; }
        public string OS { get; set; }
        public string CPU { get; set; }
        public string Memory { get; set; }
        public string GPU { get; set; }
        public string DirectX { get; set; }
        public string DiskSpace { get; set; }
        public string LanguagesSupported { get; set; }
    }
}

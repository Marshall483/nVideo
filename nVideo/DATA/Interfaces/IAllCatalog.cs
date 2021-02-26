using nVideo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nVideo.DATA.Interfaces
{
    public interface IAllCatalog
    {

        public IEnumerable<Catalog_Entity> AllEntnty { get;}

    }
}

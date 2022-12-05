using SearchServiceTest.Repository;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;

namespace SearchServiceTest.Context
{
    public interface IContext
    {        
        IList<T> Set<T>() where T : IEntity;       
    }
}

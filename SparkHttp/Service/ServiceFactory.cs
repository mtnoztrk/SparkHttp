using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkHttp.Service
{
    public class ServiceFactory
    {
        public static IService GetService(Entity.Type serviceType)
        {
            switch (serviceType)
            {
                case Entity.Type.GET:
                    return new GetService();
                case Entity.Type.POST:
                    return new PostOrPutService();
                case Entity.Type.PUT:
                    return new PostOrPutService();
                case Entity.Type.DELETE:
                    return new DeleteService();
                default:
                    return null;
            }
        }
    }
}

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
                case Entity.Type.Get:
                    return new GetService();
                case Entity.Type.Post:
                    return new PostService();
                case Entity.Type.Put:
                    return new PutService();
                case Entity.Type.Delete:
                    return new DeleteService();
                default:
                    return null;
            }
        }
    }
}

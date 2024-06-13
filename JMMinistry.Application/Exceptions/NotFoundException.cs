using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMMinistry.Application.Exceptions
{
    public class NotFoundException(string resourceId) : Exception($"Resource: {resourceId}")
    {
    }
}

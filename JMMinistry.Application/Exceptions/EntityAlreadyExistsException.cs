using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMMinistry.Application.Exceptions;

public class EntityAlreadyExistsException<T>(string reference = "") : 
    Exception($"{typeof(T)} already exists {(string.IsNullOrEmpty(reference)? "" : $"with reference: {reference}")}")
{
}

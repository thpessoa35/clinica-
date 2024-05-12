using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalSolution.Application.Common.Interfaces.Kafka;

public interface IProducerKafka
{
    Task Producer(string topic, string message);
}
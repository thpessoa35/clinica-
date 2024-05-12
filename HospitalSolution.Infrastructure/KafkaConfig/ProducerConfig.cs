using Confluent.Kafka;
using HospitalSolution.Application.Common.Interfaces.Kafka;


namespace HospitalSolution.Infrastructure.KafkaConfig;

public class ProducerConfigKafka: IProducerKafka
{
    private readonly ProducerConfig config;

    public ProducerConfigKafka()
    {
        config = new ProducerConfig
        {
            BootstrapServers = "localhost:9092"
        };
    }

    public async Task Producer(string topic, string message)
    {
        using (var producer = new ProducerBuilder<Null, string>(config).Build())
        {
            try
            {
                var deliveryReport = await producer.ProduceAsync(topic, new Message<Null, string> { Value = message });

                Console.WriteLine($"Delivered message to {deliveryReport.TopicPartitionOffset}");
            }
            catch (ProduceException<Null, string> e)
            {
                Console.WriteLine($"Delivery failed: {e.Error.Reason}");
            }
        }
    }
}

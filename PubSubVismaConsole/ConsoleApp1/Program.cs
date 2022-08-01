using Microsoft.Extensions.Logging;
using PubSubService.DataClasses;
using PubSubService.Interfaces;
using PubSubService.Services;

//logging configuration
using var loggerFactory = LoggerFactory.Create(builder =>
{
    builder
        .AddFilter("Microsoft", LogLevel.Warning)
        .AddFilter("System", LogLevel.Warning)
        .AddFilter("NonHostConsoleApp.Program", LogLevel.Debug)
        .AddConsole();
});

ILogger logger = loggerFactory.CreateLogger<Program>();

///////////////////////////////////////////////////////////////////////////////////
//publisher/subsciber  usage sample
///////////////////////////////////////////////////////////////////////////////////

try
{

    IDataProcessor<Weather> upperCaseProcessor = new UpperCaseDataProcessor<Weather>();
    IMessageBroker broker = new MessageBroker(logger);
    broker.AddDataProcessor(upperCaseProcessor);

    IPublisher publisher = new Publisher(broker);
    IMessagePresenter presenter = new ConsoleMessagePresenter();

    ISubscriber sub1 = new DelegateBasedSubscriber(nameof(sub1), broker, presenter);
    sub1.Subscribe<Weather>();

    ISubscriber sub2 = new DelegateBasedSubscriber(nameof(sub2), broker, presenter);
    sub2.Subscribe<Weather>();
    sub2.Subscribe<CultureEvent>();

    Weather weather = new() { AirTemperature = 20, Description = "Cloudy" };
    Message<Weather> weatherMessage = new(weather);

    CultureEvent cultEvent = new() { Name = "concert", Place = "XXX Arena", BeginsAt = new DateTime(2022, 09, 10, 17, 0, 0) };
    Message<CultureEvent> cultEventMessage = new(cultEvent);

    publisher.Publish(weatherMessage);
    publisher.Publish(cultEventMessage);

    sub2.Subscribe<CultureEvent>(); //throws exception as the same subscription is already there

}catch(Exception ex)
{
    logger.LogError($"Unhandled exception occured: {ex.Message}");
}

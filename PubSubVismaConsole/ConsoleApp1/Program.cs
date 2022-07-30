using PubSubService.DataClasses;
using PubSubService.Interfaces;
using PubSubService.Services;

IDataProcessor<Weather> upperCaseProcessor = new UpperCaseDataProcessor<Weather>();
IMessageBroker broker = new MessageBroker();
broker.AddDataProcessor(upperCaseProcessor);

IPublisher publisher = new Publisher(broker);
IMessagePresenter presenter = new ConsoleMessagePresenter();

ISubscriber sub1 = new Subscriber(nameof(sub1), broker, presenter);
sub1.Subscribe<Weather>();

ISubscriber sub2 = new Subscriber(nameof(sub2), broker, presenter);
sub2.Subscribe<Weather>();
sub2.Subscribe<CultureEvent>();
sub2.Subscribe<CultureEvent>();

Weather weather = new() { AirTemperature = 20, Description = "Cloudy" };
Message<Weather> weatherMessage = new(weather);

CultureEvent cultEvent = new() { Name = "concert", Place = "XXX Arena", BeginsAt = new DateTime(2022, 09, 10, 17, 0, 0) };
Message<CultureEvent> cultEventMessage = new(cultEvent);

publisher.Publish(weatherMessage);
publisher.Publish(cultEventMessage);
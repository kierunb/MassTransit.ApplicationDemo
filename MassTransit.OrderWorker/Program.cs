using MassTransit;
using MassTransit.OrderWorker;
using MassTransit.OrderWorker.Consumers;
using System.Reflection;


// TODO: Run Worker as Windows Service/Linux Deamon
// https://learn.microsoft.com/en-us/dotnet/core/extensions/windows-service?pivots=dotnet-7-0
// dotnet add package Microsoft.Extensions.Hosting.WindowsServices
// Use sc.exe to manage Windows Service
// sc.exe create "Order Service" binpath="C:\Path\To\apka.dll"

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {

        services.AddWindowsService(options =>
        {
            options.ServiceName = "Order Worker";
        });

        //services.AddHostedService<Worker>();

        // MassTransit Configuration
        services.AddMassTransit(x =>
        {
            x.SetKebabCaseEndpointNameFormatter();

            // By default, sagas are in-memory, but should be changed to a durable
            // saga repository.
            x.SetInMemorySagaRepositoryProvider();

            var entryAssembly = Assembly.GetEntryAssembly();

            x.AddConsumers(entryAssembly);

            //x.AddConsumer<PingCommandConsumer>();

            x.AddSagaStateMachines(entryAssembly);
            x.AddSagas(entryAssembly);
            x.AddActivities(entryAssembly);

            // transport configuration
            //x.UsingInMemory((context, cfg) =>
            //{
            //    cfg.ConfigureEndpoints(context);
            //});

            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host("localhost", "/", h => {
                    h.Username("guest");
                    h.Password("guest");
                });

                cfg.ConfigureEndpoints(context);
            });
        });

    })
    .Build();

host.Run();


// Add those line to run worker as a Windows Service
//builder.Services.AddWindowsService(options =>
//{
//    options.ServiceName = ".NET Joke Service";
//});
using CoreWCF;
using CoreWCF.Channels;
using CoreWCF.Configuration;
using CoreWCF.Test.Server;

var builder = WebApplication.CreateBuilder(args);

//Enable CoreWCF Services, with metadata (WSDL) support
builder.Services.AddServiceModelServices()
    .AddServiceModelMetadata();

builder.WebHost.UseNetTcp(5072);

var app = builder.Build();

((IApplicationBuilder)app).UseServiceModel(builder =>
{
    // Add the Calculator Service
    builder.AddService<CalculatorService>(serviceOptions => { })
    // Add BasicHttpBinding endpoint
    .AddServiceEndpoint<CalculatorService, ICalculatorService>(new BasicHttpBinding(), "http://localhost:5070/CalculatorService/basichttp")
    .AddServiceEndpoint<CalculatorService, ICalculatorService>(new BasicHttpBinding(BasicHttpSecurityMode.Transport), "https://localhost:5071/CalculatorService/basichttp")
    .AddServiceEndpoint<CalculatorService, ICalculatorService>(new NetTcpBinding(), $"net.tcp://localhost:5072/CalculatorService/netTcp");
});

var serviceMetadataBehavior = app.Services.GetRequiredService<CoreWCF.Description.ServiceMetadataBehavior>();
serviceMetadataBehavior.HttpGetEnabled = true;

app.Run();

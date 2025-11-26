// Create a client with given client endpoint configuration
using CoreWCF.Test.Server;
using System.ServiceModel;
double value1 = 0D;
double value2 = 0D;
double result = 0D;

//CalculatorServiceClient client = new CalculatorServiceClient();


//// Call the Add service operation.
//value1 = 100.00D;
//value2 = 15.99D;
//result = client.Add(value1, value2);
//Console.WriteLine("Add({0},{1}) = {2}", value1, value2, result);

//// Call the Subtract service operation.
//value1 = 145.00D;
//value2 = 76.54D;
//result = client.Subtract(value1, value2);
//Console.WriteLine("Subtract({0},{1}) = {2}", value1, value2, result);

//// Call the Multiply service operation.
//value1 = 9.00D;
//value2 = 81.25D;
//result = client.Multiply(value1, value2);
//Console.WriteLine("Multiply({0},{1}) = {2}", value1, value2, result);

//// Call the Divide service operation.
//value1 = 22.00D;
//value2 = 7.00D;
//result = client.Divide(value1, value2);
//Console.WriteLine("Divide({0},{1}) = {2}", value1, value2, result);

////Closing the client gracefully closes the connection and cleans up resources
//await client.CloseAsync();



//Console.WriteLine();
//Console.WriteLine("Press <ENTER> to terminate client.");
//Console.ReadLine();


var binding = new NetTcpBinding();

var factory = new ChannelFactory<ICalculatorService>(binding, new EndpointAddress($"net.tcp://localhost:5072/CalculatorService/netTcp"));
factory.Open();
try
{
    ICalculatorService clientTcp = factory.CreateChannel();
    var channelTcp = clientTcp as IClientChannel;
    channelTcp.Open();

    value1 = 100.00D;
    value2 = 15.99D;
    result = clientTcp.Add(value1, value2);
    Console.WriteLine("Add({0},{1}) = {2}", value1, value2, result);

    // Call the Subtract service operation.
    value1 = 145.00D;
    value2 = 76.54D;
    result = clientTcp.Subtract(value1, value2);
    Console.WriteLine("Subtract({0},{1}) = {2}", value1, value2, result);

    // Call the Multiply service operation.
    value1 = 9.00D;
    value2 = 81.25D;
    result = clientTcp.Multiply(value1, value2);
    Console.WriteLine("Multiply({0},{1}) = {2}", value1, value2, result);

    // Call the Divide service operation.
    value1 = 22.00D;
    value2 = 7.00D;
    result = clientTcp.Divide(value1, value2);
    Console.WriteLine("Divide({0},{1}) = {2}", value1, value2, result);

    channelTcp.Close();
    Console.WriteLine(result);
}
finally
{
    factory.Close();
}


// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

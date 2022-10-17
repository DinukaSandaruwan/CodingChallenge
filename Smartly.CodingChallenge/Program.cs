using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace Smartly.CodingChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            //setup our DI
            var serviceProvider = new ServiceCollection()
                .AddLogging(c => c.AddConsole(opt => opt.LogToStandardErrorThreshold = LogLevel.Debug))
                .AddScoped<IPaySlipService, PaySlipService>()
                .AddScoped<IEmployeeService, EmployeeService>()
                .AddScoped<ITaxService, TaxService>()
                .BuildServiceProvider();

            var logger = serviceProvider.GetService<ILoggerFactory>()
                .CreateLogger<Program>();

            logger.LogDebug("Starting application........................");

            while (true)
            {

                Console.WriteLine("\r\n Please enter employee csv file path :");
                var filePath = Console.ReadLine();
                try
                {
                    using (var scope = serviceProvider.CreateScope())
                    {
                        var empService = serviceProvider.GetService<IEmployeeService>();
                        var payslip = serviceProvider.GetService<IPaySlipService>();

                        var empList = empService.GetEmployees(filePath);
                        empService.Print(empList);

                        var data = payslip.GetPaySlip(empList);
                        payslip.Print(data);
                    }
                }
                catch (Exception ex)
                {
                    logger.LogError(ex.StackTrace);
                }
            }

        }
    }
}

using Microsoft.Extensions.Logging;
using PromartTest.Job.Jobs.Base;
using System.Threading.Tasks;
using System.Threading;
using System;
using PromartTest.Job.Settings;
using Microsoft.Extensions.DependencyInjection;
using PromartTest.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using PromartTest.Job.Options;
using Microsoft.Extensions.Options;
using System.Net.Mail;
using System.Net;
using PromartTest.Entities.Models;
using ClosedXML.Excel;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Data;

namespace PromartTest.Job.Jobs.Services
{
    public class ReportService : CronBackgroundJob
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<ReportService> _log;
        private readonly IOptions<FilterOptions> _filterOptions;
        private readonly IOptions<SmtpOptions> _smtpOptions;

        public ReportService(CronSettings<ReportService> settings, ILogger<ReportService> log, IServiceProvider serviceProvider, IOptions<FilterOptions> filterOptions, IOptions<SmtpOptions> smtpOptions)
            : base(settings.CronExpression, settings.TimeZone)
        {
            _log = log;
            _filterOptions = filterOptions;
            _smtpOptions = smtpOptions;
            _serviceProvider = serviceProvider;
        }

        protected override async Task DoWork(CancellationToken stoppingToken)
        {
            _log.LogInformation("Running... at {0}", DateTime.UtcNow);

            try
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                    _log.LogInformation("Reading filtering data...");
                    var startDate = DateTime.Parse(_filterOptions.Value.StartDate);
                    var endDate = DateTime.Parse(_filterOptions.Value.EndDate);

                    _log.LogInformation("Reading employee data...");
                    var employees = await db.Employees
                        .Where(x => x.AdmissionDate >= startDate && x.AdmissionDate <= endDate)
                        .AsNoTracking()
                        .ToListAsync();

                    _log.LogInformation("Generating excel file...");
                    using (var ms = new MemoryStream())
                    {
                        var wb = new XLWorkbook();

                        var table = new DataTable();
                        table.TableName = "EMPLEADOS";
                        table.Columns.Add("Id", typeof(int));
                        table.Columns.Add("Name", typeof(string));
                        table.Columns.Add("DocumentNumber", typeof(string));
                        table.Columns.Add("Salary", typeof(double));
                        table.Columns.Add("Age", typeof(int));
                        table.Columns.Add("Profile", typeof(string));
                        table.Columns.Add("AdmissionDate", typeof(DateTime));
                        table.Columns.Add("CreatedAt", typeof(DateTime));
                        table.Columns.Add("UpdatedAt", typeof(DateTime));

                        foreach (var employee in employees)
                        {
                            table.Rows.Add(employee.Id, employee.Name, employee.DocumentNumber,
                                employee.Salary, employee.Age, employee.Profile, employee.AdmissionDate,
                                employee.CreatedAt, employee.UpdatedAt);
                        }

                        // Add a DataTable as a worksheet
                        wb.Worksheets.Add(table);
                        wb.SaveAs(ms);
                        ms.Seek(0, SeekOrigin.Begin);

                        _log.LogInformation("Sending email...");
                        var client = new SmtpClient("smtp.gmail.com", 587)
                        {
                            Credentials = new NetworkCredential(_smtpOptions.Value.EmailAccount, _smtpOptions.Value.EmailPassword),
                            EnableSsl = true,
                        };
                        var fromMailAddress = new MailAddress(_smtpOptions.Value.EmailAccount, _smtpOptions.Value.EmailAccount);
                        var toMailAddress = new MailAddress(_smtpOptions.Value.ReportAccount, _smtpOptions.Value.ReportAccount);
                        var mailMessage = new MailMessage(fromMailAddress, toMailAddress);
                        mailMessage.Subject = "Reporte de Empleados";
                        mailMessage.Body = $"Fecha de Inicio: {startDate.ToShortDateString()}. Fecha de Fin: {endDate.ToShortDateString()}";
                        mailMessage.Attachments.Add(new Attachment(ms, "Reporte.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"));

                        await client.SendMailAsync(mailMessage);
                        ms.Close();
                        _log.LogInformation("Finishing job...");
                    }
                }
            }
            catch(Exception ex)
            {
                _log.LogError(ex.StackTrace);
            }

            await Task.CompletedTask;
        }

    }
}

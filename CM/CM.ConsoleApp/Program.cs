using CM.Application.Interfaces;
using CM.Domain.Entities;
using CM.Infrasructure;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var container = new Container(c =>
            {
                c.AddRegistry<ComponentRegistry>();
                c.AddRegistry<DataRegistry>();
            });

            RunServices(container).Wait();

            Console.ReadLine();
        }

        private static async Task RunServices(IContainer container)
        {
            var documentLibraryService = container.GetInstance<IDocumentLibraryService>();
            var exceptionLogService = container.GetInstance<IExceptionLogService>();

            DisplayDocumentLibraryOutput(await documentLibraryService.SelectCurrentMetaData("WoundAssessmentDocument", 135700));
            DisplayDocumentLibraryOutput(await documentLibraryService.MakeUpdatesWithTransaction("WoundAssessmentDocument", 135700));

            //await exceptionLogService.LogException(new Exception("Oh hey!"), 4382, 2529, 88341, "PageName", Environment.MachineName);
            //await exceptionLogService.DeleteLastException();

            DisplayExceptionLogOutput(await exceptionLogService.SelectCurrentExceptionData(10, 0));
        }

        private static void DisplayDocumentLibraryOutput(IEnumerable<Document> documents)
        {
            foreach (var doc in documents)
            {
                Console.Write($"Doc ID: {doc.DocumentID}, Title: \"{doc.Title}\", VisitID: {doc.VisitID}");

                if (doc.Visit != null) Console.Write($", Visit Type ID: {doc.Visit.VisitTypeID}");
                if (doc.Visit?.VisitType != null) Console.Write($", Visit Type: {doc.Visit.VisitType.CodeValue}");
                if (doc.LastUpdatedUser != null) Console.Write($", Last Updated By: {doc.LastUpdatedUser.FullName}");

                Console.WriteLine();
            }
        }

        private static void DisplayExceptionLogOutput(IEnumerable<ExceptionLog> exceptionLog)
        {
            foreach (var ex in exceptionLog)
            {
                Console.WriteLine($"Ex ID: {ex.ExceptionID}, FacilityID: {ex.FacilityID}, UserID: {ex.UserID}s, Time: { ex.Time}");

                if (ex.PageName != null && !ex.PageName.Equals(""))
                    Console.WriteLine($"\tPage Name: {ex.PageName}");
                else
                    Console.WriteLine($"\tPage Name: None Specified");

                if (ex.Method != null && !ex.Method.Equals(""))
                    Console.WriteLine($"\tMethod: {ex.Method}");
                else
                    Console.WriteLine($"\tMethod: None Specified");
                if (ex.Message != null && !ex.Message.Equals(""))
                    Console.WriteLine($"\tMessage: {ex.Message}");
                else
                    Console.WriteLine($"\tMessage: None Specified");

                Console.WriteLine();
            }
        }
    }
}

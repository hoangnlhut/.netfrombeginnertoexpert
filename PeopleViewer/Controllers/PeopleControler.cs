using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonReader.CSV;
using PersonReader.Factory;
using PersonReader.Interface;

namespace PeopleViewer.Controllers
{
    // no refences to specific data readers

    public class PeopleControler : Controller
    {
        private ReaderFactory _readerFactory = new ReaderFactory();
        public IActionResult UseService()
        {
            return PopulatePeopleView("Service");
        }

        public IActionResult UseCSV()
        {
            return PopulatePeopleView("CSV");
        }

        public IActionResult UseSQL()
        {
            return PopulatePeopleView("SQLServer");
        }

        private IActionResult PopulatePeopleView(string readerFac)
        {
            ViewData["Title"] = $"Using {readerFac}";
            IPersonReader reader = _readerFactory.GetReader(readerFac);
            IEnumerable<Person> people = reader.GetPeople();
            ViewData["ReaderType"] = reader.GetType().ToString();
            return View("Index", people);
        }

    }
}

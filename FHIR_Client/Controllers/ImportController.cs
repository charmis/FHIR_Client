using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using FHIR_Client.Models;
using FHIR_Client.Services;

namespace FHIR_Client.Controllers
{
    public class ImportController : Controller
    {
        // GET: Import
        public async Task<ActionResult> Index()
        {
            PatientService service = new PatientService();
            var patients = await Task.Run(() => service.GetPatients());
            return View(patients);
        }

        public ActionResult ImportPatients()
        {
            //GetPatients();
            return View();
        }

        
    }
}
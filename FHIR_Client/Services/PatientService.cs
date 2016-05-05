using FHIR_Client.FHIR_Models;
using FHIR_Client.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace FHIR_Client.Services
{
    public class PatientService
    {
        public async Task<List<Patient>> GetPatients()
        {
            List<Patient> patients = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://spark.furore.com/fhir/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP GET
                HttpResponseMessage response = await client.GetAsync("Patient");

                if (response.IsSuccessStatusCode)
                {
                    try
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        var bundle = JsonConvert.DeserializeObject<Bundle>(result);
                        patients = new List<Patient>();

                        foreach (var item in bundle.entry)
                        {
                            var patient = new Patient
                                {
                                    id = item.resource.id,
                                    BirthDate = item.resource.birthDate,
                                    Gender = item.resource.gender
                                };

                            string name = string.Empty;

                            if (item.resource.name != null)
                            {
                                if (item.resource.name[0].given != null)
                                {
                                    name = item.resource.name[0].given[0];
                                }

                                if (item.resource.name[0].family != null)
                                {
                                    if (name.Length > 0)
                                    {
                                        name = name + " " + item.resource.name[0].family[0];
                                    }
                                    else
                                    {
                                        name = item.resource.name[0].family[0];
                                    }
                                }
                            }
                            patient.Name = name;
                            patients.Add(patient);
                        }
                    }
                    catch (Exception ex) {
                    }
                }
            }

            return patients;
        }
    }
}
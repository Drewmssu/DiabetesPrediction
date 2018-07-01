using DiabetesPredictionApp.DataLayer;
using DiabetesPredictionApp.Helpers;
using DiabetesPredictionApp.Services.DiabetesPredictionAML;
using DiabetesPredictionApp.ViewModels.Entry;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Transactions;
using System.Web.Mvc;

namespace DiabetesPredictionApp.Controllers
{
    public class EntryController : BaseController
    {
        public ActionResult ListRegistros(int? p)
        {
            var vm = new ListRegistrosViewModel();
            vm.Fill(CargarDatosContext(), p);
            return View(vm);
        }

        public ActionResult AddEditRegistro(int? subjectId)
        {
            var vm = new AddEditRegistroViewModel();
            vm.Fill(CargarDatosContext(), subjectId);
            return View(vm);
        }

        [HttpPost]
        public ActionResult AddEditRegistro(AddEditRegistroViewModel model)
        {
            try
            {
                using (var ts = new TransactionScope())
                {
                    var subject = context.Subject.Find(model.SubjectId);

                    if (subject is null)
                    {
                        subject = new Subject
                        {
                            CreatedAt = DateTime.Now,
                            State = ConstantHelpers.ESTADO.NOT_TESTED
                        };

                        context.Subject.Add(subject);
                    }

                    subject.Name = model.Name;
                    subject.LastName = model.LastName;
                    subject.TimesPregnant = model.TimesPregnant;
                    subject.PlasmaGlucose = model.PlasmaGlucose;
                    subject.DistolicBlood = model.DistolicBlood;
                    subject.TricepsSFT = model.TricepsSFT;
                    subject.SerumInsuline2Hour = model.SerumInsuline2Hour;
                    subject.BodyMassIndex = model.BodyMassIndex;
                    subject.DiabetesPedigreeFunction = model.DiabetesPedigreeFunction;
                    subject.Age = model.Age;
                    subject.ProbabilityOfDiabetes = model.ProbabilityOfDiabetes;

                    context.SaveChanges();
                    ts.Complete();
                    AlertNotification("success", "Registry saved", "Success!");
                    return RedirectToAction("ListRegistros", "Entry");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                AlertNotification("error", e.Message, "Error!");
                return RedirectToAction("ListRegistros", "Entry");
            }
        }

        [HttpPost]
        public ActionResult DeleteRegistro(int registryId)
        {
            try
            {
                using (var ts = new TransactionScope())
                {
                    var registry = context.Subject.Find(registryId);

                    registry.State = ConstantHelpers.ESTADO.INACTIVO;

                    context.SaveChanges();
                    ts.Complete();
                    return new EmptyResult();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new EmptyResult();
            }
        }

        [HttpPost]
        public JsonResult Consume(string timesPregnant, string plasma, string bloodPressure, string tricepsThickness,
            string serum, string bodyMassIndex, string diabetesPedigree, string age)
        {
            var tmp = new string[,]
            {
                {
                    timesPregnant,
                    plasma,
                    bloodPressure,
                    tricepsThickness,
                    serum,
                    bodyMassIndex,
                    diabetesPedigree,
                    age,
                    "0"
                }
            };

            var response = new PredictAppAzureMLService().Consume(tmp).Result;
            var result = JsonConvert.DeserializeObject<OutputResultRoot>(response);
            var probAux = result.Results.output1.value.Values[0].Last().ToDecimal();
            var prob = Math.Round(probAux, 4);            

            return Json(prob, JsonRequestBehavior.AllowGet); 
        }
    }
}
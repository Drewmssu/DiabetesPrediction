using DiabetesPredictionApp.DataLayer.Base;
using System.ComponentModel.DataAnnotations;

namespace DiabetesPredictionApp.ViewModels.Entry
{
    public class AddEditRegistroViewModel
    {
        public int? SubjectId { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;
        [Required]
        public int Age { get; set; }
        [Required]
        [Display(Name = "Number of times pregnant")]
        public int TimesPregnant { get; set; }
        [Required]
        [Display(Name = "Plasma glucose concentration for 2 hour")]
        public float PlasmaGlucose { get; set; }
        [Required]
        [Display(Name = "Diastolic blood pressure (mm Hg)")]
        public float DistolicBlood { get; set; }
        [Required]
        [Display(Name = "Triceps skinfold thickness (mm)")]
        public float TricepsSFT { get; set; }
        [Required]
        [Display(Name = "2-Hour serum insulin (mu U/ml)")]
        public float SerumInsuline2Hour { get; set; }
        [Required]
        [Display(Name = "Body mass index")]
        public float BodyMassIndex { get; set; }
        [Required]
        [Display(Name = "Diabetes pedigree function")]
        public float DiabetesPedigreeFunction { get; set; }
        [Display(Name = "Diabetes Probability(%)")]
        public decimal? ProbabilityOfDiabetes { get; set; }

        internal void Fill(CargarDatosContex dataContext, int? subjectId)
        {
            var subject = dataContext.context.Subject.Find(subjectId);

            if (subject is null) return;
            this.Name = subject.Name;
            this.LastName = subject.LastName;
            this.TimesPregnant = subject.TimesPregnant;
            this.PlasmaGlucose = (float)subject.PlasmaGlucose;
            this.DistolicBlood = (float)subject.DistolicBlood;
            this.TricepsSFT = (float)subject.TricepsSFT;
            this.SerumInsuline2Hour = (float)subject.SerumInsuline2Hour;
            this.BodyMassIndex = (float)subject.BodyMassIndex;
            this.DiabetesPedigreeFunction = (float)subject.DiabetesPedigreeFunction;
            this.Age = subject.Age;
            this.ProbabilityOfDiabetes = subject.ProbabilityOfDiabetes ?? 0;
        }
    }
}
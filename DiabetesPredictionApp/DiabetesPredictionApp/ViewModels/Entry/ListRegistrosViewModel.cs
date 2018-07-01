using DiabetesPredictionApp.DataLayer;
using DiabetesPredictionApp.DataLayer.Base;
using DiabetesPredictionApp.Helpers;
using PagedList;
using System.Linq;

namespace DiabetesPredictionApp.ViewModels.Entry
{
    public class ListRegistrosViewModel
    {
        public int p { get; set; }
        public IPagedList<Subject> LstRegistros { get; set; }

        internal void Fill(CargarDatosContex dataContext, int? p)
        {
            this.p = p ?? 1;

            var query = dataContext.context.Subject.Where(x => x.State != ConstantHelpers.ESTADO.INACTIVO).AsQueryable();

            this.LstRegistros = query.OrderBy(x => x.LastName).ToPagedList(this.p, ConstantHelpers.DEFAULT_PAGE_SIZE);
        }
    }
}
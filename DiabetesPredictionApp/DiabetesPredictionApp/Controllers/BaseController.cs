using DiabetesPredictionApp.DataLayer.Base;
using DiabetesPredictionApp.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DiabetesPredictionApp.Helpers;

namespace DiabetesPredictionApp.Controllers
{
    public class BaseController : Controller
    {
        protected CargarDatosContex cargarDatoxContext { get; set; }
        protected DiabetesDBEntities context { get; set; }
        public BaseController()
        {
            context = new DiabetesDBEntities();
        }

        public void InvalidarContext()
        {
            context = new DiabetesDBEntities();
        }

        public CargarDatosContex CargarDatosContext()
        {
            if(cargarDatoxContext == null)
            {
                cargarDatoxContext = new CargarDatosContex { context = context };
            }

            return cargarDatoxContext;
        }

        public void AlertNotification(string type, string message, string title) => TempData["AlertNotification"] =
            UIHelpers.RenderAlertNotificacion(type, message, title);

        public void PostMessage(FlashMessage message)
        {
            if (TempData["FlashMessages"] == null)
                TempData["FlashMessages"] = new List<FlashMessage>();

            var list = ((List<FlashMessage>)TempData["FlashMessages"]);
            list.Add(message);
        }

        public void PostMessage(MessageType type, bool removeOnError = false)
        {
            var body = string.Empty;

            switch (type)
            {
                case MessageType.Error:
                    body = "Ha ocurrido un error al procesar la solicitud.";
                    break;
                case MessageType.Info:
                    body = String.Empty;
                    break;
                case MessageType.Success:
                    body = "Los datos se guardaron exitosamente.";
                    break;
                case MessageType.Warning:
                    body = ".";
                    break;
            }

            PostMessage(type, body, removeOnError);
        }

        public void PostMessage(Exception ex, bool removeOnError = false)
        {
            PostMessage(MessageType.Error,
                "Ha ocurrido un error al procesar la solicitud: " + ex.Message.ToSafeString(), removeOnError);
        }

        public void PostMessage(MessageType messageType, string title, string body, bool removeOnError = false)
        {
            PostMessage(
                new FlashMessage { Title = title, Body = body, Type = messageType, RemoveOnError = removeOnError });
        }

        public void PostMessage(MessageType messageType, string body, bool removeOnError = false)
        {
            var title = String.Empty;

            switch (messageType)
            {
                case MessageType.Error:
                    title = "¡Error!";
                    break;
                case MessageType.Info:
                    title = "Ojo.";
                    break;
                case MessageType.Success:
                    title = "¡Éxito!";
                    break;
                case MessageType.Warning:
                    title = "¡Atención!";
                    break;
            }

            PostMessage(
                new FlashMessage { Title = title, Body = body, Type = messageType, RemoveOnError = removeOnError });
        }

        public ActionResult RedirectToActionPartialView(string actionName)
        {
            return RedirectToActionPartialView(actionName, null, null);
        }

        public ActionResult RedirectToActionPartialView(string actionName, object routeValues)
        {
            return RedirectToActionPartialView(actionName, null, routeValues);
        }

        public ActionResult RedirectToActionPartialView(string actionName, string controllerName)
        {
            return RedirectToActionPartialView(actionName, controllerName, null);
        }

        public ActionResult RedirectToActionPartialView(string actionName, string controllerName, object routeValues)
        {
            var url = Url.Action(actionName, controllerName, routeValues);
            return Content("<script> window.location = '" + url + "'</script>");
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Request.Params == filterContext.ActionParameters)
            {
            }

            base.OnActionExecuting(filterContext);
        }
    }
}
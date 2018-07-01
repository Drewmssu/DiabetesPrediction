using System.Text;

namespace DiabetesPredictionApp.Helpers
{
    public class UIHelpers
    {
        public static string RenderPlaneNotification(string type, string message)
        {
            var sb = new StringBuilder();

            sb.Append($"<div class=\"alert alert-{type} alert-dismissible fade show\" role=\"alert\">")
                .Append(message)
                .Append("<button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\"><span aria-hidden=\"true\">×</span></button></div>");

            return sb.ToString();
        }

        public static string RenderAlertNotificacion(string type, string message, string title)
        {
            var sb = new StringBuilder();

            sb.Append("<script>")
                .Append("$(document).ready(function () {")
                .Append("swal({")
                .Append($"title: '{title}',")
                .Append($"text: '{message}',")
                .Append($"type: '{type}',")
                .Append("allowOutsideClick: false")
                .Append("})")
                .Append("});")
                .Append("</script>");

            return sb.ToString();
        }
    }
}

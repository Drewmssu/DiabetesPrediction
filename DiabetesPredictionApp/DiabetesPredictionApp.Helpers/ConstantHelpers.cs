using System;
using System.Collections.Generic;
using System.Configuration;
using PagedList.Mvc;

namespace DiabetesPredictionApp.Helpers
{
    public static class ConstantHelpers
    {       
        public const Int32 DEFAULT_PAGE_SIZE = 50;
        public const Int32 DEFAULT_PAGE_SIZE_MODAL = 10;
        public const Int32 DEFAULT_PAGE_SIZE_MOBILE = 10;
        public const String TEXTO_SELECCIONAR = "[ - Seleccionar - ]";

        public static class EXTENSION_REPORTE
        {
            public static readonly String PDF = "PDF";
            public static readonly String EXCEL = "XLS";
        }

        public static readonly String[] EXTENSION_IMAGEN = { "JPG", "JPEG", "PNG", "GIF", "BMP", "TIFF" };
              
        public static class LAYOUT
        {
            public static readonly String MODAL_LAYOUT_PATH = "~/Views/Shared/_ModalLayout.cshtml";
            public static readonly String MODAL_EMAIL_PATH = "~/Views/Shared/_MailLayout.cshtml";
            public static readonly String DEFAULT_LAYOUT_PATH = "~/Views/Shared/_Layout.cshtml";
            public static readonly String LOGIN_LAYOUT_PATH = "~/Views/Shared/_LoginLayout.cshtml";
        }
              
        public static class ESTADO
        {
            public const string DISPONIBLE = "DIS";
            public const string ACTIVO = "ACT";
            public const string INACTIVO = "INA";
            public const string ELIMINADO = "ELI";
            public const string PROCESADO = "PRO";
            public const string ANULADO = "ANL";
            public const string PENDIENTE = "PEN";
            public const string CONFIRMADO = "CON";
            public const string ATENDIDO = "ATE";
            public const string RECHAZADO = "REC";
            public const string SUSPENDIDO = "SUS";
            public const string EXTORNADO = "EXT";
            public const string REGISTRADO = "REG";
            public const string RESERVADO = "RES";
            public const string CONSULTA = "CNS";
            public const string FINALIZADO = "FIN";
            public const string AGOTADO = "AGO";
            public const string ACTUALIZADO = "ACL";
            public const string PROGRAMADA = "PRG";
            public const string SOLICITADO = "SOL";
            public const string OCUPADO = "OCU";
            public const string ASIGNADO = "ASG";
            public const string VENCIDO = "VEN";
            public const string EN_RUTA = "ERU";
            public const string ENTREGADO = "ENT";
            public const string OBSERVADO = "OBS";
            public const string TESTED = "TES";
            public const string NOT_TESTED = "NTE";

            public static string GetNameEstado(string Estado)
            {
                switch (Estado)
                {
                    case DISPONIBLE:
                        return "DISPONIBLE";
                    case ACTIVO:
                        return "ACTIVO";
                    case INACTIVO:
                        return "INACTIVO";
                    case PROCESADO:
                        return "PROCESADO";
                    case ANULADO:
                        return "ANULADO";
                    case SUSPENDIDO:
                        return "SUSPENDIDO";
                    case ELIMINADO:
                        return "ELIMINADO";
                    case CONFIRMADO:
                        return "CONFIRMADO";
                    case EXTORNADO:
                        return "EXTORNADO";
                    case REGISTRADO:
                        return "REGISTRADO";
                    case PENDIENTE:
                        return "PENDIENTE";
                    case ATENDIDO:
                        return "DESPACHADO";
                    case RECHAZADO:
                        return "RECHAZADO";
                    case RESERVADO:
                        return "RESERVADO";
                    case CONSULTA:
                        return "CONSULTA";
                    case FINALIZADO:
                        return "FINALIZADO";
                    case AGOTADO:
                        return "AGOTADO";
                    case ACTUALIZADO:
                        return "ACTUALIZADO";
                    case PROGRAMADA:
                        return "PROGRAMADO";
                    case SOLICITADO:
                        return "SOLICITADO";
                    case OCUPADO:
                        return "OCUPADO";
                    case ASIGNADO:
                        return "ASIGNADO";
                    case VENCIDO:
                        return "VENCIDO";
                    case EN_RUTA:
                        return "EN RUTA";
                    case ENTREGADO:
                        return "ENTREGADO";
                    case OBSERVADO:
                        return "OBSERVADO";
                    case TESTED:
                        return "TESTED";
                    case NOT_TESTED:
                        return "NOT TESTED";
                }
                return string.Empty;
            }
            public static string GetLabelEstado(string Estado)
            {
                switch (Estado)
                {
                    case DISPONIBLE:
                        return "<label class='label label-success'>DISPONIBLE</label>";
                    case ACTIVO:
                        return "<label class='label label-success'>ACTIVO</label>";
                    case INACTIVO:
                        return "<label class='label label-danger'>INACTIVO</label>";
                    case PROCESADO:
                        return "<label class='label label-success'>PROCESADO</label>";
                    case ANULADO:
                        return "<label class='label label-danger'>ANULADO</label>";
                    case SUSPENDIDO:
                        return "<label class='label label-default'>SUSPENDIDO</label>";
                    case CONFIRMADO:
                        return "<label class='label label-info'>CONFIRMADO</label>";
                    case ELIMINADO:
                        return "<label class='label label-danger'>ELIMINADO</label>";
                    case EXTORNADO:
                        return "<label class='label label-danger'>EXTORNADO</label>";
                    case REGISTRADO:
                        return "<label class='label label-info'>REGISTRADO</label>";
                    case PENDIENTE:
                        return "<label class='label label-warning'>PENDIENTE</label>";
                    case ATENDIDO:
                        return "<label class='label label-success'>ATENDIDO</label>";
                    case RESERVADO:
                        return "<label class='label label-purple'>RESERVADO</label>";
                    case RECHAZADO:
                        return "<label class='label label-danger'>RECHAZADO</label>";
                    case CONSULTA:
                        return "<label class='label label-info'>CONSULTA</label>";
                    case FINALIZADO:
                        return "<label class='label label-success'>FINALIZADO</label>";
                    case AGOTADO:
                        return "<label class='label label-danger'>AGOTADO</label>";
                    case ACTUALIZADO:
                        return "<label class='label label-success'>ACTUALIZADO</label>";
                    case PROGRAMADA:
                        return "<label class='label label-purple'>PROGRAMADA</label>";
                    case SOLICITADO:
                        return "<label class='label label-inverse'>SOLICITADO</label>";
                    case OCUPADO:
                        return "<label class='label label-warning'>OCUPADO</label>";
                    case ASIGNADO:
                        return "<label class='label label-inverse'>ASIGNADO</label>";
                    case VENCIDO:
                        return "<label class='label label-inverse'>VENCIDO</label>";
                    case EN_RUTA:
                        return "<label class='label label-success'>EN RUTA</label>";
                    case ENTREGADO:
                        return "<label class='label label-info'>ENTREGADO</label>";
                    case OBSERVADO:
                        return "<label class='label label-warning'>OBSERVADO</label>";
                    case TESTED:
                        return "<label class='label label-success'>TESTED</label>";
                    case NOT_TESTED:
                        return "<label class='label label-warning'>NOT TESTED</label>";
                }
                return string.Empty;
            }
        }

        public static PagedListRenderOptions Bootstrap4Pager => new PagedListRenderOptions
        {
            DisplayLinkToFirstPage = PagedListDisplayMode.IfNeeded,
            DisplayLinkToLastPage = PagedListDisplayMode.IfNeeded,
            DisplayLinkToPreviousPage = PagedListDisplayMode.IfNeeded,
            DisplayLinkToNextPage = PagedListDisplayMode.IfNeeded,
            DisplayLinkToIndividualPages = true,
            DisplayPageCountAndCurrentLocation = false,
            MaximumPageNumbersToDisplay = 10,
            DisplayEllipsesWhenNotShowingAllPageNumbers = true,
            EllipsesFormat = "&#8230;",
            LinkToFirstPageFormat = "««",
            LinkToPreviousPageFormat = "«",
            LinkToIndividualPageFormat = "{0}",
            LinkToNextPageFormat = "»",
            LinkToLastPageFormat = "»»",
            PageCountAndCurrentLocationFormat = "Page {0} of {1}.",
            ItemSliceAndTotalFormat = "Showing items {0} through {1} of {2}.",
            FunctionToDisplayEachPageNumber = null,
            ClassToApplyToFirstListItemInPager = null,
            ClassToApplyToLastListItemInPager = null,
            ContainerDivClasses = new List<string> { "nav text-xs-center" },
            UlElementClasses = new List<string> { "pagination", "pagination sm" },
            LiElementClasses = new List<string> { "page-item" },
            FunctionToTransformEachPageLink = (liTag, aTag) =>
            {
                aTag.Attributes.Add("class", "page-link");
                liTag.InnerHtml = aTag.ToString();
                return liTag;
            }
        };

        public static string GetDataConfiguration(string key) => string.IsNullOrEmpty(key)
            ? string.Empty
            : ConfigurationManager.AppSettings[key].ToSafeString();

        public static string ToTitleCase(this string str) => new System.Globalization.CultureInfo("en-US", false).TextInfo.ToTitleCase(str.ToLower());
    }
}

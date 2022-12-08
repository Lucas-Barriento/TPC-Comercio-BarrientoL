using dominio;
using iTextSharp.text.pdf;
using iTextSharp.text;
using iTextSharp.tool.xml;
using Microsoft.Win32;
using negocio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;

namespace TPC_BarrientoL
{
    public partial class DetalleCompra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"]!=null)
            {
            int id = int.Parse(Request.QueryString["id"].ToString());
            DetalleTransactionNegocio detalle = new DetalleTransactionNegocio();
            dgvDetalleCompras.DataSource = detalle.ListarCompra(id);
            dgvDetalleCompras.DataBind();
            }
        }

        protected void btnDescargar_Click(object sender, EventArgs e)
        {
            List<DetalleTransaccion> lista = new List<DetalleTransaccion>();
            int id = int.Parse(Request.QueryString["id"].ToString());
            DetalleTransactionNegocio detalle = new DetalleTransactionNegocio();
            lista = detalle.ListarCompra(id);

            CompraNegocio compraNegocio = new CompraNegocio();
            Compra compra = compraNegocio.Listar().Find(x => x.ID == id);

            SaveFileDialog savefile = new SaveFileDialog();

            string PaginaHTML_Texto = Properties.Resources.FacturaCompra.ToString();
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@DOMICILIO", compra.Proveedor.Domicilio.ToString()+", "+ compra.Proveedor.Localidad.ToString());
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@TELEFONO", compra.Proveedor.Telefono.ToString());
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@PROVEEDOR", compra.Proveedor.Nombre.ToString());
            //PaginaHTML_Texto = PaginaHTML_Texto.Replace("@DOCUMENTO", venta.cliente.Id.ToString());
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@FECHA", compra.FechaCompra.ToString("d"));
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@FACTURA", compra.ID.ToString());


            string filas = string.Empty;
            decimal total = 0;
            foreach (var item in lista)
            {
                filas += "<tr>";
                filas += "<td>" + item.producto.Nombre.ToString() + "</td>";
                filas += "<td>" + item.Cantidad.ToString() + "</td>";
                filas += "<td>" + (item.PrecioParcial / item.Cantidad).ToString() + "</td>";
                filas += "<td>" + item.PrecioParcial.ToString() + "</td>";
                filas += "</tr>";
                total += decimal.Parse(item.PrecioParcial.ToString());
            }
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@FILAS", filas);
            PaginaHTML_Texto = PaginaHTML_Texto.Replace("@TOTAL", total.ToString());

            if (MessageBox.Show("Desea descargar esta factura?", "Guardar", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
            {
                //Creamos un nuevo documento y lo definimos como PDF
                Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 25);


                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, HttpContext.Current.Response.OutputStream);
                pdfDoc.Open();
                pdfDoc.Add(new Phrase(""));

                //Agregamos la imagen del banner al documento
                iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(Properties.Resources.logoComercio, System.Drawing.Imaging.ImageFormat.Png);
                img.ScaleToFit(60, 60);
                img.Alignment = iTextSharp.text.Image.UNDERLYING;

                //img.SetAbsolutePosition(10,100);
                img.SetAbsolutePosition(pdfDoc.LeftMargin, pdfDoc.Top - 60);
                pdfDoc.Add(img);

                using (StringReader sr = new StringReader(PaginaHTML_Texto))
                {
                    XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                }

                pdfDoc.Close();

                Response.ContentType = "application/pdf";
                string filename = "attachment;filename= resumen_" + compra.FechaCompra.ToString("ddMMyyyy") + compra.Proveedor.Id.ToString() + compra.ID.ToString() + ".pdf";
                Response.AddHeader("content-disposition", filename);
                HttpContext.Current.Response.Write(pdfDoc);
                Response.Flush();
                Response.End();


            }

        }
    }
}
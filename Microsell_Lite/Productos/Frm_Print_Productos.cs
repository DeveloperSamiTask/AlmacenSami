using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Prj_Capa_Negocio;

namespace Microsell_Lite.Productos
{
    public partial class Frm_Print_Productos : Form
    {
        public Frm_Print_Productos()
        {
            InitializeComponent();
        }

        private void Frm_Print_NotaVenta_Load(object sender, EventArgs e)
        {           

        }

        private void pnl_titu_MouseMove(object sender, MouseEventArgs e)
        {
            Utilitario obj = new Utilitario();

            if (e.Button == MouseButtons.Left)
            {
                obj.Mover_formulario(this);

            }
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Imprimir_Listado_Producto()
        {           
           
                Rpte_Listado_Productos reporte = new Rpte_Listado_Productos();
                vsr_impre.ReportSource = reporte;               
                reporte.Refresh();                
                vsr_impre.ReportSource = reporte;             
            

        }

        private void Imprimir_Listado_PrecioProd()
        {

            Rpte_Listado_Precios reporte = new Rpte_Listado_Precios();
            vsr_impre.ReportSource = reporte;
            reporte.Refresh();
            vsr_impre.ReportSource = reporte;


        }

        private void Imprimir_Listado_stockProd()
        {

            Rpte_Listado_Stock reporte = new Rpte_Listado_Stock();
            vsr_impre.ReportSource = reporte;
            reporte.Refresh();
            vsr_impre.ReportSource = reporte;


        }

        private void Imprimir_Listado_ValorAl()
        {

            Rpte_Listado_ValorAlmacen reporte = new Rpte_Listado_ValorAlmacen();
            vsr_impre.ReportSource = reporte;
            reporte.Refresh();
            vsr_impre.ReportSource = reporte;


        }

        private void btn_Print_Click(object sender, EventArgs e)
        {
            vsr_impre.PrintReport();
        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            vsr_impre.ExportReport();
        }

       /*private void exportar()
        {
            // Declare variables and get the export options.
            ExportOptions exportOpts = new ExportOptions();
            ExcelFormatOptions excelFormatOpts = new ExcelFormatOptions();
            DiskFileDestinationOptions diskOpts = new DiskFileDestinationOptions();
            exportOpts = vs.ExportOptions;

            // Set the excel format options.
            excelFormatOpts.ExcelUseConstantColumnWidth = true;
            excelFormatOpts.ExcelTabHasColumnHeadings = true;
            exportOpts.ExportFormatType = ExportFormatType.Excel;
            exportOpts.FormatOptions = excelFormatOpts;

            // Set the disk file options and export.
            exportOpts.ExportDestinationType = ExportDestinationType.DiskFile;
            diskOpts.DiskFileName = fileName;
            exportOpts.DestinationOptions = diskOpts;

            vs.Export();
        }*/

        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            vsr_impre.RefreshReport();  
        }

        
        private void reporteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void listadoDeProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Text = "Impresion de Lista de Productos";
            Imprimir_Listado_Producto();
        }

        private void listadoDePreciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Text = "Impresion de Lista de Precios de Productos ";
            Imprimir_Listado_PrecioProd();
        }

        private void listadoDeStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Text = "Impresion de Lista de Stock de Productos";
            Imprimir_Listado_stockProd();
        }

        private void listadoDeValorDeAlmacenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Text = "Impresion de Lista- Valor de Almacen";
            Imprimir_Listado_ValorAl();
        }

        private void listadoDeKardexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rpte_listado_Kardex reporte = new Rpte_listado_Kardex();
            vsr_impre.ReportSource = reporte;
            reporte.Refresh();
            vsr_impre.ReportSource = reporte;
        }

        private void listadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rpte_Listado_Precios0 reporte = new Rpte_Listado_Precios0();
            vsr_impre.ReportSource = reporte;
            reporte.Refresh();
            vsr_impre.ReportSource = reporte;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            vsr_impre.ShowNextPage();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            vsr_impre.ShowPreviousPage();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            vsr_impre.ShowFirstPage();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            vsr_impre.ShowLastPage();
        }
    }
}

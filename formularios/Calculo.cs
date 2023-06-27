using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TablasDeVerdad.logica;
using TablasDeVerdad.elementos;

namespace TablasDeVerdad.formularios
{
    public partial class Calculo : Form
    {
        private bool invertir;

        private string VERDAD;
        private string FALSO;
        
        public Calculo()
        {
            InitializeComponent();

            invertir = false;
            VERDAD = "1";
            FALSO = "0";

            ActualizarInformacion();

            dtgTabla.Select();

        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            string text = txtEntrada.Text.Trim();
            Operacion operacion;

            dtgTabla.Columns.Clear();

            if (string.IsNullOrEmpty(text))
            {
                return;
            }

            try
            {
                operacion = logica.Calculo.Calcular(text);
                MostrarDatos(operacion);
            }
            catch(Exception ex)
            {
                MessageBox.Show("No se pudo realizar el calculo: "+ex.Message);
            }
            
        }
        private void MostrarDatos(Operacion operacion)
        {
            dtgTabla.RowHeadersVisible = false;
            operacion.Invertir = invertir;

            List<Proposicion> proposiciones = operacion.Proposiciones;

            //El ancho de la tabla sera la cantidad de Proposiciones usadas.
            //El largo de la tabla sera la longitud de las Proposiciones.
            int width = proposiciones.Count;
            int height = proposiciones[0].Values.Length;

            foreach (Proposicion proposicion in operacion.Proposiciones)
            {
                dtgTabla.Columns.Add(CrearColumna(proposicion.name));
            }

            dtgTabla.Columns.Add(CrearColumna(operacion.GetResultado().name));
            dtgTabla.MultiSelect = false;
            

            for (int i = 0; i < height; i++)
            {
                int n = dtgTabla.Rows.Add();
                dtgTabla.Rows[n].Resizable = DataGridViewTriState.False;

                for (int j = 0; j < width; j++)
                {
                    Proposicion actual = proposiciones[j];

                    bool valor = actual.Values[i];

                    if (valor)
                    {
                        dtgTabla.Rows[n].Cells[j].Value = VERDAD;
                    }
                    else
                    {
                        dtgTabla.Rows[n].Cells[j].Value = FALSO;
                    }
                    
                    
                    if(j + 1 == width)
                    {
                        bool valorResult = operacion.GetResultado().Values[i];

                        if (valorResult)
                        {
                            dtgTabla.Rows[n].Cells[width].Value = VERDAD;
                        }
                        else
                        {
                            dtgTabla.Rows[n].Cells[width].Value = FALSO;
                        }
                    }
                }
            }

            dtgTabla.ClearSelection();

        }
        private DataGridViewColumn CrearColumna(string titulo)
        {
            DataGridViewColumn column = new DataGridViewColumn();

            DataGridViewColumnHeaderCell cellHeader = new DataGridViewColumnHeaderCell();
            cellHeader.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column.HeaderCell = cellHeader;

            DataGridViewCell cell = new DataGridViewTextBoxCell();
            cell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            
            column.CellTemplate = cell;

            column.HeaderText = titulo;

            column.Resizable = DataGridViewTriState.False;
            column.ReadOnly = true;

            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            column.MinimumWidth = 30;

            return column;
        }
        private void ActualizarInformacion()
        {
            string info = "Suma: " + Logica.SUMA
                + "\n\nMultiplicación: " + Logica.MULTIPLICACION
                + "\n\nNegación: " + Logica.NEGACION
                + "\n\nSeparadores: " + Logica.SEPARADORAPERTURA + " " + Logica.SEPARADORCIERRE;

            lblInfo.Text = info;

        }

        private void dtgTabla_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;
            dataGridView.ClearSelection();
        }

        private void btnLogicaNegativa_Click(object sender, EventArgs e)
        {
            invertir = !invertir;

            if(invertir)
            {
                btnInvertir.FlatStyle = FlatStyle.Flat;
                btnInvertir.BackColor = Color.DarkGray;
            }
            else
            {
                btnInvertir.FlatStyle = FlatStyle.Standard;
                btnInvertir.BackColor = SystemColors.Control;
            }


            string text = txtEntrada.Text.Trim();
            Operacion operacion;
            dtgTabla.Columns.Clear();

            if (string.IsNullOrEmpty(text)) return;

            try
            {
                operacion = logica.Calculo.Calcular(text);
                MostrarDatos(operacion);
            }
            catch (Exception){}
        }

        private void txtEntrada_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (int)Keys.Enter)
            {
                btnCalcular.PerformClick();
            }
        }
    }
}

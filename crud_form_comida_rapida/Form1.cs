using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace crud_form_comida_rapida
{
    public partial class Form1 : Form
    {
        string url = "https://localhost:44329/api/tipos";
        public Form1()
        {
            InitializeComponent();
        }

        public async Task<string> ObtenerTipos()
        {
            WebRequest req = WebRequest.Create(url);
            WebResponse res = req.GetResponse();
            StreamReader sr = new StreamReader(res.GetResponseStream());
            return await sr.ReadToEndAsync();
        }

        private  async void Form1_Load(object sender, EventArgs e)
        {
            string respuesta = await ObtenerTipos();

            //debemos convertir el string a list

            List<TipoViewModel> tipos = JsonConvert.DeserializeObject<List<TipoViewModel>>(respuesta);

            comboTipo.DataSource = tipos;

            comboTipo.DisplayMember = "nombre";
            comboTipo.ValueMember = "id";
            
        }
    }
}

using ProjetoSoftware.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.Globalization;
using System.Web.Helpers;
using System.Drawing;
using System.Web.UI.DataVisualization.Charting;
using System.IO;
using Newtonsoft.Json;
using System.Web.Services;
using System.Web.Script.Services;
using System.Collections;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using MySql.Data.MySqlClient;

namespace ProjetoSoftware.Controllers
{
    public class NaufragosController : Controller
    {
        
        private Contexto db = new Contexto();
        // GET: Naufragos
        

        public ActionResult Pesquisar(string search, string search2,string organiza,string currentFilter, int ? page = null)
        {
            var pesquisa = from s in db.Naufragos
                           select s;

            ViewBag.OrganizaNome = String.IsNullOrEmpty(organiza) ? "nome_desc:" : "";
            ViewBag.OrganizaEstado = String.IsNullOrEmpty(organiza) ? "estado_desc:" : "";
            ViewBag.OrganizaLocal = String.IsNullOrEmpty(organiza) ? "local_desc:" : "";
            ViewBag.OrganizaData = organiza == "Date" ? "date_desc:" : "date";

            if(search != null)
            {
                page = 1;
            }
            else
            {
                search = currentFilter;
            }
            ViewBag.Currentfilter = search;

            if (!String.IsNullOrEmpty(search))
            {
                pesquisa = pesquisa.Where(n => n.Nome.Contains(search) || n.Local.Contains(search));
            }

            if (!String.IsNullOrEmpty(search2))
            {
                pesquisa = pesquisa.Where(n =>n.Estado.Contains(search2));
            }

            DateTime searchDate;
            if (DateTime.TryParseExact(search2,
                "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out searchDate))
            {
                pesquisa = pesquisa.Where(s => s.DataOcorrido >= searchDate);
            }

            switch (organiza)
            {
                case "nome_desc":
                    pesquisa = pesquisa.OrderByDescending(n => n.Nome);
                    break;
                case "estado_desc":
                    pesquisa = pesquisa.OrderByDescending(n => n.Estado);
                    break;
                case "local_desc":
                    pesquisa = pesquisa.OrderByDescending(n => n.Local);
                    break;
                case "date":
                    pesquisa = pesquisa.OrderByDescending(n => n.DataOcorrido);
                    break;
            }

           

            int pageSize = 10;
            int pageNumber = (page ?? 1);

            return View(pesquisa.OrderBy(n=>n.Nome).ToPagedList(pageNumber,pageSize));
        }

        public ActionResult pegarDados()
        {
            return View();
        }

        public ActionResult DadosColuna()
        {
            var chart = new System.Web.Helpers.Chart(width: 300, height: 220).AddTitle("Test");

            var xValues = new List<String>();
            var yValues = new List<String>();

            var lista = (from n in db.Naufragos
                         select new
                         {
                             n.Nome,
                             n.Estado
                         });

            foreach (var item in lista)
            {
                xValues.Add(item.Nome);
                yValues.Add(item.Estado);
            }

            chart.AddSeries(chartType: "Doughnut",
                    xValue: xValues,
                    yValues: yValues).Write("png");

            return null;

        }
        //public ActionResult PegarDados2()
        //{

        //    string query = "SELECT count(IdNaufrago), Estado";
        //    query += " FROM Naufragos group by Estado ";
        //    string constr = ConfigurationManager.ConnectionStrings["Contexto"].ConnectionString;
        //    List<Naufragos> chartData = new List<Naufragos>();

        //    using (MySqlConnection con = new MySqlConnection(constr))
        //    {
        //        using (MySqlCommand cmd = new MySqlCommand(query))
        //        {
        //            cmd.CommandType = CommandType.Text;
        //            cmd.Connection = con;
        //            con.Open();
        //            using (MySqlDataReader sdr = cmd.ExecuteReader())
        //            {
        //                while (sdr.Read())
        //                {
        //                    chartData.Add(new Naufragos
        //                    {
        //                        Estado = sdr["Estado"].ToString(),
        //                        IdNaufrago = Convert.ToInt32(sdr["IdNaufrago"])
        //                    });
        //                }
        //            }

        //            con.Close();
        //        }
        //    }

        //    return View(chartData);
        //}

        [HttpPost]
        public JsonResult ExportReport(string imageData)
        {
            string fileName = Path.Combine(Server.MapPath("~/ExportImage"), DateTime.Now.ToString("ddMMyyyyhhmmsstt") + ".png");
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                using (BinaryWriter bw = new BinaryWriter(fs))
                {
                    byte[] data = Convert.FromBase64String(imageData);
                    bw.Write(data);
                    bw.Close();
                }
            }
            return new JsonResult { Data = "Image saved successfully" };
        }

    


        public ActionResult Index(int ? page=null )
        {
            page = (page ?? 1);

            var dados = db.Naufragos.OrderBy(n => n.Nome).ToList();

            return View(dados.ToPagedList((int)page,30));
        }

        [HttpGet]
        public ActionResult CarregarDados()
        {
            var dados = from v in db.Naufragos
                        select new
                        {
                            v.Nome,
                            v.Estado,
                            v.DataOcorrido,
                            v.Local,
                            v.Motivo
                        };

            return Json(new { data = dados }, JsonRequestBehavior.AllowGet);
        }

        // GET: Naufragos/Details/5
        public ActionResult Detalhes(int ? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Naufragos naufrago = db.Naufragos.Find(id);
            if (naufrago == null)
            {
                return HttpNotFound();
            }
            return View(naufrago);
        }

        // GET: Naufragos/Create
        public ActionResult Create()
        {
            

            return View();
        }

        // POST: Naufragos/Create
        [HttpPost]
        public ActionResult Create(Naufragos naufragos)
        {
            try
            {
                db.Naufragos.Add(naufragos);
                db.SaveChanges();
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Naufragos/Edit/5
        public ActionResult Edit(int ? id)
        {
            Naufragos naufrago = db.Naufragos.Find(id);
            if (naufrago == null)
            {
                return HttpNotFound();
            }
            return View(naufrago);
        }

        // POST: Naufragos/Edit/5
        [HttpPost]
        public ActionResult Edit(Naufragos naufrago)
        {
            if (ModelState.IsValid)
            {
                db.Entry(naufrago).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(naufrago);
        }

        // GET: Naufragos/Delete/5
        public ActionResult Delete(int id)
        {
            var naufragio = db.Naufragos.Find(id);
            return View(naufragio);
        }

        // POST: Naufragos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Naufragos naufragos = db.Naufragos.Find(id);
                db.Naufragos.Remove(naufragos);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

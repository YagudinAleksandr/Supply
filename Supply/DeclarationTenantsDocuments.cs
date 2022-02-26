using Libraries.ExcelSystem;
using Supply.Domain;
using Supply.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace Supply
{
    public partial class DeclarationTenantsDocuments : Form
    {
        public DeclarationTenantsDocuments()
        {
            InitializeComponent();

            pbProgress.Visible = false;
        }

        private void DeclarationTenantsDocuments_Load(object sender, EventArgs e)
        {
            try
            {
                using(SupplyDbContext db = new SupplyDbContext())
                {
                    cbHostels.DataSource = db.Hostels.ToList();
                    cbHostels.DisplayMember = "Name";
                    cbHostels.ValueMember = "ID";
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                using(SupplyDbContext db = new SupplyDbContext())
                {
                    Log logInfo = new Log();
                    logInfo.ID = Guid.NewGuid();
                    logInfo.Type = "ERROR";
                    logInfo.Caption = $"DeclarationTenantsDocuments.cs. Class: DeclarationTenantsDocuments. Method:  DeclarationTenantsDocuments_Load." + ex.Message + "." + ex.InnerException;
                    logInfo.CreatedAt = DateTime.Now.ToString();
                    db.Logs.Add(logInfo);
                    db.SaveChanges();
                }
                this.Close();
            }
        }

        private void BTN_Create_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(cbHostels.SelectedValue.ToString(), out _))
                {
                    MessageBox.Show("Выбирите общежитие", "Предепреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                pbProgress.Visible = true;

                using (SupplyDbContext db = new SupplyDbContext())
                {
                    List<TenantToOrder> tenantToOrders = new List<TenantToOrder>();

                    int hostelID = int.Parse(cbHostels.SelectedValue.ToString());

                    foreach (Enterance enterance in db.Enterances.Where(x => x.HostelId == hostelID).ToList())
                    {
                        foreach (Flat flat in db.Flats.Where(x => x.Enterance_ID == enterance.ID).ToList())
                        {
                            foreach (Room room in db.Rooms.Where(x => x.FlatID == flat.ID).ToList())
                            {
                                foreach (Tenant tenant in db.Tenants.Where(x => x.RoomID == room.ID).Where(s => s.Status == true).Include(o => o.Order).Include(p => p.Identification).ToList())
                                {
                                    var documents = db.TenantDocuments.Where(x => x.TenantID == tenant.ID).ToList();
                                    var changePassport = db.ChangePassports.Where(x => x.TenantID == tenant.ID).ToList();

                                    TenantToOrder tenantToOrder = new TenantToOrder
                                    {
                                        Room = room.Name,
                                        Order = tenant.Order.OrderNumber,
                                        StartOrder = tenant.Order.StartDate,
                                        EndOrder = tenant.Order.EndDate
                                    };

                                    if (changePassport.Count > 0)
                                    {
                                        foreach(ChangePassport temp in changePassport)
                                        {
                                            tenantToOrder.FullName = temp.Surename + " ";
                                            tenantToOrder.FullName += temp.Name;

                                            tenantToOrder.FullName += !string.IsNullOrEmpty(temp.Patronymic) ? " " + temp.Patronymic : string.Empty;
                                        }
                                    }
                                    else
                                    {
                                        tenantToOrder.FullName = tenant.Identification.Surename + " ";
                                        tenantToOrder.FullName += tenant.Identification.Name;

                                        tenantToOrder.FullName += !string.IsNullOrEmpty(tenant.Identification.Patronymic) ? " " + tenant.Identification.Patronymic : string.Empty;
                                    }

                                    if (documents.Count > 0)
                                    {
                                        foreach(var document in documents)
                                        {
                                            if (DateTime.Parse(document.EndDate) >= DateTime.Now)
                                            {
                                                switch(document.Type)
                                                {
                                                    case "Мед.обследование":
                                                        tenantToOrder.MedicalExam = "+";
                                                        break;
                                                    case "Воинский учет":
                                                        tenantToOrder.MillitaryDoc = "+";
                                                        break;
                                                    case "Эл.пропуск":
                                                        tenantToOrder.ElectronDoc = "+";
                                                        break;
                                                    default:
                                                        break;
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        tenantToOrder.MillitaryDoc = "";
                                        tenantToOrder.MedicalExam = "";
                                        tenantToOrder.ElectronDoc = "";
                                    }

                                    tenantToOrders.Add(tenantToOrder);
                                }
                            }
                        }
                    }

                    Hostel hostel = db.Hostels.Where(x => x.ID == hostelID).FirstOrDefault();

                    CreateDeclaration(hostel.Name, tenantToOrders);
                }

                MessageBox.Show("Отчет сформирован", "Успех", MessageBoxButtons.OK, MessageBoxIcon.None);

                pbProgress.Visible = false;
            }
            catch(Exception ex)
            {
                pbProgress.Visible = false;

                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                using (SupplyDbContext db = new SupplyDbContext())
                {
                    Log logInfo = new Log();
                    logInfo.ID = Guid.NewGuid();
                    logInfo.Type = "ERROR";
                    logInfo.Caption = $"DeclarationTenantsDocuments.cs.  Method:  BTN_Create_Click." + ex.Message + "." + ex.InnerException;
                    logInfo.CreatedAt = DateTime.Now.ToString();
                    db.Logs.Add(logInfo);
                    db.SaveChanges();
                }

                return;
            }
        }

        private void CreateDeclaration(string hostelName, List<TenantToOrder> tenantToOrders)
        {
            var tenants = from t in tenantToOrders
                          orderby t.FullName
                          select t;

            using (ExcelHelper excel = new ExcelHelper())
            {
                string date = DateTime.Now.ToShortDateString();
                excel.Open(filePath: AppSettings.GetTemplateSetting("outfileDir") + @"\", name: $"Отчеты о наличию документов жильцов общежития {hostelName} на {date}.xlsx", out _);

                excel.Set("A", 1, "№ п/п", out _);
                excel.Set("B", 1, "ФИО", out _);
                excel.Set("C", 1, "Комната", out _);
                excel.Set("D", 1, "Договор", out _);
                excel.Set("E", 1, "Дата начала договора", out _);
                excel.Set("F", 1, "Дата окончания договора", out _);
                excel.Set("G", 1, "Медецинское обследование", out _);
                excel.Set("H", 1, "Эл. пропуск", out _);
                excel.Set("I", 1, "Документы о воинском учете", out _);

                pbProgress.Minimum = 0;
                pbProgress.Maximum = tenants.Count();

                int mainCounter = 2;
                foreach(TenantToOrder tenantToOrder in tenants)
                {
                    excel.Set("A", mainCounter, (mainCounter - 1).ToString(), out _);
                    excel.Set("B", mainCounter, tenantToOrder.FullName, out _);
                    excel.Set("C", mainCounter, tenantToOrder.Room, out _);
                    excel.Set("D", mainCounter, tenantToOrder.Order, out _);
                    excel.Set("E", mainCounter, tenantToOrder.StartOrder, out _);
                    excel.Set("F", mainCounter, tenantToOrder.EndOrder, out _);
                    excel.Set("G", mainCounter, tenantToOrder.MedicalExam, out _);
                    excel.Set("H", mainCounter, tenantToOrder.ElectronDoc, out _);
                    excel.Set("I", mainCounter, tenantToOrder.MillitaryDoc, out _);

                    pbProgress.Value += 1;

                    mainCounter++;
                }

                excel.Save();
            }
        }

        private class TenantToOrder
        {
            public string Room { get; set; }
            public string FullName { get; set; }
            public string Order { get; set; }
            public string StartOrder { get; set; }
            public string EndOrder { get; set; }
            public string MedicalExam { get; set; }
            public string ElectronDoc { get; set; }
            public string MillitaryDoc { get; set; }
        }
    }
}

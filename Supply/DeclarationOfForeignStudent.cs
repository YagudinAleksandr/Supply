using Libraries.ExcelSystem;
using Supply.Domain;
using Supply.Libs;
using Supply.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Supply
{
    public partial class DeclarationOfForeignStudent : Form
    {
        public DeclarationOfForeignStudent()
        {
            InitializeComponent();
            PB_ProgressBar.Visible = false;
            LB_ProgressInf.Visible = false;
        }

        private void DeclarationOfForeignStudent_Shown(object sender, EventArgs e)
        {
            using (SupplyDbContext db = new SupplyDbContext())
            {
                CB_Hostels.DataSource = db.Hostels.ToList();
                CB_Hostels.ValueMember = "ID";
                CB_Hostels.DisplayMember = "Name";
            }
        }

        private void BTN_Create_Click(object sender, EventArgs e)
        {
            if (_hostelID == 0)
            {
                MessageBox.Show("Выбирите общежитие!");
                return;
            }

            PB_ProgressBar.Visible = true;
            LB_ProgressInf.Visible = true;

            try
            {
                PB_ProgressBar.Minimum = 0;
                using (SupplyDbContext db = new SupplyDbContext())
                {
                    var hostel = db.Hostels.Where(x => x.ID == _hostelID).FirstOrDefault();

                    if (hostel == null)
                    {
                        MessageBox.Show("Общежитие не найдено!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        PB_ProgressBar.Visible = false;
                        LB_ProgressInf.Visible = false;

                        return;
                    }

                    var enterances = db.Enterances.Where(x => x.HostelId == hostel.ID).ToList();

                    if (enterances.Count == 0)
                    {
                        MessageBox.Show("Подъездов не найдено!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        PB_ProgressBar.Visible = false;
                        LB_ProgressInf.Visible = false;

                        return;
                    }

                    PB_ProgressBar.Maximum = enterances.Count;

                    using (ExcelHelper excel = new ExcelHelper())
                    {
                        if (!excel.Open(filePath: AppSettings.GetTemplateSetting("outfileDir") + @"\", name: $"Отчеты по студентам сторонней организации общежития {hostel.Name} с {DateTime.Now.ToShortDateString()}.xlsx", out string error))
                        {
                            MessageBox.Show(error, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            excel.Close();

                            Log logInfo = new Log();
                            logInfo.ID = Guid.NewGuid();
                            logInfo.Type = "ERROR";
                            logInfo.Caption = $"Class: DeclarationOfForeignStudent. Method: BTN_Create_Click. {error}";
                            logInfo.CreatedAt = DateTime.Now.ToString();
                            db.Logs.Add(logInfo);
                            db.SaveChanges();

                            PB_ProgressBar.Visible = false;
                            LB_ProgressInf.Visible = false;
                            return;
                        }

                        excel.Set("A", 1, "№ п/п", out _);
                        excel.Set("B", 1, "ФИО", out _);
                        excel.Set("C", 1, "Комната", out _);
                        excel.Set("D", 1, "Договор", out _);
                        excel.Set("E", 1, "Дата начала", out _);
                        excel.Set("F", 1, "Дата окончания", out _);

                        int rowNumber = 2;
                        int counter = 1, total = 0;

                        foreach (Enterance enterance in enterances)
                        {
                            foreach (Flat flat in db.Flats.Where(x => x.Enterance_ID == enterance.ID).ToList())
                            {
                                foreach (Room room in db.Rooms.Where(x => x.FlatID == flat.ID).ToList())
                                {
                                    foreach (Tenant tenant in db.Tenants.Where(r => r.RoomID == room.ID).Where(x => x.Status == true).ToList())
                                    {
                                        if (!string.IsNullOrEmpty(OrdersCreation.AdditionalInf(10, tenant.ID)))
                                        {
                                            Identification identification = db.Identifications.Where(x => x.ID == tenant.ID).FirstOrDefault();
                                            ChangePassport changePassport = db.ChangePassports.Where(x => x.TenantID == tenant.ID).Where(x => x.Status == true).FirstOrDefault();
                                            Order order = db.Orders.Where(x => x.ID == tenant.ID).FirstOrDefault();

                                            excel.Set("A", rowNumber, counter.ToString(), out _);

                                            if(changePassport!=null)
                                            {
                                                string fullName = changePassport.Surename + " " + changePassport.Name;
                                                fullName += string.IsNullOrEmpty(changePassport.Patronymic) ? " " + changePassport.Patronymic : string.Empty;

                                                excel.Set("B", rowNumber, fullName, out _);
                                            }
                                            else
                                            {
                                                string fullName = identification.Surename + " " + identification.Name;
                                                fullName += string.IsNullOrEmpty(identification.Patronymic) ? " " + identification.Patronymic : string.Empty;

                                                excel.Set("B", rowNumber, fullName, out _);
                                            }

                                            excel.Set("C", rowNumber, room.Name.ToString(), out _);
                                            excel.Set("D", rowNumber, order.OrderNumber, out _);
                                            excel.Set("E", rowNumber, order.StartDate, out _);
                                            excel.Set("F", rowNumber, order.EndDate, out _);

                                            counter++;
                                            rowNumber++;
                                            total++;
                                        }
                                    }
                                }
                            }

                            PB_ProgressBar.Value += 1;
                        }

                        excel.Set("A", rowNumber, "Всего:", out _);
                        excel.Set("B", rowNumber, total.ToString(), out _);

                        excel.Save();
                    }


                }

                MessageBox.Show("Отчет создан успешно!");
                PB_ProgressBar.Visible = false;
                LB_ProgressInf.Visible = false;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                using (SupplyDbContext db = new SupplyDbContext())
                {
                    Log logInfo = new Log();
                    logInfo.ID = Guid.NewGuid();
                    logInfo.Type = "ERROR";
                    logInfo.Caption = $"Class: DeclarationOfForeignStudent. Method: BTN_Create_Click. {ex.Message}.{ex.InnerException}";
                    logInfo.CreatedAt = DateTime.Now.ToString();
                    db.Logs.Add(logInfo);
                    db.SaveChanges();
                }
                PB_ProgressBar.Visible = false;
                LB_ProgressInf.Visible = false;
            }
        }

        private int _hostelID = 0;
        private void CB_Hostels_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                _hostelID = (int)CB_Hostels.SelectedValue;
            }
            catch
            {
                return;
            }
        }
    }
}

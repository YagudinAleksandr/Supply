using Libraries.ExcelSystem;
using Supply.Domain;
using Supply.Libs;
using Supply.Models;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace Supply
{
    public partial class DeclarationTenantsInHostels : Form
    {
        private int _hostelID;
        private bool _foreignCitizenship;
        public DeclarationTenantsInHostels(bool foreignCitizenship = false)
        {
            InitializeComponent();
            _foreignCitizenship = foreignCitizenship;
        }


        private void DeclarationTenantsInHostels_Shown(object sender, EventArgs e)
        {
            using (SupplyDbContext db = new SupplyDbContext())
            {
                CB_Hostels.DataSource = db.Hostels.ToList();
                CB_Hostels.ValueMember = "ID";
                CB_Hostels.DisplayMember = "Name";
            }
        }

        private void CB_Hostels_SelectedIndexChanged(object sender, EventArgs e)
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

        private void BTN_Create_Click(object sender, EventArgs e)
        {
            if (_hostelID == 0)
            {
                MessageBox.Show("Выбирите общежитие!");
                return;
            }

            string error = string.Empty;

            try
            {
                if (_hostelID == 0)
                {
                    MessageBox.Show("Выбирите общежитие!");
                    return;
                }

                if (_foreignCitizenship == false) 
                {
                    using (ExcelHelper excelHelper = new ExcelHelper())
                    {
                        if (excelHelper.Open(filePath: AppSettings.GetTemplateSetting("outfileDir") + @"\", name: $"Отчеты по проживающим({DateTime.Now.ToShortDateString()}).xlsx", out error))
                        {
                            using (SupplyDbContext db = new SupplyDbContext())
                            {


                                try
                                {
                                    excelHelper.Set(columnName: "A", rowNumber: 1, value: "№ общежития", error: out error);
                                    excelHelper.Set(columnName: "A", rowNumber: 2, value: "Кол-во граждан РФ", error: out error);
                                    excelHelper.Set(columnName: "A", rowNumber: 3, value: "Кол-во иностранных граждан", error: out error);
                                    excelHelper.Set(columnName: "A", rowNumber: 4, value: "Бюджетная основа", error: out error);
                                    excelHelper.Set(columnName: "A", rowNumber: 5, value: "Внебюджетная основа", error: out error);
                                    excelHelper.Set(columnName: "A", rowNumber: 6, value: "Кол-во студентов очной формы", error: out error);
                                    excelHelper.Set(columnName: "A", rowNumber: 7, value: "Кол-во студентов очно-заочной формы", error: out error);
                                    excelHelper.Set(columnName: "A", rowNumber: 8, value: "Кол-во студентов заочной формы", error: out error);
                                    excelHelper.Set(columnName: "A", rowNumber: 9, value: "Кол-во сотрудников", error: out error);
                                    excelHelper.Set(columnName: "A", rowNumber: 10, value: "Кол-во сторонних лиц", error: out error);
                                    excelHelper.Set(columnName: "A", rowNumber: 11, value: "Кол-во членов семьи", error: out error);
                                    excelHelper.Set(columnName: "A", rowNumber: 12, value: "Всего проживает", error: out error);


                                    Hostel hostel = db.Hostels.Where(x => x.ID == _hostelID).FirstOrDefault();


                                    int citizenshipRF = 0;
                                    int citizenshipForeign = 0;
                                    int tenantEnemy = 0;
                                    int worker = 0;
                                    int tenantOF = 0;
                                    int tenantNOF = 0;
                                    int tenantNOFOF = 0;
                                    int budjet = 0;
                                    int notBudjet = 0;
                                    int total = 0;
                                    int family = 0;

                                    excelHelper.Set(columnName: "B", rowNumber: 1, value: hostel.Name, error: out error);

                                    var enterances = db.Enterances.Where(x => x.HostelId == hostel.ID).ToList();
                                    foreach (var enterance in enterances)
                                    {
                                        var flats = db.Flats.Where(x => x.Enterance_ID == enterance.ID).ToList();
                                        foreach (var flat in flats)
                                        {

                                            var rooms = db.Rooms.Where(x => x.FlatID == flat.ID).OrderBy(n => n.Name).ToList();
                                            foreach (var room in rooms)
                                            {
                                                var tenants = db.Tenants.Where(x => x.RoomID == room.ID).Where(st => st.Status == true).ToList();
                                                foreach (Tenant tenant in tenants)
                                                {
                                                    Identification identification = db.Identifications.Where(x => x.ID == tenant.ID).FirstOrDefault();
                                                    ChangePassport changePassport = db.ChangePassports.Where(x => x.TenantID == tenant.ID).Where(s => s.Status == true).FirstOrDefault();

                                                    if (tenant.TenantTypeID == 1)
                                                    {
                                                        if (OrdersCreation.AdditionalInf(5, tenant.ID) == "Очная" || OrdersCreation.AdditionalInf(5, tenant.ID) == "очная")
                                                        {
                                                            tenantOF++;
                                                        }
                                                        if (OrdersCreation.AdditionalInf(5, tenant.ID) == "Очно-заочная" || OrdersCreation.AdditionalInf(5, tenant.ID) == "очно-заочная")
                                                        {
                                                            tenantNOFOF++;
                                                        }
                                                        if (OrdersCreation.AdditionalInf(5, tenant.ID) == "Заочная" || OrdersCreation.AdditionalInf(5, tenant.ID) == "заочная")
                                                        {
                                                            tenantNOF++;
                                                        }

                                                        if (OrdersCreation.AdditionalInf(7, tenant.ID) == "Бюджет" || OrdersCreation.AdditionalInf(7, tenant.ID) == "бюджет")
                                                        {
                                                            budjet++;
                                                        }
                                                        if (OrdersCreation.AdditionalInf(7, tenant.ID) == "Внебюджет" || OrdersCreation.AdditionalInf(7, tenant.ID) == "внебюджет")
                                                        {
                                                            notBudjet++;
                                                        }
                                                    }

                                                    if (tenant.TenantTypeID == 2)
                                                    {
                                                        worker++;
                                                        var additionalTenants = db.AdditionalInformation.Where(t => t.TenantID == tenant.ID).Where(x => x.AdditionalInformationTypeID == 9).ToList();
                                                        foreach (AdditionalInformation additionalInformation in additionalTenants)
                                                        {
                                                            total++;
                                                            family++;
                                                        }
                                                    }

                                                    if (tenant.TenantTypeID == 3)
                                                    {
                                                        tenantEnemy++;
                                                        var additionalTenants = db.AdditionalInformation.Where(t => t.TenantID == tenant.ID).Where(x => x.AdditionalInformationTypeID == 9).ToList();
                                                        foreach (AdditionalInformation additionalInformation in additionalTenants)
                                                        {
                                                            total++;
                                                            family++;
                                                        }
                                                    }

                                                    if (changePassport != null)
                                                    {
                                                        if (changePassport.Citizenship == "РФ" || changePassport.Citizenship == "Россия")
                                                        {
                                                            citizenshipRF++;
                                                        }
                                                        else
                                                        {
                                                            citizenshipForeign++;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (identification.Cityzenship == "РФ" || identification.Cityzenship == "Россия")
                                                        {
                                                            citizenshipRF++;
                                                        }
                                                        else
                                                        {
                                                            citizenshipForeign++;
                                                        }
                                                    }

                                                    total++;
                                                }

                                            }
                                        }
                                    }

                                    excelHelper.Set(columnName: "B", rowNumber: 1, value: hostel.Name, error: out error);
                                    excelHelper.Set(columnName: "B", rowNumber: 2, value: citizenshipRF.ToString(), error: out error);
                                    excelHelper.Set(columnName: "B", rowNumber: 3, value: citizenshipForeign.ToString(), error: out error);
                                    excelHelper.Set(columnName: "B", rowNumber: 4, value: budjet.ToString(), error: out error);
                                    excelHelper.Set(columnName: "B", rowNumber: 5, value: notBudjet.ToString(), error: out error);
                                    excelHelper.Set(columnName: "B", rowNumber: 6, value: tenantOF.ToString(), error: out error);
                                    excelHelper.Set(columnName: "B", rowNumber: 7, value: tenantNOFOF.ToString(), error: out error);
                                    excelHelper.Set(columnName: "B", rowNumber: 8, value: tenantNOF.ToString(), error: out error);
                                    excelHelper.Set(columnName: "B", rowNumber: 9, value: worker.ToString(), error: out error);
                                    excelHelper.Set(columnName: "B", rowNumber: 10, value: tenantEnemy.ToString(), error: out error);
                                    excelHelper.Set(columnName: "B", rowNumber: 11, value: family.ToString(), error: out error);
                                    excelHelper.Set(columnName: "B", rowNumber: 12, value: total.ToString(), error: out error);


                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                            }


                            excelHelper.Save();
                        }
                        else
                        {
                            AddLog(error, "AdminOrders.cs.Class: DeclarationTenantsInHostels: BTN_Create_Click.");
                        }
                    }
                }

                if (_foreignCitizenship == true)
                {
                    using (ExcelHelper excelHelper = new ExcelHelper())
                    {
                        if (excelHelper.Open(filePath: AppSettings.GetTemplateSetting("outfileDir") + @"\", name: $"Отчеты по проживающим иностранным гражданам({DateTime.Now.ToShortDateString()}).xlsx", out error))
                        {
                            using (SupplyDbContext db = new SupplyDbContext())
                            {
                                
                                try
                                {
                                    excelHelper.Set(columnName: "A", rowNumber: 1, value: "№", error: out error);
                                    excelHelper.Set(columnName: "B", rowNumber: 1, value: "№ общежития", error: out error);
                                    excelHelper.Set(columnName: "C", rowNumber: 1, value: "№ комнаты", error: out error);
                                    excelHelper.Set(columnName: "D", rowNumber: 1, value: "Ф.И.О.", error: out error);
                                    excelHelper.Set(columnName: "E", rowNumber: 1, value: "Гражданство", error: out error);
                                    excelHelper.Set(columnName: "F", rowNumber: 1, value: "Ступень обучения", error: out error);
                                    excelHelper.Set(columnName: "G", rowNumber: 1, value: "Договор №", error: out error);
                                    excelHelper.Set(columnName: "H", rowNumber: 1, value: "Дата начала договора", error: out error);
                                    excelHelper.Set(columnName: "I", rowNumber: 1, value: "Дата окончания договора", error: out error);
                                    excelHelper.Set(columnName: "J", rowNumber: 1, value: "Форма обучения", error: out error);
                                    excelHelper.Set(columnName: "K", rowNumber: 1, value: "Основа обучения", error: out error);

                                    Hostel hostel = db.Hostels.Where(x => x.ID == _hostelID).FirstOrDefault();

                                    int counter = 1;
                                    int rowCount = 2;

                                    var enterances = db.Enterances.Where(x => x.HostelId == hostel.ID).ToList();
                                    foreach (var enterance in enterances)
                                    {
                                        var flats = db.Flats.Where(x => x.Enterance_ID == enterance.ID).ToList();
                                        foreach (var flat in flats)
                                        {

                                            var rooms = db.Rooms.Where(x => x.FlatID == flat.ID).OrderBy(n => n.Name).ToList();
                                            foreach (var room in rooms)
                                            {
                                                var tenants = db.Tenants.Where(x => x.RoomID == room.ID).Where(st => st.Status == true).Include(or=>or.Order).ToList();
                                                foreach (Tenant tenant in tenants)
                                                {
                                                    if (tenant.TenantTypeID != 2 || tenant.TenantTypeID != 3) 
                                                    {
                                                        Identification identification = db.Identifications.Where(x => x.ID == tenant.ID).FirstOrDefault();
                                                        if(identification!=null)
                                                        {
                                                            ChangePassport changePassport = db.ChangePassports.Where(x => x.TenantID == tenant.ID).Where(s => s.Status == true).FirstOrDefault();

                                                            if (changePassport != null)
                                                            {
                                                                if (changePassport.Citizenship != "Россия" && changePassport.Citizenship != "РФ")
                                                                {
                                                                    excelHelper.Set(columnName: "A", rowNumber: rowCount, value: counter.ToString(), error: out error);
                                                                    excelHelper.Set(columnName: "B", rowNumber: rowCount, value: hostel.Name, error: out error);
                                                                    excelHelper.Set(columnName: "C", rowNumber: rowCount, value: room.Name, error: out error);
                                                                    if (changePassport != null)
                                                                    {
                                                                        if (changePassport.Patronymic != null)
                                                                        {
                                                                            excelHelper.Set(columnName: "D", rowNumber: rowCount, value: changePassport.Surename + " " + changePassport.Name + " " + changePassport.Patronymic, error: out error);
                                                                        }
                                                                        else
                                                                        {
                                                                            excelHelper.Set(columnName: "D", rowNumber: rowCount, value: changePassport.Surename + " " + changePassport.Name, error: out error);
                                                                        }

                                                                        excelHelper.Set(columnName: "E", rowNumber: rowCount, value: changePassport.Citizenship, error: out error);
                                                                    }
                                                                    else
                                                                    {
                                                                        if (identification.Patronymic != null)
                                                                        {
                                                                            excelHelper.Set(columnName: "D", rowNumber: rowCount, value: identification.Surename + " " + identification.Name + " " + identification.Patronymic, error: out error);
                                                                        }
                                                                        else
                                                                        {
                                                                            excelHelper.Set(columnName: "D", rowNumber: rowCount, value: identification.Surename + " " + identification.Name, error: out error);
                                                                        }

                                                                        excelHelper.Set(columnName: "E", rowNumber: rowCount, value: identification.Cityzenship, error: out error);
                                                                    }
                                                                    excelHelper.Set(columnName: "F", rowNumber: rowCount, value: OrdersCreation.AdditionalInf(6, tenant.ID), error: out error);
                                                                    excelHelper.Set(columnName: "G", rowNumber: rowCount, value: tenant.Order.OrderNumber, error: out error);
                                                                    excelHelper.Set(columnName: "H", rowNumber: rowCount, value: tenant.Order.StartDate, error: out error);
                                                                    excelHelper.Set(columnName: "I", rowNumber: rowCount, value: tenant.Order.EndDate, error: out error);
                                                                    excelHelper.Set(columnName: "J", rowNumber: rowCount, value: OrdersCreation.AdditionalInf(5, tenant.ID), error: out error);
                                                                    excelHelper.Set(columnName: "K", rowNumber: rowCount, value: OrdersCreation.AdditionalInf(7, tenant.ID), error: out error);

                                                                    rowCount++;
                                                                    counter++;
                                                                }
                                                            }
                                                            else
                                                            {
                                                                if (identification.Cityzenship != "РФ" && identification.Cityzenship != "Россия")
                                                                {
                                                                    excelHelper.Set(columnName: "A", rowNumber: rowCount, value: counter.ToString(), error: out error);
                                                                    excelHelper.Set(columnName: "B", rowNumber: rowCount, value: hostel.Name, error: out error);
                                                                    excelHelper.Set(columnName: "C", rowNumber: rowCount, value: room.Name, error: out error);
                                                                    if (changePassport != null)
                                                                    {
                                                                        if (changePassport.Patronymic != null)
                                                                        {
                                                                            excelHelper.Set(columnName: "D", rowNumber: rowCount, value: changePassport.Surename + " " + changePassport.Name + " " + changePassport.Patronymic, error: out error);
                                                                        }
                                                                        else
                                                                        {
                                                                            excelHelper.Set(columnName: "D", rowNumber: rowCount, value: changePassport.Surename + " " + changePassport.Name, error: out error);
                                                                        }

                                                                        excelHelper.Set(columnName: "E", rowNumber: rowCount, value: changePassport.Citizenship, error: out error);
                                                                    }
                                                                    else
                                                                    {
                                                                        if (identification.Patronymic != null)
                                                                        {
                                                                            excelHelper.Set(columnName: "D", rowNumber: rowCount, value: identification.Surename + " " + identification.Name + " " + identification.Patronymic, error: out error);
                                                                        }
                                                                        else
                                                                        {
                                                                            excelHelper.Set(columnName: "D", rowNumber: rowCount, value: identification.Surename + " " + identification.Name, error: out error);
                                                                        }

                                                                        excelHelper.Set(columnName: "E", rowNumber: rowCount, value: identification.Cityzenship, error: out error);
                                                                    }
                                                                    excelHelper.Set(columnName: "F", rowNumber: rowCount, value: OrdersCreation.AdditionalInf(6, tenant.ID), error: out error);
                                                                    excelHelper.Set(columnName: "G", rowNumber: rowCount, value: tenant.Order.OrderNumber, error: out error);
                                                                    excelHelper.Set(columnName: "H", rowNumber: rowCount, value: tenant.Order.StartDate, error: out error);
                                                                    excelHelper.Set(columnName: "I", rowNumber: rowCount, value: tenant.Order.EndDate, error: out error);
                                                                    excelHelper.Set(columnName: "J", rowNumber: rowCount, value: OrdersCreation.AdditionalInf(5, tenant.ID), error: out error);
                                                                    excelHelper.Set(columnName: "K", rowNumber: rowCount, value: OrdersCreation.AdditionalInf(7, tenant.ID), error: out error);

                                                                    rowCount++;
                                                                    counter++;
                                                                }
                                                            }
                                                        }
                                                        
                                                        
                                                    }
                                                    
                                                }

                                            }
                                        }
                                    }

                                    


                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                            }


                            excelHelper.Save();
                        }
                        else
                        {
                            AddLog(error, "AdminOrders.cs.Class: DeclarationTenantsInHostels: BTN_Create_Click.");
                        }
                    }
                }


                if (error == string.Empty)
                {
                    MessageBox.Show("Файл создан успешно!");
                }
                else
                {
                    MessageBox.Show(error);
                }
            }
            catch(Exception ex)
            {
                AddLog(ex.Message + "." + ex.InnerException, "Class: DeclarationTenantsInHostels.Method: BTN_Create_Click");
                MessageBox.Show(ex.Message + "." + ex.InnerException);
            }
        }

        private void AddLog(string errorMessage, string caption)
        {
            using (SupplyDbContext db = new SupplyDbContext())
            {
                Log logInfo = new Log();
                logInfo.ID = Guid.NewGuid();
                logInfo.Type = "ERROR";
                logInfo.Caption = $"{caption}" + errorMessage;
                logInfo.CreatedAt = DateTime.Now.ToString();
                db.Logs.Add(logInfo);
                db.SaveChanges();
            }
        }
    }
}

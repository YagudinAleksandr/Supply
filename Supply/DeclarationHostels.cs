using Libraries.ExcelSystem;
using Supply.Domain;
using Supply.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Supply
{
    public partial class DeclarationHostels : Form
    {
        private int _hostelID,
                    _placesCount;
        public DeclarationHostels()
        {
            InitializeComponent();
            _hostelID = _placesCount = 0;
        }

        private void BTN_Create_Click(object sender, EventArgs e)
        {
            string error = string.Empty;
            try
            {
                if (_hostelID == 0)
                {
                    MessageBox.Show("Выбирите общежитие!");
                    return;
                }
                using (ExcelHelper excelHelper = new ExcelHelper())
                {
                    if (excelHelper.Open(filePath: AppSettings.GetTemplateSetting("outfileDir"), name: $"Отчеты по общежитиям({DateTime.Now.ToShortDateString()}).xlsx", out error))
                    {
                        using (SupplyDbContext db = new SupplyDbContext())
                        {

                            int totalPlaces = 0;
                            int totalLockedPlaces = 0;
                            int totalFreePlaces = 0;

                            bool flagAllHostelInf = false;
                            bool flagEmptyPlaces = false;
                            try
                            {
                                excelHelper.Set(columnName: "A", rowNumber: 1, value: "№ общежитие", error: out error);
                                excelHelper.Set(columnName: "B", rowNumber: 1, value: "Комната №", error: out error);
                                excelHelper.Set(columnName: "C", rowNumber: 1, value: "Кол-во мест", error: out error);
                                excelHelper.Set(columnName: "D", rowNumber: 1, value: "Занято", error: out error);
                                int counter = 2;

                                

                                if(ChB_AllHostel.Checked)
                                {
                                    flagAllHostelInf = true;
                                    
                                }

                                if(ChB_EmptyPlaces.Checked)
                                {
                                    flagEmptyPlaces = true;
                                }

                                if(flagAllHostelInf==true)
                                {
                                    flagEmptyPlaces = false;

                                    Hostel hostel = db.Hostels.Where(id => id.ID == _hostelID).FirstOrDefault();

                                    var enterances = db.Enterances.Where(x => x.HostelId == hostel.ID).ToList();
                                    foreach (var enterance in enterances)
                                    {
                                        var flats = db.Flats.Where(x => x.Enterance_ID == enterance.ID).ToList();
                                        foreach (var flat in flats)
                                        {
                                            
                                            var rooms = db.Rooms.Where(x => x.FlatID == flat.ID).OrderBy(n=>n.Name).ToList();
                                            foreach (var room in rooms)
                                            {
                                                var tenants = db.Tenants.Where(x => x.RoomID == room.ID).Where(st => st.Status == true).ToList();

                                                excelHelper.Set(columnName: "A", rowNumber: counter, value: hostel.Name, error: out error);
                                                excelHelper.Set(columnName: "B", rowNumber: counter, value: room.Name, error: out error);
                                                excelHelper.Set(columnName: "C", rowNumber: counter, value: $"{room.Places}", error: out error);
                                                excelHelper.Set(columnName: "D", rowNumber: counter, value: $"{tenants.Count}", error: out error);

                                                totalPlaces += room.Places;
                                                totalLockedPlaces += tenants.Count;
                                                counter++;
                                            }
                                        }
                                    }

                                    excelHelper.Set(columnName: "A", rowNumber: counter + 1, value: $"Всего мест: {totalPlaces}", error: out error);
                                    excelHelper.Set(columnName: "B", rowNumber: counter + 1, value: $"Занято мест всего: {totalLockedPlaces}", error: out error);
                                    excelHelper.Set(columnName: "C", rowNumber: counter + 1, value: $"Свободно всего мест: {totalFreePlaces = totalPlaces - totalLockedPlaces}", error: out error);

                                }
                                else if(flagEmptyPlaces==true)
                                {
                                    Hostel hostel = db.Hostels.Where(id => id.ID == _hostelID).FirstOrDefault();

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

                                                if (_placesCount > 0)
                                                {
                                                    if (room.Places == _placesCount && room.Places!=tenants.Count)
                                                    {
                                                        excelHelper.Set(columnName: "A", rowNumber: counter, value: hostel.Name, error: out error);
                                                        excelHelper.Set(columnName: "B", rowNumber: counter, value: room.Name, error: out error);
                                                        excelHelper.Set(columnName: "C", rowNumber: counter, value: $"{room.Places}", error: out error);
                                                        excelHelper.Set(columnName: "D", rowNumber: counter, value: $"{tenants.Count}", error: out error);

                                                        totalPlaces += room.Places;
                                                        totalLockedPlaces += tenants.Count;
                                                        counter++;
                                                    }
                                                }
                                                
                                            }
                                        }
                                    }

                                    excelHelper.Set(columnName: "A", rowNumber: counter + 1, value: $"Всего мест: {totalPlaces}", error: out error);
                                    excelHelper.Set(columnName: "B", rowNumber: counter + 1, value: $"Занято мест всего: {totalLockedPlaces}", error: out error);
                                    excelHelper.Set(columnName: "C", rowNumber: counter + 1, value: $"Свободно всего мест: {totalFreePlaces = totalPlaces - totalLockedPlaces}", error: out error);
                                }
                                else
                                {
                                    Hostel hostel = db.Hostels.Where(id => id.ID == _hostelID).FirstOrDefault();

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

                                                if (_placesCount > 0)
                                                {
                                                    if (room.Places == _placesCount)
                                                    {
                                                        excelHelper.Set(columnName: "A", rowNumber: counter, value: hostel.Name, error: out error);
                                                        excelHelper.Set(columnName: "B", rowNumber: counter, value: room.Name, error: out error);
                                                        excelHelper.Set(columnName: "C", rowNumber: counter, value: $"{room.Places}", error: out error);
                                                        excelHelper.Set(columnName: "D", rowNumber: counter, value: $"{tenants.Count}", error: out error);

                                                        totalPlaces += room.Places;
                                                        totalLockedPlaces += tenants.Count;
                                                        counter++;
                                                    }
                                                }

                                            }
                                        }
                                    }

                                    excelHelper.Set(columnName: "A", rowNumber: counter + 1, value: $"Всего мест: {totalPlaces}", error: out error);
                                    excelHelper.Set(columnName: "B", rowNumber: counter + 1, value: $"Занято мест всего: {totalLockedPlaces}", error: out error);
                                    excelHelper.Set(columnName: "C", rowNumber: counter + 1, value: $"Свободно всего мест: {totalFreePlaces = totalPlaces - totalLockedPlaces}", error: out error);
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
                        AddLog(error, "AdminOrders.cs.Class: AdminOrders.Method: BTN_CreateExcel_Click.ExcelHelper.Open.");
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
            catch (Exception ex)
            {
                AddLog(ex.Message + "." + ex.InnerException, "AdminOrders.cs.Class: AdminOrders.Method: BTN_CreateExcel_Click.");
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

        private void DeclarationHostels_Load(object sender, EventArgs e)
        {
            Thread thread = new Thread(UpdateInformation);
            thread.Start();
        }

        private void UpdateInformation()
        {
            Action action = () =>
            {
                using (SupplyDbContext db = new SupplyDbContext())
                {
                    CB_Hostels.DataSource = db.Hostels.ToList();
                    CB_Hostels.DisplayMember = "Name";
                    CB_Hostels.ValueMember = "ID";
                }
            };

            Invoke(action);
        }

        private void CB_Hostels_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _hostelID = (int)CB_Hostels.SelectedValue;

                Thread thread = new Thread(ChangePlacesValue);
                thread.Start();
            }
            catch
            {
                return;
            }
        }

        private void ChangePlacesValue()
        {
            Action action = () =>
              {
                  using (SupplyDbContext db = new SupplyDbContext())
                  {
                      if (_hostelID != 0)
                      {
                          var enterances = db.Enterances.Where(hid => hid.HostelId == _hostelID).ToList();

                          List<int> places = new List<int>();

                          foreach (Enterance enterance in enterances)
                          {
                              var flats = db.Flats.Where(eid => eid.Enterance_ID == enterance.ID).ToList();
                              foreach (Flat flat in flats)
                              {
                                  var rooms = db.Rooms.Where(fid => fid.FlatID == flat.ID).ToList();
                                  foreach (Room room in rooms)
                                  {
                                      places.Add(room.Places);
                                  }
                              }
                          }


                          var unique = places.Distinct();

                          CB_Places.DataSource = unique.ToList();
                      }

                  }
              };
            Invoke(action);
            
        }

        private void ChB_AllHostel_CheckedChanged(object sender, EventArgs e)
        {
            if(ChB_AllHostel.Checked)
            {
                ChB_EmptyPlaces.Enabled = false;
                CB_Places.Enabled = false;
            }
            else
            {
                ChB_EmptyPlaces.Enabled = true;
                CB_Places.Enabled = true;
            }
        }

        private void CB_Places_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _placesCount = (int)CB_Places.SelectedValue;
            }
            catch
            {
                return;
            }
            
        }

        
    }
}

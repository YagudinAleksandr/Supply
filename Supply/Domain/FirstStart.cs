using Supply.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supply.Domain
{
    public class FirstStart
    {
        public static string Start()
        {
            using (SupplyDbContext db = new SupplyDbContext())
            {
                try
                {
                    var roles = db.Roles.ToList();
                    if (roles.Count == 0)
                    {
                        db.Roles.Add(new Role() { ID = 1, Name = "ADMINISTRATOR", Title = "Администратор" });
                        db.Roles.Add(new Role() { ID = 2, Name = "MANAGER", Title = "Менеджер" });
                        db.Roles.Add(new Role() { ID = 3, Name = "USER", Title = "Пользователь" });
                        db.SaveChanges();
                    }

                    var users = db.Users.ToList();
                    if (users.Count == 0)
                    {
                        db.Users.Add(new User() { ID = 1, Name = "Ягудин Александр Германович", Login = "Yagudin", Password = "b081dbe85e1ec3ffc3d4e7d0227400cd", RoleID = 1 });
                    }

                    var additianlInformationTypes = db.AdditionalInformationTypes.ToList();
                    if (additianlInformationTypes.Count == 0)
                    {
                        db.AdditionalInformationTypes.Add(new AdditionalInformationType() { ID = 1, Name = "Телефон" });
                        db.AdditionalInformationTypes.Add(new AdditionalInformationType() { ID = 2, Name = "Адрес эл.почты" });
                        db.AdditionalInformationTypes.Add(new AdditionalInformationType() { ID = 3, Name = "Факультет" });
                        db.AdditionalInformationTypes.Add(new AdditionalInformationType() { ID = 4, Name = "Группа" });
                        db.AdditionalInformationTypes.Add(new AdditionalInformationType() { ID = 5, Name = "Форма обучения" });
                        db.AdditionalInformationTypes.Add(new AdditionalInformationType() { ID = 6, Name = "Ступень обучения" });
                        db.AdditionalInformationTypes.Add(new AdditionalInformationType() { ID = 7, Name = "Основа обучения" });
                        db.AdditionalInformationTypes.Add(new AdditionalInformationType() { ID = 8, Name = "Период заселения" });
                        db.AdditionalInformationTypes.Add(new AdditionalInformationType() { ID = 9, Name = "Доп.жилец" });
                        db.AdditionalInformationTypes.Add(new AdditionalInformationType() { ID = 10, Name = "Организация" });
                        db.SaveChanges();
                    }

                    var benefitTypes = db.BenefitTypes.ToList();
                    if (benefitTypes.Count == 0)
                    {
                        db.BenefitTypes.Add(new BenefitType() { ID = 1, Name = "сирота" });
                        db.BenefitTypes.Add(new BenefitType() { ID = 2, Name = "инвалид" });
                        db.BenefitTypes.Add(new BenefitType() { ID = 3, Name = "получатель социальной помощи" });
                        db.SaveChanges();
                    }

                    var documentTypes = db.DocumentTypes.ToList();
                    if (documentTypes.Count == 0)
                    {
                        db.DocumentTypes.Add(new DocumentType() { ID = 1, Name = "Паспорт" });
                        db.DocumentTypes.Add(new DocumentType() { ID = 2, Name = "Удостоверение" });
                        db.SaveChanges();
                    }

                    var tenantTypes = db.TenantTypes.ToList();
                    if (tenantTypes.Count == 0)
                    {
                        db.TenantTypes.Add(new TenantType() { ID = 1, Name = "Студент" });
                        db.TenantTypes.Add(new TenantType() { ID = 2, Name = "Сотрудник" });
                        db.TenantTypes.Add(new TenantType() { ID = 3, Name = "Иной" });
                        db.SaveChanges();
                    }

                    return string.Empty;
                }
                catch(Exception ex)
                {
                    return ex.Message + "." + ex.InnerException;
                }
                
            }
        }
    }
}

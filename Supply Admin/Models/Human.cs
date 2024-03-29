﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supply_Admin.Models
{
    public class Human
    {
        public int Id { get; set; }
        public string Name { get; set; } //Имя
        public string Surename { get; set; }//Фамилия
        public string Patronymic { get; set; }//Отчество
        public string PhoneNumber { get; set; }//Номер телефона

        public string DocType { get; set; }//Документ удостоверяющий личность
        public string Series { get; set; }//Серия
        public string Number { get; set; }//Номер
        public string Given { get; set; }//Кем выдан
        public string GivenDate { get; set; }//Дата выдачи
        public string GivenCode { get; set; }//Код подразделения
        public string Registration { get; set; }//Зарегистрирован
        public string Citizenship { get; set; }//Гражданство

        public string GroupName { get; set; }//Группа обучающегося
        
        public int? RoomId { get; set; }
        public Rooms Room { get; set; }

        
    }
}

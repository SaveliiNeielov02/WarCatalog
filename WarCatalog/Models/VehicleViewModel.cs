﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WarCatalog.Models
{
    [Table("vehicles")]
    public class Vehicle
    {
        [Key]
        [Column("id")]
        public int ID { get; set; }

        [ForeignKey("Type")]
        [Column("typeid")]
        public int TypeID { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("photourl")]
        public string PhotoURL { get; set; }

        [Column("description")]
        public string Description { get; set; }
        public Type Type { get; set; }
    }
    [Table("types")]
    public class Type
    {
        [Key]
        [Column("id")]
        public int ID { get; set; }

        [Column("typename")]
        public string TypeName { get; set; }
    }
    /*public class TanksRepository 
    {
        private List<Vehicle> tanksList;

        public TanksRepository()
        {
            tanksList = new List<Vehicle>
            {
                new Vehicle
                {
                    ID = 1,
                    Name = "Т-64БВ",
                    Type = new Type{ID = 1, TypeName = "Танк" },
                    PhotoURL = "https://1.bp.blogspot.com/-b1Gc-e6a0Kk/YE-L-BiWZWI/AAAAAAAA7hA/RN19giKPbuEQQmiG_2j1vSDmk4PCfbhLACLcBGAsYHQ/s0/384.webp",
                    Description =
                    "Т-64Б (1976 год) — модернизированный вариант танка Т-64А. Основные отличия: комплекс управляемого ракетного вооружения 9М112 «Кобра», для которого гладкоствольное орудие модифицировано (2А46-2) с добавлением возможности пуска ПТУР из канала ствола, новая система управления огнём 1А33-1 с прицелом-дальномером-прибором слежения 1Г42 со встроенным лазерным (квантовым) дальномером (впервые в СССР, с 7-летним опозданием относительно танка «Чифтен») с высокой точностью определения дальности до цели и системой определения поправки на боковое движение цели и с электронным баллистическим вычислителем с автоматическим вычислением поправок для стрельбы, система защиты от напалма, система пуска дымовых гранат «Туча», сплошные бортовые экраны, увеличен динамический ход опорных катков. С 1984 по опытно-конструкторской работе «Отражение» на верхний лобовой лист наваривалась дополнительная стальная плита толщиной 30 мм. Поздние версии танка оснащены комплексом управляемого вооружения (ПТУР) 9К112-1 «Кобра» и полностью переработанным 125-мм орудием — пусковой установкой 2А46М-1, стабилизированным в двух плоскостях."

                },
                new Vehicle
                {
                    ID = 2,
                    Name = "Т-80БВМ",
                    Type = new Type{ID = 1, TypeName = "Танк" },
                    PhotoURL = "https://upload.wikimedia.org/wikipedia/commons/c/c6/GeneralRehearsal2018-21.jpg",
                    Description =
                    "Российская модернизация основного боевого танка Т-80БВ семейства танков Т-80. Разработан и производится Омским заводом транспортного машиностроения (входит в Ростех). Контракт модернизацию устаревших Т-80БВ до уровня Т-80БВМ был подписан с Минобороны РФ на форуме Армия-2017[1]. Т-80БВМ находится на вооружении российской и украинской армии."

                },
                new Vehicle
                {
                    ID = 3,
                    Name = "Leopard2A6",
                    Type = new Type{ID = 1, TypeName = "Танк" },
                    PhotoURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/5d/Leopard_2_A7.JPG/640px-Leopard_2_A7.JPG",
                    Description =
                    "Леопард 2 (нем. Leopard) — немецкий основной боевой танк третьего поколения. Танк начала разрабатывать в 1968 году фирма Krauss-Maffei, в 1970 году министр обороны ФРГ Гельмут Шмидт сделал его основой для перспективного боевого танка для бундесвера, в 1972 году были построены первые прототипы. В 1976 году прототип Леопард 2AV проходил сравнительные испытания вместе с прототипом XM1 на Абердинском полигоне в США. Первый серийный танк Леопард 2 был передан немецкой армии 25 октября 1979 года. Благодаря высокой огневой мощи, постоянному улучшению боеприпасов, хорошей защите, высокой точности стрельбы (в том числе в движении), высококачественным приборам наблюдения танк пользуется большим спросом на экспортном рынке. После окончания холодной войны Германия и два других первых оператора танка ― Нидерланды и Швейцария — стали предлагать танки на экспорт из состава своих вооружённых сил. В результате танк находится на вооружении 14 европейских стран, а также Канады, Турции, Катара, Сингапура и Чили, танковый парк бундесвера сократился с 2125 до 328 единиц, а Нидерланды полностью отказались от бронетанковых войск. В силу широкой географии стран-эксплуатантов, часть из которых производили танки на собственной территории, существует большое количество модификаций танка и проектов его модернизации, наиболее распространённой является модификация 2A4 и её модернизации, а наиболее современной серийной — 2A7V. К 2015 году всего было произведено более 3600 танков этого типа."

                },
                new Vehicle
                {
                    ID = 4,
                    Name = "Т-72Б3",
                    Type = new Type{ID = 1, TypeName = "Танк" },
                    PhotoURL = "https://warspot-asset.s3.amazonaws.com/articles/pictures/000/094/054/content/01-6cb6c8081c21362b94a8b169f891678e.jpg",
                    Description =
                    "Т-72Б3 — российский основной боевой танк семейства Т-72. Модификация Т-72Б3 разработана в качестве массовой и экономичной альтернативы основному танку Т-90А до получения Вооружёнными силами Российской Федерации танков нового поколения, Т-14. Представляет собой сравнительно простую и эффективную модернизацию танка Т-72Б, с доведением некоторых параметров до уровня Т-90А или превосходящих как в Т-72Б3 обр. 2016 (УБХ или Т-72Б3М)."
                }
            };
        }

        public List<Vehicle> GetTanks()
        {
            return tanksList;
        }
    }*/



    /*public class EntityTanksRepository
    {
        private readonly DbContextOptions<ModelDbContext> _dbContextOptions;

        public EntityTanksRepository(DbContextOptions<ModelDbContext> dbContextOptions)
        {
            _dbContextOptions = dbContextOptions;
        }

        public List<TankViewModel> GetTanks()
        {
            using (var context = new ModelDbContext(_dbContextOptions))
            {
                List<TankViewModel> tanks = context.Tanks.ToList();
                return tanks.Select(t => new TankViewModel
                {
                    ID = t.ID,
                    Name = t.Name,
                    PhotoURL = t.PhotoURL,
                    Description = t.Description
                }).ToList();
            }
        }

    }*/

}

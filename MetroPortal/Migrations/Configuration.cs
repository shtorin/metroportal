namespace MetroPortal.Migrations {
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;
    using MetroPortal.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<MetroPortal.Models.MetroPortalEntities> {
        public Configuration() {
            AutomaticMigrationsEnabled = false;
        }

        // Возвращает список всех районов Москвы
        private List<Disctrict> getDistrictsList() {
            List<Disctrict> allDistricts = new List<Disctrict> {
                new Disctrict { DistrictName = "Академический" },
                new Disctrict { DistrictName = "Алексеевский" },
                new Disctrict { DistrictName = "Алтуфьевский" },
                new Disctrict { DistrictName = "Арбат" },
                new Disctrict { DistrictName = "Аэропорт" },
                new Disctrict { DistrictName = "Бабушкинский" },
                new Disctrict { DistrictName = "Басманный" },
                new Disctrict { DistrictName = "Беговой" },
                new Disctrict { DistrictName = "Бескудниковский" },
                new Disctrict { DistrictName = "Бибирево" },
                new Disctrict { DistrictName = "Бирюлёво Восточное" },
                new Disctrict { DistrictName = "Бирюлёво Западное" },
                new Disctrict { DistrictName = "Богородское" },
                new Disctrict { DistrictName = "Братеево" },
                new Disctrict { DistrictName = "Бутырский" },
                new Disctrict { DistrictName = "Вешняки" },
                new Disctrict { DistrictName = "Внуково" },
                new Disctrict { DistrictName = "Войковский" },
                new Disctrict { DistrictName = "Восточное Дегунино" },
                new Disctrict { DistrictName = "Восточное Измайлово" },
                new Disctrict { DistrictName = "Восточный" },
                new Disctrict { DistrictName = "Выхино-Жулебино" },
                new Disctrict { DistrictName = "Гагаринский" },
                new Disctrict { DistrictName = "Головинский" },
                new Disctrict { DistrictName = "Гольяново" },
                new Disctrict { DistrictName = "Даниловский" },
                new Disctrict { DistrictName = "Дмитровский" },
                new Disctrict { DistrictName = "Донской" },
                new Disctrict { DistrictName = "Дорогомилово" },
                new Disctrict { DistrictName = "Замоскворечье" },
                new Disctrict { DistrictName = "Западное Дегунино" },
                new Disctrict { DistrictName = "Зюзино" },
                new Disctrict { DistrictName = "Зябликово" },
                new Disctrict { DistrictName = "Ивановское" },
                new Disctrict { DistrictName = "Измайлово" },
                new Disctrict { DistrictName = "Капотня" },
                new Disctrict { DistrictName = "Коньково" },
                new Disctrict { DistrictName = "Коптево" },
                new Disctrict { DistrictName = "Косино-Ухтомский" },
                new Disctrict { DistrictName = "Котловка" },
                new Disctrict { DistrictName = "Красносельский" },
                new Disctrict { DistrictName = "Крылатское" },
                new Disctrict { DistrictName = "Крюково" },
                new Disctrict { DistrictName = "Кузьминки" },
                new Disctrict { DistrictName = "Кунцево" },
                new Disctrict { DistrictName = "Куркино" },
                new Disctrict { DistrictName = "Левобережный" },
                new Disctrict { DistrictName = "Лефортово" },
                new Disctrict { DistrictName = "Лианозово" },
                new Disctrict { DistrictName = "Ломоносовский" },
                new Disctrict { DistrictName = "Лосиноостровский" },
                new Disctrict { DistrictName = "Люблино" },
                new Disctrict { DistrictName = "Марфино" },
                new Disctrict { DistrictName = "Марьина Роща" },
                new Disctrict { DistrictName = "Марьино" },
                new Disctrict { DistrictName = "Матушкино" },
                new Disctrict { DistrictName = "Метрогородок" },
                new Disctrict { DistrictName = "Мещанский" },
                new Disctrict { DistrictName = "Митино" },
                new Disctrict { DistrictName = "Можайский" },
                new Disctrict { DistrictName = "Молжаниновский" },
                new Disctrict { DistrictName = "Москворечье-Сабурово" },
                new Disctrict { DistrictName = "Нагатино-Садовники" },
                new Disctrict { DistrictName = "Нагатинский Затон" },
                new Disctrict { DistrictName = "Нагорный" },
                new Disctrict { DistrictName = "Некрасовка" },
                new Disctrict { DistrictName = "Нижегородский" },
                new Disctrict { DistrictName = "Новогиреево" },
                new Disctrict { DistrictName = "Новокосино" },
                new Disctrict { DistrictName = "Ново-Переделкино" },
                new Disctrict { DistrictName = "Обручевский" },
                new Disctrict { DistrictName = "Орехово-Борисово Северное" },
                new Disctrict { DistrictName = "Орехово-Борисово Южное" },
                new Disctrict { DistrictName = "Останкинский" },
                new Disctrict { DistrictName = "Отрадное" },
                new Disctrict { DistrictName = "Очаково-Матвеевское" },
                new Disctrict { DistrictName = "Перово" },
                new Disctrict { DistrictName = "Печатники" },
                new Disctrict { DistrictName = "Покровское-Стрешнево" },
                new Disctrict { DistrictName = "Преображенское" },
                new Disctrict { DistrictName = "Пресненский" },
                new Disctrict { DistrictName = "Проспект Вернадского" },
                new Disctrict { DistrictName = "Раменки" },
                new Disctrict { DistrictName = "Ростокино" },
                new Disctrict { DistrictName = "Рязанский" },
                new Disctrict { DistrictName = "Савёлки" },
                new Disctrict { DistrictName = "Савёловский" },
                new Disctrict { DistrictName = "Свиблово" },
                new Disctrict { DistrictName = "Северное Бутово" },
                new Disctrict { DistrictName = "Северное Измайлово" },
                new Disctrict { DistrictName = "Северное Медведково" },
                new Disctrict { DistrictName = "Северное Тушино" },
                new Disctrict { DistrictName = "Северный" },
                new Disctrict { DistrictName = "Силино" },
                new Disctrict { DistrictName = "Сокол" },
                new Disctrict { DistrictName = "Соколиная Гора" },
                new Disctrict { DistrictName = "Сокольники" },
                new Disctrict { DistrictName = "Солнцево" },
                new Disctrict { DistrictName = "Старое Крюково" },
                new Disctrict { DistrictName = "Строгино" },
                new Disctrict { DistrictName = "Таганский" },
                new Disctrict { DistrictName = "Тверской" },
                new Disctrict { DistrictName = "Текстильщики" },
                new Disctrict { DistrictName = "Тёплый Стан" },
                new Disctrict { DistrictName = "Тимирязевский" },
                new Disctrict { DistrictName = "Тропарёво-Никулино" },
                new Disctrict { DistrictName = "Филёвский Парк" },
                new Disctrict { DistrictName = "Фили-Давыдково" },
                new Disctrict { DistrictName = "Хамовники" },
                new Disctrict { DistrictName = "Ховрино" },
                new Disctrict { DistrictName = "Хорошёво-Мнёвники" },
                new Disctrict { DistrictName = "Хорошёвский" },
                new Disctrict { DistrictName = "Царицыно" },
                new Disctrict { DistrictName = "Черёмушки" },
                new Disctrict { DistrictName = "Чертаново Северное" },
                new Disctrict { DistrictName = "Чертаново Центральное" },
                new Disctrict { DistrictName = "Чертаново Южное" },
                new Disctrict { DistrictName = "Щукино" },
                new Disctrict { DistrictName = "Южное Бутово" },
                new Disctrict { DistrictName = "Южное Медведково" },
                new Disctrict { DistrictName = "Южное Тушино" },
                new Disctrict { DistrictName = "Южнопортовый" },
                new Disctrict { DistrictName = "Якиманка" },
                new Disctrict { DistrictName = "Ярославский" },
                new Disctrict { DistrictName = "Ясенево" },
                new Disctrict { DistrictName = "Внуковское" },
                new Disctrict { DistrictName = "Вороновское" },
                new Disctrict { DistrictName = "Воскресенское" },
                new Disctrict { DistrictName = "Десёновское" },
                new Disctrict { DistrictName = "Киевский" },
                new Disctrict { DistrictName = "Клёновское" },
                new Disctrict { DistrictName = "Кокошкино" },
                new Disctrict { DistrictName = "Краснопахорское" },
                new Disctrict { DistrictName = "Марушкинское" },
                new Disctrict { DistrictName = "Михайлово-Ярцевское" },
                new Disctrict { DistrictName = "Московский" },
                new Disctrict { DistrictName = "Мосрентген" },
                new Disctrict { DistrictName = "Новофёдоровское" },
                new Disctrict { DistrictName = "Первомайское" },
                new Disctrict { DistrictName = "Роговское" },
                new Disctrict { DistrictName = "Рязановское" },
                new Disctrict { DistrictName = "Сосенское" },
                new Disctrict { DistrictName = "Троицк" },
                new Disctrict { DistrictName = "Филимонковское" },
                new Disctrict { DistrictName = "Щаповское" },
                new Disctrict { DistrictName = "Щербинка" }
            };

            return allDistricts;
        }

        // Возвращает список всех веток метрополитена
        private List<Line> getLinesList() {
            List<Line> allLines = new List<Line> {
                new Line() { LineName = "Сокольническая", Color = 0, Stations = new List<Station>() },
                new Line() { LineName = "Замоскворецкая", Color = 1, Stations = new List<Station>() },
                new Line() { LineName = "Арбатско-Покровская", Color = 2, Stations = new List<Station>() },
                new Line() { LineName = "Филёвская", Color = 3, Stations = new List<Station>() },
                new Line() { LineName = "Кольцевая", Color = 4, Stations = new List<Station>() },
                new Line() { LineName = "Калужско-Рижская", Color = 5, Stations = new List<Station>() },
                new Line() { LineName = "Таганско-Краснопресненская	", Color = 6, Stations = new List<Station>() },
                new Line() { LineName = "Калининская", Color = 7, Stations = new List<Station>() },
                new Line() { LineName = "Солнцевская", Color = 8, Stations = new List<Station>() },
                new Line() { LineName = "Серпуховско-Тимирязевская", Color = 9, Stations = new List<Station>() },
                new Line() { LineName = "Люблинско-Дмитровская", Color = 10, Stations = new List<Station>() },
                new Line() { LineName = "Каховская", Color = 11, Stations = new List<Station>() },
                new Line() { LineName = "Бутовская", Color = 12, Stations = new List<Station>() },
                new Line() { LineName = "Монорельс", Color = 13, Stations = new List<Station>() },
                new Line() { LineName = "Московское центральное кольцо", Color = 14, Stations = new List<Station>() }
            };

            return allLines;
        }

        // Возвращает список станций для каждой ветки
        private List<List<Station>> getLineStationsList(MetroPortalEntities context) {
            var allStations = new List<List<Station>>() {
                // Сокольническая
                new List<Station>() {
                    new Station() { StationName = "Бульвар Рокоссовского", Address = "",
                        Line = context.Lines.Single(l => l.LineName == "Сокольническая"),
                        District = context.Districts.SingleOrDefault(d => d.DistrictName == "Богородское")},
                    new Station() { StationName = "Черкизовская", Address = "", Line = context.Lines.Single(l => l.LineName == "Сокольническая"),
                        District = context.Districts.SingleOrDefault(d => d.DistrictName == "Преображенское") },
                    new Station() { StationName = "Преображенская площадь", Address = "", Line = context.Lines.Single(l => l.LineName == "Сокольническая"),
                        District = context.Districts.SingleOrDefault(d => d.DistrictName == "Преображенское") },
                    new Station() { StationName = "Сокольники", Address = "", Line = context.Lines.Single(l => l.LineName == "Сокольническая"),
                        District = context.Districts.SingleOrDefault(d => d.DistrictName == "Сокольники") },
                },
                
                // Замоскворецкая
                new List<Station>() { },
                
                // Арбатско-Покровская
                new List<Station>() { },
                
                // Филёвская
                new List<Station>() { },
                
                // Кольцевая
                new List<Station>() { },
                
                // Калужско-Рижская
                new List<Station>() { },
                
                // Таганско-Краснопресненская
                new List<Station>() { },
                
                // Калининская
                new List<Station>() { },
                
                // Солнцевская
                new List<Station>() { },
                
                // Серпуховско-Тимирязевская
                new List<Station>() { },
                
                // Люблинско-Дмитровская
                new List<Station>() { },
                
                // Каховская
                new List<Station>() { },
                
                // Бутовская
                new List<Station>() { },
                
                // Монорельс
                new List<Station>() { },
                
                // Московское центральное кольцо
                new List<Station>() { },
            };

            return allStations;
        }

        protected override void Seed(MetroPortalEntities context) {
            // Добавляем районы
            var districts = getDistrictsList();
            districts.ForEach(district => context.Districts.AddOrUpdate(d => d.DistrictName, district));
            
            // Добавляем ветки
            var lines = getLinesList();
            lines.ForEach(line => context.Lines.AddOrUpdate(l => l.LineName, line));
            
            // Добавляем станции веткам
            // Получаем все станции
            var allStations = getLineStationsList(context);
            foreach (Line line in lines) {
                // Список станций текущей ветки
                var currentLineStations = allStations[line.LineId - 1];
                line.Stations = currentLineStations;
                currentLineStations.ForEach(station => context.Stations.AddOrUpdate(s => s.StationName, station));
                context.Lines.AddOrUpdate(l => l.LineName, line);
            }

            context.SaveChanges();
        }
    }
}

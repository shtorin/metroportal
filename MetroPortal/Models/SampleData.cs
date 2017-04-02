using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Globalization;
using System.Linq;
using System.IO;
using MetroPortal.Models;
using System.Collections.Generic;
using System.Web;


namespace MetroPortal.Models {

    public class SampleData : CreateDatabaseIfNotExists<MetroPortalEntities> {

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

        public void readTransfersFromFile(MetroPortalEntities context, string fileName) {
            using (var fs = File.OpenRead(fileName))
            using (var reader = new StreamReader(fs)) {

                while (!reader.EndOfStream) {
                    try {
                        var row = reader.ReadLine();
                        var values = row.Split('\t');

                        var lineFromName = values[0];
                        var stationFromName = values[1];
                        var lineToName = values[2];
                        var stationToName = values[3];

                        var lineFrom = context.Lines.Single(l => l.LineName == lineFromName);
                        var stationFrom = context.Stations.Single(s => s.StationName == stationFromName && s.LineId == lineFrom.LineId);

                        var lineTo = context.Lines.Single(l => l.LineName == lineToName);
                        var stationTo = context.Stations.Single(s => s.StationName == stationToName && s.LineId == lineTo.LineId);

                        stationFrom.TransfersTo.Add(stationTo);

                        context.SaveChanges();
                    }
                    catch (InvalidOperationException ex) {

                    }
                }

            }
        }

        public void readStationsFromFile(MetroPortalEntities context, string fileName) {
            using (var fs = File.OpenRead(fileName))
            using (var reader = new StreamReader(fs)) {

                while (!reader.EndOfStream) {
                    try {
                        var row = reader.ReadLine();
                        var values = row.Split('\t');

                        var lineName = values[0];
                        var stationName = values[1];
                        double latitude;
                        double.TryParse(values[2], NumberStyles.Any, CultureInfo.InvariantCulture, out latitude);
                        double longtitude;
                        double.TryParse(values[3], NumberStyles.Any, CultureInfo.InvariantCulture, out longtitude);

                        var currentLine = context.Lines.Single(l => l.LineName == lineName);
                        var newStation = new Station() {
                            StationName = stationName,
                            Latitude = latitude,
                            Longtitude = longtitude,
                            Line = context.Lines.Single(l => l.LineName == lineName)
                        };
                        currentLine.Stations.Add(newStation);
                        context.Stations.AddOrUpdate(s => s.StationName, newStation);

                        context.SaveChanges();
                    }
                    catch (InvalidOperationException ex) {

                    }
                }
            }
        }


        protected override void Seed(MetroPortalEntities context) {

            // Добавляем ветки
            var lines = getLinesList();
            lines.ForEach(line => context.Lines.AddOrUpdate(l => l.LineName, line));
            context.SaveChanges();

            readStationsFromFile(context, HttpContext.Current.Server.MapPath("~/Content/stations.txt"));
            readStationsFromFile(context, HttpContext.Current.Server.MapPath("~/Content/lines.txt"));

            context.SaveChanges();
        }

    }
}